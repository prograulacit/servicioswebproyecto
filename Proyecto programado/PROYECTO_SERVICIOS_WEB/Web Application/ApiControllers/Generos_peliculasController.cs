using System.Collections.Generic;
using System.Web.Http;
using BLL.Logica;
using BLL.Objeto;

namespace Web_Application.ApiControllers
{
    public class Generos_peliculasController : ApiController
    {
        // GET: api/Generos_peliculas
        public IEnumerable<Generos_peliculas> Get()
        {
            Generos_peliculas generos_peliculas = new Generos_peliculas();
            List<Generos_peliculas> generos_peliculas_lista = generos_peliculas.traer_generosPelicula();
            return generos_peliculas_lista;
        }

        // GET: api/Generos_peliculas/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Generos_peliculas
        public string Post([FromBody]Generos_peliculas generos_peliculas)
        {
            #region Plantilla Postman -> Abrir para ver.
            //{
            //    "genero": "codigoDelRegistroPlaceholder"
            //}
            #endregion
            string nuevo_id = Tareas.generar_nuevo_id_para_un_registro();

            generos_peliculas.id = nuevo_id;

            generos_peliculas.guardar_generosPelicula(generos_peliculas);
            return "Genero de pelicula " + nuevo_id + " guardada.";
        }

        // PUT: api/Generos_peliculas/5
        public string Put([FromBody]Generos_peliculas generos_peliculas)
        {
            #region Plantilla Postman -> Abrir para ver.
            //{
            //    "ID":"IDadminResponsable",
            //    "genero":"IDadminResponsable"
            //}
            #endregion

            generos_peliculas.actualizar_generosPelicula(generos_peliculas);
            return "Genero de pelicula " + generos_peliculas.id + " actualizado.";
        }

        // DELETE: api/Generos_peliculas/5
        public string Delete(string id)
        {
            Generos_peliculas generos_peliculas = new Generos_peliculas();
            generos_peliculas.eliminar_generosPelicula(id);
            return "Genero de pelicula " + id + " eliminada.";
        }
    }
}
