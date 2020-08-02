using BLL.Logica;
using BLL.Objeto;
using System;
using System.IO;
using System.Linq;
using System.Web.UI;

namespace Web_Application.Paginas.Backend
{
    public partial class musicaAdmin : System.Web.UI.Page
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

        protected void subirArchivosMusica_Click(object sender, EventArgs e)
        {
            if (Session["update"].ToString() == ViewState["update"].ToString())
            {
                try
                {
                    Parametros parametros = new Parametros();
                    string rutaPrincipal = parametros.traerParametros().First().rutaAlmacenamientoMusica;
                    string rutaArchivo = rutaPrincipal + "\\" + nombreArchivoMusica.Value.ToString();
                    string rutaPrincipalPrev = parametros.traerParametros().First().rutaAlmacenamientoPrevisualizacionMusica;
                    string rutaArchivoPrev = rutaPrincipalPrev + "\\" + nombrePrevisualizacionMusica.Value.ToString();
                    archivoMusica.PostedFile.SaveAs(rutaArchivo);
                    archivoMusicaPrev.PostedFile.SaveAs(rutaArchivoPrev);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "exitoCrear", "exitoMensaje('Elemento creado con exito')", true);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
                }
                Session["update"] = Server.UrlEncode(System.DateTime.Now.ToString());
            }
        }


        protected void editarArchivosMusica_Click(object sender, EventArgs e)
        {
            if (Session["update"].ToString() == ViewState["update"].ToString())
            {
                try
                {
                    Parametros parametros = new Parametros();
                    string rutaPrincipal = parametros.traerParametros().First().rutaAlmacenamientoMusica;
                    string rutaPrincipalPrev = parametros.traerParametros().First().rutaAlmacenamientoPrevisualizacionMusica;
                    string rutaArchivoViejo = rutaPrincipal + "\\" + viejoNombreDescargaMusica.Value;
                    string rutaArchivoNuevo = rutaPrincipal + "\\" + editarNombreDescargaMusica.Value;
                    string rutaArchivoViejoPrev = rutaPrincipalPrev + "\\" + viejoNombrePrevisualizacionMusica.Value;
                    string rutaArchivoNuevoPrev = rutaPrincipalPrev + "\\" + editarNombrePrevisualizacionMusica.Value;

                    if ((editarArchivoMusica.PostedFile.ContentLength == 0) && (viejoNombreDescargaMusica.Value != editarNombreDescargaMusica.Value) && File.Exists(rutaArchivoViejo))
                    {
                        //Editar solo ruta archivo musica
                        File.Move(rutaArchivoViejo, rutaArchivoNuevo);
                    }
                    else if ((editarArchivoMusica.PostedFile.ContentLength > 0) && (viejoNombreDescargaMusica.Value != editarNombreDescargaMusica.Value) && File.Exists(rutaArchivoViejo))
                    {
                        //Editar archivo de musica y ruta
                        File.Delete(rutaArchivoViejo);
                        editarArchivoMusica.PostedFile.SaveAs(rutaArchivoNuevo);
                    }
                    else if ((editarArchivoMusica.PostedFile.ContentLength > 0) && (viejoNombreDescargaMusica.Value == editarNombreDescargaMusica.Value) && File.Exists(rutaArchivoViejo))
                    {
                        //Editar solo archivo de musica
                        File.Delete(rutaArchivoViejo);
                        editarArchivoMusica.PostedFile.SaveAs(rutaArchivoViejo);
                    }

                    if ((editarArchivoMusicaPrev.PostedFile.ContentLength == 0) && (viejoNombrePrevisualizacionMusica.Value != editarNombrePrevisualizacionMusica.Value) && File.Exists(rutaArchivoViejoPrev))
                    {
                        //Editar solo ruta archivo previsualizacion musica
                        File.Move(rutaArchivoViejoPrev, rutaArchivoNuevoPrev);
                    }
                    else if ((editarArchivoMusicaPrev.PostedFile.ContentLength > 0) && (viejoNombrePrevisualizacionMusica.Value != editarNombrePrevisualizacionMusica.Value) && File.Exists(rutaArchivoViejoPrev))
                    {
                        //Editar archivo de musica previsualizacion y ruta
                        File.Delete(rutaArchivoViejoPrev);
                        editarArchivoMusicaPrev.PostedFile.SaveAs(rutaArchivoNuevoPrev);
                    }
                    else if ((editarArchivoMusicaPrev.PostedFile.ContentLength > 0) && (viejoNombrePrevisualizacionMusica.Value == editarNombrePrevisualizacionMusica.Value) && File.Exists(rutaArchivoViejoPrev))
                    {
                        //Editar solo archivo de musica previsualizacion
                        File.Delete(rutaArchivoViejoPrev);
                        editarArchivoMusicaPrev.PostedFile.SaveAs(rutaArchivoViejoPrev);
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

        protected void eliminarArchivoMusica_Click(object sender, EventArgs e)
        {
            if (Session["update"].ToString() == ViewState["update"].ToString())
            {
                try
                {
                    Parametros parametros = new Parametros();
                    string rutaPrincipal = parametros.traerParametros().First().rutaAlmacenamientoMusica;
                    string rutaPrincipalPrev = parametros.traerParametros().First().rutaAlmacenamientoPrevisualizacionMusica;
                    string rutaArchivo = rutaPrincipal + "\\" + viejoNombreDescargaMusica.Value;
                    string rutaArchivoPrev = rutaPrincipalPrev + "\\" + viejoNombrePrevisualizacionMusica.Value;

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