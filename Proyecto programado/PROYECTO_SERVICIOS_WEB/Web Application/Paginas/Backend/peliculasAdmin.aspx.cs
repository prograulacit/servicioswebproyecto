using BLL.Logica;
using BLL.Objeto;
using System;
using System.IO;
using System.Linq;
using System.Web.UI;

namespace Web_Application.Paginas.Backend
{
    public partial class peliculasAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool adminMaestro = Memoria.sesionAdminDatos.adminMaestro;
            bool mantenimiento = Memoria.sesionAdminDatos.adminMantenimiento;

            if (!adminMaestro && !mantenimiento)
            {
                Response.Redirect("~/Paginas/Backend/Index.aspx");
            }

            if (!IsPostBack)
            {
                Session["update"] = Server.UrlEncode(System.DateTime.Now.ToString());
            }
        }

        protected void subirArchivosPelicula_Click(object sender, EventArgs e)
        {
            if (Session["update"].ToString() == ViewState["update"].ToString())
            {
                try
                {
                    Parametros parametros = new Parametros();
                    string rutaPrincipal = parametros.traerParametros().First().rutaAlmacenamientoPeliculas;
                    string rutaArchivo = rutaPrincipal + "\\" + nombreArchivoPelicula.Value.ToString();
                    string rutaPrincipalPrev = parametros.traerParametros().First().rutaAlmacenamientoPrevisualizacionPeliculas;
                    string rutaArchivoPrev = rutaPrincipalPrev + "\\" + nombrePrevisualizacionPelicula.Value.ToString();
                    archivoPelicula.PostedFile.SaveAs(rutaArchivo);
                    archivoPeliculaPrev.PostedFile.SaveAs(rutaArchivoPrev);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "exitoCrear", "exitoMensaje('Elemento creado con exito')", true);
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "errorMensaje", "errorMensaje('Error: " + ex.Message + "')", true);
                }
                Session["update"] = Server.UrlEncode(System.DateTime.Now.ToString());
            }
        }


        protected void editarArchivosPelicula_Click(object sender, EventArgs e)
        {
            if (Session["update"].ToString() == ViewState["update"].ToString())
            {
                try
                {
                    Parametros parametros = new Parametros();
                    string rutaPrincipal = parametros.traerParametros().First().rutaAlmacenamientoPeliculas;
                    string rutaPrincipalPrev = parametros.traerParametros().First().rutaAlmacenamientoPrevisualizacionPeliculas;
                    string rutaArchivoViejo = rutaPrincipal + "\\" + viejoNombreDescargaPelicula.Value;
                    string rutaArchivoNuevo = rutaPrincipal + "\\" + editarNombreDescargaPelicula.Value;
                    string rutaArchivoViejoPrev = rutaPrincipalPrev + "\\" + viejoNombrePrevisualizacionPelicula.Value;
                    string rutaArchivoNuevoPrev = rutaPrincipalPrev + "\\" + editarNombrePrevisualizacionPelicula.Value;

                    if ((editarArchivoPelicula.PostedFile.ContentLength == 0) && (viejoNombreDescargaPelicula.Value != editarNombreDescargaPelicula.Value) && File.Exists(rutaArchivoViejo))
                    {
                        //Editar solo ruta archivo pelicula
                        File.Move(rutaArchivoViejo, rutaArchivoNuevo);
                    }
                    else if ((editarArchivoPelicula.PostedFile.ContentLength > 0) && (viejoNombreDescargaPelicula.Value != editarNombreDescargaPelicula.Value) && File.Exists(rutaArchivoViejo))
                    {
                        //Editar archivo de pelicula y ruta
                        File.Delete(rutaArchivoViejo);
                        editarArchivoPelicula.PostedFile.SaveAs(rutaArchivoNuevo);
                    }
                    else if ((editarArchivoPelicula.PostedFile.ContentLength > 0) && (viejoNombreDescargaPelicula.Value == editarNombreDescargaPelicula.Value) && File.Exists(rutaArchivoViejo))
                    {
                        //Editar solo archivo de pelicula
                        File.Delete(rutaArchivoViejo);
                        editarArchivoPelicula.PostedFile.SaveAs(rutaArchivoViejo);
                    }

                    if ((editarArchivoPeliculaPrev.PostedFile.ContentLength == 0) && (viejoNombrePrevisualizacionPelicula.Value != editarNombrePrevisualizacionPelicula.Value) && File.Exists(rutaArchivoViejoPrev))
                    {
                        //Editar solo ruta archivo previsualizacion pelicula
                        File.Move(rutaArchivoViejoPrev, rutaArchivoNuevoPrev);
                    }
                    else if ((editarArchivoPeliculaPrev.PostedFile.ContentLength > 0) && (viejoNombrePrevisualizacionPelicula.Value != editarNombrePrevisualizacionPelicula.Value) && File.Exists(rutaArchivoViejoPrev))
                    {
                        //Editar archivo de pelicula previsualizacion y ruta
                        File.Delete(rutaArchivoViejoPrev);
                        editarArchivoPeliculaPrev.PostedFile.SaveAs(rutaArchivoNuevoPrev);
                    }
                    else if ((editarArchivoPeliculaPrev.PostedFile.ContentLength > 0) && (viejoNombrePrevisualizacionPelicula.Value == editarNombrePrevisualizacionPelicula.Value) && File.Exists(rutaArchivoViejoPrev))
                    {
                        //Editar solo archivo de pelicula previsualizacion
                        File.Delete(rutaArchivoViejoPrev);
                        editarArchivoPeliculaPrev.PostedFile.SaveAs(rutaArchivoViejoPrev);
                    }
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "exitoCrear", "exitoMensaje('Elemento actualizado con exito')", true);
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "errorMensaje", "errorMensaje('Error: " + ex.Message + "')", true);
                }
                Session["update"] = Server.UrlEncode(System.DateTime.Now.ToString());
            }
        }

        protected void eliminarArchivoPelicula_Click(object sender, EventArgs e)
        {
            Parametros parametros = new Parametros();

            try
            {
                string rutaPrincipal = parametros.traerParametros().First().rutaAlmacenamientoPeliculas;
                string rutaPrincipalPrev = parametros.traerParametros().First().rutaAlmacenamientoPrevisualizacionPeliculas;
                string rutaArchivo = rutaPrincipal + "\\" + viejoNombreDescargaPelicula.Value;
                string rutaArchivoPrev = rutaPrincipalPrev + "\\" + viejoNombrePrevisualizacionPelicula.Value;
                if (File.Exists(rutaArchivo)) { File.Delete(rutaArchivo); }
                if (File.Exists(rutaArchivoPrev)) { File.Delete(rutaArchivoPrev); }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "exitoMensaje", "exitoMensaje('Elemento eliminado con exito.')", true);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "errorMensaje", "errorMensaje('Error: " + ex.Message + "')", true);
            }
        }
    }
}