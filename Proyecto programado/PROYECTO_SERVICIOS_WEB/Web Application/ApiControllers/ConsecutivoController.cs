using System.Collections.Generic;
using System.Web.Http;
using BLL.Logica;
using BLL.Objeto;

namespace Web_Application.ApiControllers
{
    public class ConsecutivoController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Consecutivo> Get()
        {
            Consecutivo consecutivo = new Consecutivo();
            List<Consecutivo> lista_consecutivos = consecutivo.traerConsecutivos();
            return lista_consecutivos;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public string Post([FromBody]Consecutivo consecutivo)
        {
            #region Plantilla Postman -> Abrir para ver.
            //{
            //    "tipoConsecutivo":"placeholderType",
            //    "descripcion": "1",
            //    "prefijo":"placeholderPrefix",
            //    "rangoInicial":"0",
            //    "rangoFinal":"200"
            //}
            #endregion
            string nuevo_id = Tareas.generar_nuevo_id_para_un_registro();
            Consecutivo consecutivo_temp = new Consecutivo(
                nuevo_id
                , consecutivo.tipoConsecutivo
                , consecutivo.descripcion
                , consecutivo.prefijo
                , consecutivo.rangoInicial
                , consecutivo.rangoFinal
                );

            consecutivo_temp.guardarConsecutivo_baseDeDatos(consecutivo_temp);
            return "Consecutivo " + nuevo_id + " agregado.";
        }

        // PUT api/<controller>/5
        public string Put([FromBody]Consecutivo consecutivo)
        {
            #region Plantilla Postman -> Abrir para ver.
            //{
            //    "ID":"idplaceholder",
            //    "tipoConsecutivo":"editado",
            //    "descripcion": "1",
            //    "prefijo":"editado",
            //    "rangoInicial":"0",
            //    "rangoFinal":"200"
            //}
            #endregion
            Consecutivo consecutivo_temp = new Consecutivo(
                consecutivo.id
                , consecutivo.tipoConsecutivo
                , consecutivo.descripcion
                , consecutivo.prefijo
                , consecutivo.rangoInicial
                , consecutivo.rangoFinal
                );

            consecutivo_temp.actualizarConsecutivo_baseDeDatos(consecutivo_temp);
            return "Consecutivo " + consecutivo.id + " actualizado.";
        }

        // DELETE api/<controller>/5
        public string Delete(string id)
        {
            Consecutivo consecutivo = new Consecutivo();
            consecutivo.eliminarConsecutivo_baseDeDatos(id);
            return "Consecutivo " + id + " eliminado.";
        }
    }
}