using System.Collections.Generic;
using System.Web.Http;
using BLL.Logica;
using BLL.Objeto;

namespace Web_Application.ApiControllers
{
    public class PeliculaController : ApiController
    {
        // GET: api/Pelicula
        public IEnumerable<Pelicula> Get()
        {
            Pelicula pelicula = new Pelicula();
            List<Pelicula> lista_peliculas = pelicula.traerPeliculas();
            return lista_peliculas;
        }

        // GET: api/Pelicula/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Pelicula
        public string Post([FromBody]Pelicula pelicula)
        {
            #region Plantilla Postman -> Abrir para ver.
            //{
            //    "nombre":"IDadminResponsable",
            //    "genero": "codigoDelRegistroPlaceholder",
            //    "anio":"tipoBitacoraPlaceholder",
            //    "idioma":"descripcionPlaceholder",
            //    "actores":"registroEnDetallePlaceholder",
            //    "nombreArchivoDescarga":"registroEnDetallePlaceholder",
            //    "nombreArchivoPrevisualizacion":"registroEnDetallePlaceholder",
            //    "monto":"registroEnDetallePlaceholder"
            //}
            #endregion
            string nuevo_id = Tareas.generar_nuevo_id_para_un_registro();

            pelicula.id = nuevo_id;

            pelicula.guardarPelicula(pelicula);
            return "Pelicula " + nuevo_id + " guardada.";
        }

        // PUT: api/Pelicula/5
        public string Put([FromBody]Pelicula pelicula)
        {
            #region Plantilla Postman -> Abrir para ver.
            //{
            //    "ID":"IDadminResponsable",
            //    "nombre":"IDadminResponsable",
            //    "genero": "codigoDelRegistroPlaceholder",
            //    "anio":"tipoBitacoraPlaceholder",
            //    "idioma":"descripcionPlaceholder",
            //    "actores":"registroEnDetallePlaceholder",
            //    "nombreArchivoDescarga":"registroEnDetallePlaceholder",
            //    "nombreArchivoPrevisualizacion":"registroEnDetallePlaceholder",
            //    "monto":"registroEnDetallePlaceholder"
            //}
            #endregion

            pelicula.actualizarPelicula(pelicula);
            return "Pelicula " + pelicula.id + " actualizada.";
        }

        // DELETE: api/Pelicula/5
        public string Delete(string id)
        {
            Pelicula pelicula = new Pelicula();
            pelicula.eliminarPelicula(id);
            return "Pelicula " + id + " eliminada.";
        }
    }
}
