using System.Collections.Generic;
using System.Web.Http;
using BLL.Logica;
using BLL.Objeto;

namespace Web_Application.ApiControllers
{
    public class TransaccionController : ApiController
    {
        // GET: api/Transaccion
        public IEnumerable<Transaccion> Get()
        {
            Transaccion transaccion = new Transaccion();
            List<Transaccion> lista_transacciones = transaccion.traerTransacciones();
            return lista_transacciones;
        }

        // POST: api/Transaccion
        public string Post([FromBody]Transaccion transaccion)
        {
            #region Plantilla Postman -> Abrir para ver.
            /*{
                "monto": "monto",
                "usuarioID":"usuarioID",
                "consecutivoProductoID":"consecutivoProductoID",
                "tarjetaID":"tarjetaID",
                "easyPayID":"easyPayID"
            }*/
            #endregion

            Consecutivo consecutivo = new Consecutivo();

            // Registro espejo del registro requerido guardado en la base de datos.
            Consecutivo registro_de_consecutivo =
                consecutivo.traerConsecutivo_registroReflejadoEnDB("transaccion");

            // Se actualiza el id de la transaccion como prefijo+numConsecuvito.
            // Ejemplo: tra4 .
            transaccion.id =
                registro_de_consecutivo.prefijo + (int.Parse(registro_de_consecutivo.descripcion) + 1);

            // Aumentamos el valor "descripcion" del consecutivo en 1.
            string valorDescripcionAumentadoEn1 =
                Tareas.aumentarColumnaDeConsecutivoEn1(registro_de_consecutivo);
            registro_de_consecutivo.descripcion = valorDescripcionAumentadoEn1;

            // Le asignamos la fecha de transaccion al elemento.
            transaccion.fechaCompra = Tareas.obtener_fecha_actual();

            // Guardamos el registro de transaccion.
            transaccion.crearRegistroTranseccion(transaccion);

            // Actualizamos el consecutivo en la base de datos.
            consecutivo.actualizarConsecutivo_baseDeDatos(registro_de_consecutivo);

            return "Transaccion " + transaccion.id + " agregada.";
        }

        // PUT: api/Transaccion/5
        public string Put([FromBody]Transaccion transaccion)
        {
            #region Plantilla Postman -> Abrir para ver.
            /*{
                "ID":"ID",
                "fechaCompra":"fechaCompra",
                "monto": "editado",
                "usuarioID":"editado",
                "consecutivoProductoID":"editado",
                "tarjetaID":"editado",
                "easyPayID":"editado"
            }*/
            #endregion

            // La fecha de la compra no debería poder ser actualizada por lo que
            // se trae su valor guardado original.
            transaccion.fechaCompra = 
                transaccion.traerFechaCompra_porId(transaccion.id);

            transaccion.actualizarRegistroTransaccion(transaccion);
            return "Transaccion " + transaccion.id + " actualizada.";
        }

        // DELETE: api/Transaccion/5
        public string Delete(string id)
        {
            Transaccion transaccion = new Transaccion();
            transaccion.eliminarTransaccion(id);
            return "Transaccion " + id + " eliminada.";
        }
    }
}
