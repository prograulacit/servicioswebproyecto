using System.Collections.Generic;
using System.Web.Http;
using BLL.Logica;
using BLL.Objeto;


namespace Web_Application.ApiControllers
{
    public class ParametrosController : ApiController
    {
        // GET: api/Parametros
        public IEnumerable<Parametros> Get()
        {
            Parametros parametros = new Parametros();
            List<Parametros> lista_parametros = parametros.traerParametros();
            return lista_parametros;
        }

        // GET: api/Parametros/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Parametros
        public string Post([FromBody]Parametros parametros)
        {
            #region Plantilla Postman -> Abrir para ver.
            //{
            //    "rutaAlmacenamientoPrevisualizacionLibros":"PreLibros",
            //    "rutaAlmacenamientoLibros": "AlLibros",
            //    "rutaAlmacenamientoPrevisualizacionPeliculas":"PrePeliculas",
            //    "rutaAlmacenamientoPeliculas": "AlPeliculas",
            //    "rutaAlmacenamientoPrevisualizacionMusica":"PreMusica",
            //    "rutaAlmacenamientoMusica": "AlMusica"
            //}
            #endregion

            Parametros parametros_temporal = new Parametros();
            List<Parametros> lista_parametros_temporal =
                parametros_temporal.traerParametros();

            // Solo puede existir un registro de parametros en la base de datos.
            // Si lista_parametros_temporal es null, se guardara el registro.
            if (lista_parametros_temporal == null)
            {
                string nuevo_id = "par";
                Parametros parametros_registro = new Parametros(
                     nuevo_id
                     , parametros.rutaAlmacenamientoPrevisualizacionLibros
                     , parametros.rutaAlmacenamientoLibros
                     , parametros.rutaAlmacenamientoPrevisualizacionPeliculas
                     , parametros.rutaAlmacenamientoPeliculas
                     , parametros.rutaAlmacenamientoPrevisualizacionMusica
                     , parametros.rutaAlmacenamientoMusica
                     );
                parametros_temporal.crearRegistroParametros(parametros_registro);
                return "Registro de parametros " + nuevo_id + " agregado.";
            }
            else
            {
                return "Ya hay un registro de parametros existente. Consulta rechazada.";
            }
        }

        // PUT: api/Parametros/5
        public string Put([FromBody]Parametros parametros)
        {
            #region Plantilla Postman -> Abrir para ver.
            /*{
                "ID":"IDDelRegistroUnicoDeParametros",
                "rutaAlmacenamientoPrevisualizacionLibros":"PreLibros",
                "rutaAlmacenamientoLibros": "AlLibros",
                "rutaAlmacenamientoPrevisualizacionPeliculas":"PrePeliculas",
                "rutaAlmacenamientoPeliculas": "AlPeliculas",
                "rutaAlmacenamientoPrevisualizacionMusica":"PreMusica",
                "rutaAlmacenamientoMusica": "AlMusica"
            }*/
            #endregion
            Parametros parametros_temp = new Parametros(
                       parametros.id
                     , parametros.rutaAlmacenamientoPrevisualizacionLibros
                     , parametros.rutaAlmacenamientoLibros
                     , parametros.rutaAlmacenamientoPrevisualizacionPeliculas
                     , parametros.rutaAlmacenamientoPeliculas
                     , parametros.rutaAlmacenamientoPrevisualizacionMusica
                     , parametros.rutaAlmacenamientoMusica
                );

            parametros_temp.actualizarParametros(parametros_temp);
            return "Parametros actualizados. ID: " + parametros.id;
        }

        // DELETE: api/Parametros/5
        public string Delete(string id)
        {
            Parametros parametros = new Parametros();
            parametros.eliminarRegistroParametros(id);
            return "Registro de parametros eliminado. ID: " + id;
        }
    }
}
