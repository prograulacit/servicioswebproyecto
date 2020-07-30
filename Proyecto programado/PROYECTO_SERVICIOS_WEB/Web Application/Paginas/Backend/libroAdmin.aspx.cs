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
        }

        protected void subirArchivosLibro_Click(object sender, EventArgs e)
        {
            Parametros parametros = new Parametros();
            string rutaPrincipal = parametros.traerParametros().First().rutaAlmacenamientoLibros;
            string rutaArchivo = rutaPrincipal + "\\" + nombreArchivoLibro.Value.ToString();
            bool exitoArchivo = false;
            bool exitoArchivoPrev = false;

            if (!File.Exists(rutaArchivo))
            {
                archivoLibro.PostedFile.SaveAs(rutaArchivo);
                exitoArchivo = true;
            }

            //Subida archivo libro previsualizacion
            string rutaPrincipalPrev = parametros.traerParametros().First().rutaAlmacenamientoPrevisualizacionLibros;
            string rutaArchivoPrev = rutaPrincipalPrev + "\\" + nombrePrevisualizacionLibro.Value.ToString();
            if (exitoArchivo && !File.Exists(rutaArchivoPrev))
            {
                archivoLibroPrev.PostedFile.SaveAs(rutaArchivoPrev);
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


        protected void editarArchivosLibro_Click(object sender, EventArgs e)
        {
            Parametros parametros = new Parametros();
            string rutaPrincipal = parametros.traerParametros().First().rutaAlmacenamientoLibros;
            string rutaPrincipalPrev = parametros.traerParametros().First().rutaAlmacenamientoPrevisualizacionLibros;
            string rutaArchivoViejo = rutaPrincipal + "\\" + viejoNombreDescargaLibro.Value;
            string rutaArchivoNuevo = rutaPrincipal + "\\" + editarNombreDescargaLibro.Value;
            string rutaArchivoViejoPrev = rutaPrincipalPrev + "\\" + viejoNombrePrevisualizacionLibro.Value;
            string rutaArchivoNuevoPrev = rutaPrincipalPrev + "\\" + editarNombrePrevisualizacionLibro.Value;
            string errorMensaje = "";
            bool exitoArchivo = true;
            bool exitoArchivoPrev = true;

            if ((editarArchivoLibro.PostedFile.ContentLength == 0) && (viejoNombreDescargaLibro.Value != editarNombreDescargaLibro.Value) && File.Exists(rutaArchivoViejo))
            {
                //Editar solo ruta archivo libro
                if (!File.Exists(rutaArchivoNuevo))
                {
                    File.Move(rutaArchivoViejo, rutaArchivoNuevo);
                }
                else
                {
                    exitoArchivo = false;
                    errorMensaje = "El archivo de libro ya existe. Por favor, ingresar otro nombre de archivo.";
                }
            }
            else if ((editarArchivoLibro.PostedFile.ContentLength > 0) && (viejoNombreDescargaLibro.Value != editarNombreDescargaLibro.Value) && File.Exists(rutaArchivoViejo))
            {
                //Editar archivo de libro y ruta
                if (!File.Exists(rutaArchivoNuevo))
                {
                    File.Delete(rutaArchivoViejo);
                    editarArchivoLibro.PostedFile.SaveAs(rutaArchivoNuevo);
                }
                else
                {
                    exitoArchivo = false;
                    errorMensaje = "El archivo de libro ya existe. Por favor, ingresar otro nombre de archivo.";
                }
            }
            else if ((editarArchivoLibro.PostedFile.ContentLength > 0) && (viejoNombreDescargaLibro.Value == editarNombreDescargaLibro.Value) && File.Exists(rutaArchivoViejo))
            {
                //Editar archivo de libro
                File.Delete(rutaArchivoViejo);
                editarArchivoLibro.PostedFile.SaveAs(rutaArchivoViejo);
            }

            if ((editarArchivoLibroPrev.PostedFile.ContentLength == 0) && (viejoNombrePrevisualizacionLibro.Value != editarNombrePrevisualizacionLibro.Value) && File.Exists(rutaArchivoViejoPrev))
            {
                //Editar solo ruta archivo previsualizacion libro
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
            else if ((editarArchivoLibroPrev.PostedFile.ContentLength > 0) && (viejoNombrePrevisualizacionLibro.Value != editarNombrePrevisualizacionLibro.Value) && File.Exists(rutaArchivoViejoPrev))
            {
                //Editar archivo de libro previsualizacion y ruta
                if (!File.Exists(rutaArchivoNuevoPrev))
                {
                    File.Delete(rutaArchivoViejoPrev);
                    editarArchivoLibroPrev.PostedFile.SaveAs(rutaArchivoNuevoPrev);
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
            else if ((editarArchivoLibroPrev.PostedFile.ContentLength > 0) && (viejoNombrePrevisualizacionLibro.Value == editarNombrePrevisualizacionLibro.Value) && File.Exists(rutaArchivoViejoPrev))
            {
                //Editar archivo de libro previsualizacion
                File.Delete(rutaArchivoViejoPrev);
                editarArchivoLibroPrev.PostedFile.SaveAs(rutaArchivoViejoPrev);
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

        protected void eliminarArchivoLibro_Click(object sender, EventArgs e)
        {
            Parametros parametros = new Parametros();

            try
            {
                string rutaPrincipal = parametros.traerParametros().First().rutaAlmacenamientoLibros;
                string rutaPrincipalPrev = parametros.traerParametros().First().rutaAlmacenamientoPrevisualizacionLibros;

                if ((viejoNombreDescargaLibro.Value != "") && (viejoNombrePrevisualizacionLibro.Value != ""))
                {
                    string rutaArchivo = rutaPrincipal + "\\" + viejoNombreDescargaLibro.Value;
                    string rutaArchivoPrev = rutaPrincipalPrev + "\\" + viejoNombrePrevisualizacionLibro.Value;
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