﻿using BLL.Logica;
using BLL.Objeto;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Web_Application.ApiControllers
{
    public class MusicaController : ApiController
    {
        // GET: api/Musica
        public IEnumerable<Musica> Get()
        {
            Musica musica = new Musica();
            List<Musica> lista_musica = musica.traerMusicas();
            return lista_musica;
        }

        // GET: api/Musica/5
        public string Get(int id)
        {
            return "value";
        }

        // GET: api/Musica/?archivoPrevisualizacion=nombre_archivo
        public HttpResponseMessage Get(string archivoPrevisualizacion)
        {
            Parametros parametros = new Parametros();
            List<Parametros> lista_parametros = parametros.traerParametros();
            string path = lista_parametros.First().rutaAlmacenamientoPrevisualizacionMusica + "\\" + archivoPrevisualizacion;

            if (File.Exists(path))
            {
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                var stream = new FileStream(path, FileMode.Open);
                result.Content = new StreamContent(stream);
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("audio/mp3");
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                result.Content.Headers.ContentDisposition.FileName = archivoPrevisualizacion;
                return result;
            }
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        // POST: api/Musica
        public string Post([FromBody]Musica musica)
        {
            #region Plantilla Postman -> Abrir para ver.
            /*
             {
                "nombre":"NombreDePelicula",
                "genero": "generoDePelicula",
                "tipoInterpretacion":"anioDeLaPelicula",
                "idioma":"idiomaDeLaPelicula",
                "pais":"actoresDeLaPelicula",
                "disquera":"actoresDeLaPelicula",
                "nombreDisco":"actoresDeLaPelicula",
                "anio":"actoresDeLaPelicula",
                "nombreArchivoDescarga":"registroEnDetallePlaceholder",
                "nombreArchivoPrevisualizacion":"registroEnDetallePlaceholder",
                "monto":"registroEnDetallePlaceholder"
            }
            */
            #endregion

            Consecutivo consecutivo = new Consecutivo();

            // Registro espejo del registro requerido guardado en la base de datos.
            Consecutivo registro_de_consecutivo =
                consecutivo.traerConsecutivo_registroReflejadoEnDB("musica");

            // Se actualiza el id del libro como prefijo+numConsecuvito.
            // Ejemplo: lib4 .
            musica.id =
                registro_de_consecutivo.prefijo + (int.Parse(registro_de_consecutivo.descripcion) + 1);

            // Aumentamos el valor "descripcion" del consecutivo en 1.
            string valorDescripcionAumentadoEn1 =
                Tareas.aumentarColumnaDeConsecutivoEn1(registro_de_consecutivo);
            registro_de_consecutivo.descripcion = valorDescripcionAumentadoEn1;

            // Guardamos el nuevo registro en la base de datos.
            musica.guardarMusica(musica);

            // Actualizamos el consecutivo en la base de datos.
            consecutivo.actualizarConsecutivo_baseDeDatos(registro_de_consecutivo);

            // Agregar registro en bitacora
            Bitacora bitacora = new Bitacora();
            string registroEnDetalle = "Id=" + musica.id + " | " + "Nombre=" + musica.nombre + " | " +
                "Genero=" + musica.genero + " | " + "tipoInterpretacion=" + musica.tipoInterpretacion + " | " +
                "idioma=" + musica.idioma + " | " + "pais=" + musica.pais + " | " +
                "disquera=" + musica.disquera + " | " + "nombreDisco=" + musica.nombreDisco + " | " +
                "anio=" + musica.anio + " | " + "nombreArchivoDescarga=" + musica.nombreArchivoDescarga + " | " + 
                "nombreArchivoPrevisualizacion=" + musica.nombreArchivoPrevisualizacion + " | " + "monto=" + musica.monto + " | ";
            bitacora.guardarBitacora_interfazDeUsuario("Agregar", "Insercion de nueva Musica", registroEnDetalle);

            return "Musica " + musica.id + " " + musica.nombre + " guardada.";
        }

        // PUT: api/Musica/5
        public string Put([FromBody]Musica musica)
        {
            #region Plantilla Postman -> Abrir para ver.
            /*
            {
                "ID":"mus1",
               "nombre":"NombreDePelicula",
                "genero": "generoDePelicula",
                "tipoInterpretacion":"anioDeLaPelicula",
                "idioma":"idiomaDeLaPelicula",
                "pais":"actoresDeLaPelicula",
                "disquera":"actoresDeLaPelicula",
                "nombreDisco":"actoresDeLaPelicula",
                "anio":"actoresDeLaPelicula",
                "nombreArchivoDescarga":"registroEnDetallePlaceholder",
                "nombreArchivoPrevisualizacion":"registroEnDetallePlaceholder",
                "monto":"registroEnDetallePlaceholder"
            }
            */
            #endregion

            musica.actualizarMusica(musica);

            // Agregar registro en bitacora
            Bitacora bitacora = new Bitacora();
            string registroEnDetalle = "Id=" + musica.id + " | " + "Nombre=" + musica.nombre + " | " +
                "Genero=" + musica.genero + " | " + "tipoInterpretacion=" + musica.tipoInterpretacion + " | " +
                "idioma=" + musica.idioma + " | " + "pais=" + musica.pais + " | " +
                "disquera=" + musica.disquera + " | " + "nombreDisco=" + musica.nombreDisco + " | " +
                "anio=" + musica.anio + " | " + "nombreArchivoDescarga=" + musica.nombreArchivoDescarga + " | " +
                "nombreArchivoPrevisualizacion=" + musica.nombreArchivoPrevisualizacion + " | " + "monto=" + musica.monto + " | ";
            bitacora.guardarBitacora_interfazDeUsuario("Modificar", "Modificacion de Musica", registroEnDetalle);

            return "Musica " + musica.id + " " + musica.nombre + " actualizada.";
        }

        // DELETE: api/Musica/5
        public string Delete(string id)
        {
            Musica musica = new Musica();
            musica.eliminarMusica(id);

            // Disminuimos el valor "descripcion" del consecutivo en 1.
            Consecutivo consecutivo = new Consecutivo();
            Consecutivo registro_de_consecutivo = consecutivo.traerConsecutivo_registroReflejadoEnDB("musica");
            string valorDescripcionDisminuidoEn1 = Tareas.disminuirColumnaDeConsecutivoEn1(registro_de_consecutivo);
            registro_de_consecutivo.descripcion = valorDescripcionDisminuidoEn1;
            consecutivo.actualizarConsecutivo_baseDeDatos(registro_de_consecutivo);

            // Agregar registro en bitacora
            Bitacora bitacora = new Bitacora();
            bitacora.guardarBitacora_interfazDeUsuario("Eliminar", "Eliminacion de Musica", "");

            return "Musica " + id + " eliminada.";
        }
    }
}
