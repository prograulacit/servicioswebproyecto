using BLL.Logica;
using BLL.Objeto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        }

        protected void subirArchivosPelicula_Click(object sender, EventArgs e)
        {
            Parametros parametros = new Parametros();
            string rutaPrincipal = parametros.traerParametros().First().rutaAlmacenamientoPeliculas;
            string rutaArchivo = rutaPrincipal + "\\" + nombreArchivoPelicula.Value.ToString();
            bool exitoArchivo = false;
            bool exitoArchivoPrev = false;

            if (!File.Exists(rutaArchivo))
            {
                archivoPelicula.PostedFile.SaveAs(rutaArchivo);
                exitoArchivo = true;
            }

            //Subida archivo musica previsualizacion
            string rutaPrincipalPrev = parametros.traerParametros().First().rutaAlmacenamientoPrevisualizacionMusica;
            string rutaArchivoPrev = rutaPrincipalPrev + "\\" + nombrePrevisualizacionPelicula.Value.ToString();
            if (exitoArchivo && !File.Exists(rutaArchivoPrev))
            {
                archivoPeliculaPrev.PostedFile.SaveAs(rutaArchivoPrev);
                exitoArchivoPrev = true;
            }

            if (exitoArchivo && exitoArchivoPrev)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "exitoCrear", "exitoMensaje('Elemento creado con exito')", true);
            }
            else
            {
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "eliminar_ultima", "eliminar_elemento('"+ ultimaMusicaId.Value + "', 'null', 'null')", true);
            }
        }


        protected void editarArchivosPelicula_Click(object sender, EventArgs e)
        {
            Parametros parametros = new Parametros();
            string rutaPrincipal = parametros.traerParametros().First().rutaAlmacenamientoPeliculas;
            string rutaPrincipalPrev = parametros.traerParametros().First().rutaAlmacenamientoPrevisualizacionPeliculas;
            string rutaArchivoViejo = rutaPrincipal + "\\" + viejoNombreDescargaPelicula.Value;
            string rutaArchivoNuevo = rutaPrincipal + "\\" + editarNombreDescargaPelicula.Value;
            string rutaArchivoViejoPrev = rutaPrincipalPrev + "\\" + viejoNombrePrevisualizacionPelicula.Value;
            string rutaArchivoNuevoPrev = rutaPrincipalPrev + "\\" + editarNombrePrevisualizacionPelicula.Value;
            string errorMensaje = "";
            bool exitoArchivo = true;
            bool exitoArchivoPrev = true;

            if ((editarArchivoPelicula.PostedFile.ContentLength == 0) && (viejoNombreDescargaPelicula.Value != editarNombreDescargaPelicula.Value) && File.Exists(rutaArchivoViejo))
            {
                //Editar solo ruta archivo musica
                if (!File.Exists(rutaArchivoNuevo))
                {
                    File.Move(rutaArchivoViejo, rutaArchivoNuevo);
                }
                else
                {
                    exitoArchivo = false;
                    errorMensaje = "El archivo de musica ya existe. Por favor, ingresar otro nombre de archivo.";
                }
            }
            else if ((editarArchivoPelicula.PostedFile.ContentLength > 0) && (viejoNombreDescargaPelicula.Value != editarNombreDescargaPelicula.Value) && File.Exists(rutaArchivoViejo))
            {
                //Editar archivo de musica y ruta
                if (!File.Exists(rutaArchivoNuevo))
                {
                    File.Delete(rutaArchivoViejo);
                    editarArchivoPelicula.PostedFile.SaveAs(rutaArchivoNuevo);
                }
                else
                {
                    exitoArchivo = false;
                    errorMensaje = "El archivo de musica ya existe. Por favor, ingresar otro nombre de archivo.";
                }
            }
            else if ((editarArchivoPelicula.PostedFile.ContentLength > 0) && (viejoNombreDescargaPelicula.Value == editarNombreDescargaPelicula.Value) && File.Exists(rutaArchivoViejo))
            {
                //Editar archivo de musica
                File.Delete(rutaArchivoViejo);
                editarArchivoPelicula.PostedFile.SaveAs(rutaArchivoViejo);
            }

            if ((editarArchivoPeliculaPrev.PostedFile.ContentLength == 0) && (viejoNombrePrevisualizacionPelicula.Value != editarNombrePrevisualizacionPelicula.Value) && File.Exists(rutaArchivoViejoPrev))
            {
                //Editar solo ruta archivo previsualizacion musica
                if (!File.Exists(rutaArchivoNuevoPrev))
                {
                    File.Move(rutaArchivoViejoPrev, rutaArchivoNuevoPrev);
                }
                else
                {
                    exitoArchivoPrev = false;
                    errorMensaje = "El archivo de previsualizacion ya existe. Por favor, ingresar otro nombre de archivo.";

                    if (File.Exists(rutaArchivoNuevo))
                    {
                        File.Delete(rutaArchivoNuevo);
                    }
                }
            }
            else if ((editarArchivoPeliculaPrev.PostedFile.ContentLength > 0) && (viejoNombrePrevisualizacionPelicula.Value != editarNombrePrevisualizacionPelicula.Value) && File.Exists(rutaArchivoViejoPrev))
            {
                //Editar archivo de musica previsualizacion y ruta
                if (!File.Exists(rutaArchivoNuevoPrev))
                {
                    File.Delete(rutaArchivoViejoPrev);
                    editarArchivoPeliculaPrev.PostedFile.SaveAs(rutaArchivoNuevoPrev);
                }
                else
                {
                    exitoArchivoPrev = false;
                    errorMensaje = "El archivo de previsualizacion ya existe. Por favor, ingresar otro nombre de archivo.";

                    if (File.Exists(rutaArchivoNuevo))
                    {
                        File.Delete(rutaArchivoNuevo);
                    }
                }
            }
            else if ((editarArchivoPeliculaPrev.PostedFile.ContentLength > 0) && (viejoNombrePrevisualizacionPelicula.Value == editarNombrePrevisualizacionPelicula.Value) && File.Exists(rutaArchivoViejoPrev))
            {
                //Editar archivo de musica previsualizacion
                File.Delete(rutaArchivoViejoPrev);
                editarArchivoPeliculaPrev.PostedFile.SaveAs(rutaArchivoViejoPrev);
            }

            if (exitoArchivo && exitoArchivoPrev)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "exitoCrear", "exitoMensaje('Elemento actualizado con exito')", true);
            }
            else
            {
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "eliminar_ultima", "eliminar_ultima()", true);
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "errorMensaje", "errorMensaje('" + errorMensaje + "')", true);
            }
        }

        protected void eliminarArchivoPelicula_Click(object sender, EventArgs e)
        {
            Parametros parametros = new Parametros();

            try
            {
                string rutaPrincipal = parametros.traerParametros().First().rutaAlmacenamientoPeliculas;
                string rutaPrincipalPrev = parametros.traerParametros().First().rutaAlmacenamientoPrevisualizacionPeliculas;

                if ((viejoNombreDescargaPelicula.Value != "") && (viejoNombrePrevisualizacionPelicula.Value != ""))
                {
                    string rutaArchivo = rutaPrincipal + "\\" + viejoNombreDescargaPelicula.Value;
                    string rutaArchivoPrev = rutaPrincipalPrev + "\\" + viejoNombrePrevisualizacionPelicula.Value;
                    if (File.Exists(rutaArchivo)) { File.Delete(rutaArchivo); }
                    if (File.Exists(rutaArchivoPrev)) { File.Delete(rutaArchivoPrev); }
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "exitoMensaje", "exitoMensaje('El elemento ha sido eliminado con exito.')", true);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "errorMensaje", "errorMensaje('Error: " + ex.Message + "')", true);
            }
        }
    }
}