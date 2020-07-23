using System.Collections.Generic;
using System.Web.Http;
using BLL.Logica;
using BLL.Objeto;

namespace Web_Application.ApiControllers
{
    public class ErrorController : ApiController
    {
        // GET: api/Error
        public IEnumerable<Error> Get()
        {
            Error error = new Error();
            List<Error> lista_errores = error.traerErrores();
            return lista_errores;
        }

        // GET: api/Error/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Error
        public string Post([FromBody]Error error)
        {
            #region Plantilla Postman -> Abrir para ver.
            /*{
                "IDUsuario":"idUsuarioPlaceholder",
                "mensajeDeError": "Mensaje de error placeholder"
            }*/
            #endregion
            string nuevo_id = Tareas.generar_nuevo_id_para_un_registro();
            Error error_temp = new Error(
                nuevo_id
                , Tareas.obtener_fecha_actual()
                , error.IDUsuario
                , error.mensajeDeError
                );

            error_temp.guardarError(error_temp);
            return "Error " + nuevo_id + " agregado.";
        }

        // PUT: api/Error/5
        public string Put([FromBody]Error error)
        {
            #region Plantilla Postman -> Abrir para ver.
            //{
            //    "ID":"id del registor de error",
            //    "IDUsuario":"idUsuarioPlaceholder update",
            //    "mensajeDeError": "Mensaje de error placeholder update"
            //}
            #endregion
            Error error_temp = new Error(
                error.id
                , Tareas.obtener_fecha_actual()
                , error.IDUsuario
                , error.mensajeDeError
                );

            error_temp.actualizarError(error_temp);
            return "Error " + error.id + " actualizado.";
        }

        // DELETE: api/Error/5
        public string Delete(string id)
        {
            Error error = new Error();
            error.eliminarError(id);
            return "Error " + id + " eliminado.";
        }
    }
}
