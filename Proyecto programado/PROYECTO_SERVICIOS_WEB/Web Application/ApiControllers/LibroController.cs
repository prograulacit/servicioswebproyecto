using System.Collections.Generic;
using System.Web.Http;
using BLL.Logica;
using BLL.Objeto;

namespace Web_Application.ApiControllers
{
    public class LibroController : ApiController
    {
        // GET: api/Libro
        public IEnumerable<Libro> Get()
        {
            Libro libro = new Libro();
            List<Libro> lista_libros = libro.traerLibros();
            return lista_libros;
        }

        // GET: api/Libro/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Libro
        public string Post([FromBody]Libro libro)
        {
            #region Plantilla Postman -> Abrir para ver.
            /*
             {
                "nombre":"NombreDePelicula",
                "categoria": "generoDePelicula",
                "autor":"anioDeLaPelicula",
                "idioma":"idiomaDeLaPelicula",
                "editorial":"actoresDeLaPelicula",
                "anioPublicacion":"actoresDeLaPelicula",
                "nombreArchivoDescarga":"registroEnDetallePlaceholder",
                "nombreArchivoPrevisualizacion":"registroEnDetallePlaceholder",
                "monto":"registroEnDetallePlaceholder"
            }
            */
            #endregion

            Consecutivo consecutivo = new Consecutivo();

            // Registro espejo del registro requerido guardado en la base de datos.
            Consecutivo registro_de_consecutivo =
                consecutivo.traerConsecutivo_registroReflejadoEnDB("libro");

            // Se actualiza el id del libro como prefijo+numConsecuvito.
            // Ejemplo: lib4 .
            libro.id =
                registro_de_consecutivo.prefijo + registro_de_consecutivo.descripcion;

            // Aumentamos el valor "descripcion" del consecutivo en 1.
            string valorDescripcionAumentadoEn1 =
                Tareas.aumentarColumnaDeConsecutivoEn1(registro_de_consecutivo);
            registro_de_consecutivo.descripcion = valorDescripcionAumentadoEn1;

            // Guardamos el nuevo registro en la base de datos.
            libro.guardarLibro(libro);

            // Actualizamos el consecutivo en la base de datos.
            consecutivo.actualizarConsecutivo_baseDeDatos(registro_de_consecutivo);

            return "Libro " + libro.id + " " + libro.nombre + " guardado.";
        }

        // PUT: api/Libro/5
        public string Put([FromBody]Libro libro)
        {
            #region Plantilla Postman -> Abrir para ver.
            /*
            {
                "ID":"IdDelLibro",
                "nombre":"NombreDePelicula",
                "categoria": "generoDePelicula",
                "autor":"anioDeLaPelicula",
                "idioma":"idiomaDeLaPelicula",
                "editorial":"actoresDeLaPelicula",
                "anioPublicacion":"actoresDeLaPelicula",
                "nombreArchivoDescarga":"registroEnDetallePlaceholder",
                "nombreArchivoPrevisualizacion":"registroEnDetallePlaceholder",
                "monto":"registroEnDetallePlaceholder"
            }
            */
            #endregion

            libro.actualizarLibro(libro);
            return "Libro " + libro.id + " " + libro.nombre + " actualizada.";
        }

        // DELETE: api/Libro/5
        public string Delete(string id)
        {
            Libro libro = new Libro();
            libro.eliminarLibro(id);
            return "Libro " + id + " eliminado.";
        }
    }
}
