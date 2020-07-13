using System.Collections.Generic;
using System.Web.Http;
using BLL.Logica;
using BLL.Objeto;

namespace Web_Application.ApiControllers
{
    public class Generos_musicaController : ApiController
    {
        // GET: api/Generos_musica
        public IEnumerable<Generos_musica> Get()
        {
            Generos_musica generos_musica = new Generos_musica();
            List<Generos_musica> generos_musica_lista = generos_musica.traer_generosMusica();
            return generos_musica_lista;
        }

        // GET: api/Generos_musica/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Generos_musica
        public string Post([FromBody]Generos_musica generos_musica)
        {
            #region Plantilla Postman -> Abrir para ver.
            //{
            //    "genero": "codigoDelRegistroPlaceholder"
            //}
            #endregion
            string nuevo_id = Tareas.generar_nuevo_id_para_un_registro();

            generos_musica.id = nuevo_id;

            generos_musica.guardar_generosMusica(generos_musica);
            return "Genero de musica " + nuevo_id + " guardada.";
        }

        // PUT: api/Generos_musica/5
        public string Put([FromBody]Generos_musica generos_musica)
        {
            #region Plantilla Postman -> Abrir para ver.
            //{
            //    "ID":"IDadminResponsable",
            //    "genero":"IDadminResponsable"
            //}
            #endregion

            generos_musica.actualizar_generosMusica(generos_musica);
            return "Genero de musica " + generos_musica.id + " actualizado.";
        }

        // DELETE: api/Generos_musica/5
        public string Delete(string id)
        {
            Generos_musica generos_musica = new Generos_musica();
            generos_musica.eliminar_generosMusica(id);
            return "Genero de musica " + id + " eliminada.";
        }
    }
}
