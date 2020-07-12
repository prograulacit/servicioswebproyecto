using System.Collections.Generic;
using System.Web.Http;
using BLL.Logica;
using BLL.Objeto;

namespace Web_Application.ApiControllers
{
    public class BitacoraController : ApiController
    {
        // GET: api/Bitacora
        public IEnumerable<Bitacora> Get()
        {
            Bitacora bitacora = new Bitacora();
            List<Bitacora> lista_bitacoras = bitacora.traerBitacoras();
            return lista_bitacoras;
        }

        // GET: api/Bitacora/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Bitacora
        public string Post([FromBody]Bitacora bitacora)
        {
            #region Plantilla Postman -> Abrir para ver.
            //{
            //    "IDadmin":"IDadminResponsable",
            //    "codigoDelRegistro": "codigoDelRegistroPlaceholder",
            //    "tipo":"tipoBitacoraPlaceholder",
            //    "descripcion":"descripcionPlaceholder",
            //    "registroEnDetalle":"registroEnDetallePlaceholder"
            //}
            #endregion
            string nuevo_id = Tareas.generar_nuevo_id_para_un_registro();
            Bitacora bitacora_temp = new Bitacora(
                nuevo_id
                , bitacora.IDadmin
                , Tareas.obtener_fecha_actual() //Fecha
                , bitacora.codigoDelRegistro
                , bitacora.tipo
                , bitacora.descripcion
                , bitacora.registroEnDetalle
                );

            bitacora_temp.guardarBitacora(bitacora_temp);
            return "Bitacora " + nuevo_id + " agregada.";
        }

        // PUT: api/Bitacora/5
        public string Put([FromBody]Bitacora bitacora)
        {
            #region Plantilla Postman -> Abrir para ver.
            //{
            //    "ID":"IDBitacoraPlaceholder",
            //    "IDadmin":"editado",
            //    "codigoDelRegistro": "editado",
            //    "tipo":"editado",
            //    "descripcion":"editado",
            //    "registroEnDetalle":"editado"
            //}
            #endregion
            Bitacora bitacora_temp = new Bitacora(
                bitacora.id
                , bitacora.IDadmin
                , Tareas.obtener_fecha_actual()
                , bitacora.codigoDelRegistro
                , bitacora.tipo
                , bitacora.descripcion
                , bitacora.registroEnDetalle
                );

            bitacora_temp.actualizarBitacora(bitacora_temp);
            return "Bitacora " + bitacora.id + " actualizada.";
        }

        // DELETE: api/Bitacora/5
        public string Delete(string id)
        {
            Bitacora bitacora = new Bitacora();
            bitacora.eliminarBitacora(id);
            return "Bitacora " + id + " eliminado.";
        }
    }
}
