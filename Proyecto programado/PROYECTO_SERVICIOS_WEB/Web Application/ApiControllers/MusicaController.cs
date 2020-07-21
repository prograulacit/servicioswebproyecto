using System.Collections.Generic;
using System.Web.Http;
using BLL.Logica;
using BLL.Objeto;

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
                registro_de_consecutivo.prefijo + registro_de_consecutivo.descripcion;

            // Aumentamos el valor "descripcion" del consecutivo en 1.
            string valorDescripcionAumentadoEn1 =
                Tareas.aumentarColumnaDeConsecutivoEn1(registro_de_consecutivo);
            registro_de_consecutivo.descripcion = valorDescripcionAumentadoEn1;

            // Guardamos el nuevo registro en la base de datos.
            musica.guardarMusica(musica);

            // Actualizamos el consecutivo en la base de datos.
            consecutivo.actualizarConsecutivo_baseDeDatos(registro_de_consecutivo);

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
            return "Musica " + musica.id + " " + musica.nombre + " actualizada.";
        }

        // DELETE: api/Musica/5
        public string Delete(string id)
        {
            Musica musica = new Musica();
            musica.eliminarMusica(id);
            return "Musica " + id + " eliminada.";
        }
    }
}
