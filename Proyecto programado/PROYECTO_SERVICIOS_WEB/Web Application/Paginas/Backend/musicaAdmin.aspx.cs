﻿using BLL.Logica;
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
        }

        protected void subirArchivosMusica_Click(object sender, EventArgs e)
        {
            Parametros parametros = new Parametros();
            string rutaPrincipal = parametros.traerParametros().First().rutaAlmacenamientoMusica;
            string rutaArchivo = rutaPrincipal + "\\" + nombreArchivoMusica.Value.ToString();
            bool exitoArchivo = false;
            bool exitoArchivoPrev = false;

            if (!File.Exists(rutaArchivo))
            {
                archivoMusica.PostedFile.SaveAs(rutaArchivo);
                exitoArchivo = true;
            }

            //Subida archivo musica previsualizacion
            string rutaPrincipalPrev = parametros.traerParametros().First().rutaAlmacenamientoPrevisualizacionMusica;
            string rutaArchivoPrev = rutaPrincipalPrev + "\\" + nombrePrevisualizacionMusica.Value.ToString();
            if (exitoArchivo && !File.Exists(rutaArchivoPrev))
            {
                archivoMusicaPrev.PostedFile.SaveAs(rutaArchivoPrev);
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


        protected void editarArchivosMusica_Click(object sender, EventArgs e)
        {
            Parametros parametros = new Parametros();
            string rutaPrincipal = parametros.traerParametros().First().rutaAlmacenamientoMusica;
            string rutaPrincipalPrev = parametros.traerParametros().First().rutaAlmacenamientoPrevisualizacionMusica;
            string rutaArchivoViejo = rutaPrincipal + "\\" + viejoNombreDescargaMusica.Value;
            string rutaArchivoNuevo = rutaPrincipal + "\\" + editarNombreDescargaMusica.Value;
            string rutaArchivoViejoPrev = rutaPrincipalPrev + "\\" + viejoNombrePrevisualizacionMusica.Value;
            string rutaArchivoNuevoPrev = rutaPrincipalPrev + "\\" + editarNombrePrevisualizacionMusica.Value;
            string errorMensaje = "";
            bool exitoArchivo = true;
            bool exitoArchivoPrev = true;

            if ((editarArchivoMusica.PostedFile.ContentLength == 0) && (viejoNombreDescargaMusica.Value != editarNombreDescargaMusica.Value) && File.Exists(rutaArchivoViejo))
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
            else if ((editarArchivoMusica.PostedFile.ContentLength > 0) && (viejoNombreDescargaMusica.Value != editarNombreDescargaMusica.Value) && File.Exists(rutaArchivoViejo))
            {
                //Editar archivo de musica y ruta
                if (!File.Exists(rutaArchivoNuevo))
                {
                    File.Delete(rutaArchivoViejo);
                    editarArchivoMusica.PostedFile.SaveAs(rutaArchivoNuevo);
                }
                else
                {
                    exitoArchivo = false;
                    errorMensaje = "El archivo de musica ya existe. Por favor, ingresar otro nombre de archivo.";
                }
            }
            else if ((editarArchivoMusica.PostedFile.ContentLength > 0) && (viejoNombreDescargaMusica.Value == editarNombreDescargaMusica.Value) && File.Exists(rutaArchivoViejo))
            {
                //Editar archivo de musica
                File.Delete(rutaArchivoViejo);
                editarArchivoMusica.PostedFile.SaveAs(rutaArchivoViejo);
            }

            if ((editarArchivoMusicaPrev.PostedFile.ContentLength == 0) && (viejoNombrePrevisualizacionMusica.Value != editarNombrePrevisualizacionMusica.Value) && File.Exists(rutaArchivoViejoPrev))
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
            else if ((editarArchivoMusicaPrev.PostedFile.ContentLength > 0) && (viejoNombrePrevisualizacionMusica.Value != editarNombrePrevisualizacionMusica.Value) && File.Exists(rutaArchivoViejoPrev))
            {
                //Editar archivo de musica previsualizacion y ruta
                if (!File.Exists(rutaArchivoNuevoPrev))
                {
                    File.Delete(rutaArchivoViejoPrev);
                    editarArchivoMusicaPrev.PostedFile.SaveAs(rutaArchivoNuevoPrev);
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
            else if ((editarArchivoMusicaPrev.PostedFile.ContentLength > 0) && (viejoNombrePrevisualizacionMusica.Value == editarNombrePrevisualizacionMusica.Value) && File.Exists(rutaArchivoViejoPrev))
            {
                //Editar archivo de musica previsualizacion
                File.Delete(rutaArchivoViejoPrev);
                editarArchivoMusicaPrev.PostedFile.SaveAs(rutaArchivoViejoPrev);
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

        protected void eliminarArchivoMusica_Click(object sender, EventArgs e)
        {
            Parametros parametros = new Parametros();

            try
            {
                string rutaPrincipal = parametros.traerParametros().First().rutaAlmacenamientoMusica;
                string rutaPrincipalPrev = parametros.traerParametros().First().rutaAlmacenamientoPrevisualizacionMusica;

                if ((viejoNombreDescargaMusica.Value != "") && (viejoNombrePrevisualizacionMusica.Value != ""))
                {
                    string rutaArchivo = rutaPrincipal + "\\" + viejoNombreDescargaMusica.Value;
                    string rutaArchivoPrev = rutaPrincipalPrev + "\\" + viejoNombrePrevisualizacionMusica.Value;
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