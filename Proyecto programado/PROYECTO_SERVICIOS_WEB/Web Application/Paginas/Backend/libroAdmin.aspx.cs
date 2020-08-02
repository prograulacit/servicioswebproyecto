using BLL.Logica;
using BLL.Objeto;
using System;
using System.IO;
using System.Linq;
using System.Web.UI;

namespace Web_Application.Paginas.Backend
{
    public partial class libroAdmin : System.Web.UI.Page
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

        protected void subirArchivosLibro_Click(object sender, EventArgs e)
        {
            if (Session["update"].ToString() == ViewState["update"].ToString())
            {
                try
                {
                    Parametros parametros = new Parametros();
                    string rutaPrincipal = parametros.traerParametros().First().rutaAlmacenamientoLibros;
                    string rutaArchivo = rutaPrincipal + "\\" + nombreArchivoLibro.Value.ToString();
                    string rutaPrincipalPrev = parametros.traerParametros().First().rutaAlmacenamientoPrevisualizacionLibros;
                    string rutaArchivoPrev = rutaPrincipalPrev + "\\" + nombrePrevisualizacionLibro.Value.ToString();
                    archivoLibro.PostedFile.SaveAs(rutaArchivo);
                    archivoLibroPrev.PostedFile.SaveAs(rutaArchivoPrev);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "exitoCrear", "exitoMensaje('Elemento creado con exito')", true);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
                }
                Session["update"] = Server.UrlEncode(System.DateTime.Now.ToString());
            }
        }


        protected void editarArchivosLibro_Click(object sender, EventArgs e)
        {
            if (Session["update"].ToString() == ViewState["update"].ToString())
            {
                try
                {
                    Parametros parametros = new Parametros();
                    string rutaPrincipal = parametros.traerParametros().First().rutaAlmacenamientoLibros;
                    string rutaPrincipalPrev = parametros.traerParametros().First().rutaAlmacenamientoPrevisualizacionLibros;
                    string rutaArchivoViejo = rutaPrincipal + "\\" + viejoNombreDescargaLibro.Value;
                    string rutaArchivoNuevo = rutaPrincipal + "\\" + editarNombreDescargaLibro.Value;
                    string rutaArchivoViejoPrev = rutaPrincipalPrev + "\\" + viejoNombrePrevisualizacionLibro.Value;
                    string rutaArchivoNuevoPrev = rutaPrincipalPrev + "\\" + editarNombrePrevisualizacionLibro.Value;

                    if ((editarArchivoLibro.PostedFile.ContentLength == 0) && (viejoNombreDescargaLibro.Value != editarNombreDescargaLibro.Value) && File.Exists(rutaArchivoViejo))
                    {
                        //Editar solo ruta archivo libro
                        File.Move(rutaArchivoViejo, rutaArchivoNuevo);
                    }
                    else if ((editarArchivoLibro.PostedFile.ContentLength > 0) && (viejoNombreDescargaLibro.Value != editarNombreDescargaLibro.Value) && File.Exists(rutaArchivoViejo))
                    {
                        //Editar archivo de libro y ruta
                        File.Delete(rutaArchivoViejo);
                        editarArchivoLibro.PostedFile.SaveAs(rutaArchivoNuevo);
                    }
                    else if ((editarArchivoLibro.PostedFile.ContentLength > 0) && (viejoNombreDescargaLibro.Value == editarNombreDescargaLibro.Value) && File.Exists(rutaArchivoViejo))
                    {
                        //Editar solo archivo de libro
                        File.Delete(rutaArchivoViejo);
                        editarArchivoLibro.PostedFile.SaveAs(rutaArchivoViejo);
                    }

                    if ((editarArchivoLibroPrev.PostedFile.ContentLength == 0) && (viejoNombrePrevisualizacionLibro.Value != editarNombrePrevisualizacionLibro.Value) && File.Exists(rutaArchivoViejoPrev))
                    {
                        //Editar solo ruta archivo previsualizacion libro
                        File.Move(rutaArchivoViejoPrev, rutaArchivoNuevoPrev);
                    }
                    else if ((editarArchivoLibroPrev.PostedFile.ContentLength > 0) && (viejoNombrePrevisualizacionLibro.Value != editarNombrePrevisualizacionLibro.Value) && File.Exists(rutaArchivoViejoPrev))
                    {
                        //Editar archivo de libro previsualizacion y ruta
                        File.Delete(rutaArchivoViejoPrev);
                        editarArchivoLibroPrev.PostedFile.SaveAs(rutaArchivoNuevoPrev);
                    }
                    else if ((editarArchivoLibroPrev.PostedFile.ContentLength > 0) && (viejoNombrePrevisualizacionLibro.Value == editarNombrePrevisualizacionLibro.Value) && File.Exists(rutaArchivoViejoPrev))
                    {
                        //Editar solo archivo de libro previsualizacion
                        File.Delete(rutaArchivoViejoPrev);
                        editarArchivoLibroPrev.PostedFile.SaveAs(rutaArchivoViejoPrev);
                    }
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "exitoCrear", "exitoMensaje('Elemento actualizado con exito')", true);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
                }
                Session["update"] = Server.UrlEncode(System.DateTime.Now.ToString());
            }
        }

        protected void eliminarArchivoLibro_Click(object sender, EventArgs e)
        {
            if (Session["update"].ToString() == ViewState["update"].ToString())
            {
                try
                {
                    Parametros parametros = new Parametros();
                    string rutaPrincipal = parametros.traerParametros().First().rutaAlmacenamientoLibros;
                    string rutaPrincipalPrev = parametros.traerParametros().First().rutaAlmacenamientoPrevisualizacionLibros;
                    string rutaArchivo = rutaPrincipal + "\\" + viejoNombreDescargaLibro.Value;
                    string rutaArchivoPrev = rutaPrincipalPrev + "\\" + viejoNombrePrevisualizacionLibro.Value;
                    if (File.Exists(rutaArchivo)) { File.Delete(rutaArchivo); }
                    if (File.Exists(rutaArchivoPrev)) { File.Delete(rutaArchivoPrev); }
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "exitoMensaje", "exitoMensaje('Elemento eliminado con exito.')", true);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
                }
                Session["update"] = Server.UrlEncode(System.DateTime.Now.ToString());
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            ViewState["update"] = Session["update"];
        }
    }
}