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

        // GET: api/Transaccion/id
        /// <summary>
        /// Retorna una transacción por ID. Si el ID escrito es
        /// "asociada" se traen todas las transacciones que pertenezcan
        /// o sean propiedad del usuario logeado en la sesión actual.
        /// </summary>
        /// <param name="ID">ID de una transacción o la palabra
        /// "asociada" sin comillas.</param>
        /// <returns>Objeto Transacción.</returns>
        public IEnumerable<Transaccion> Get(string ID)
        {
            Transaccion transaccion = new Transaccion();

            if (ID.Equals("asociada"))
            {
                // Traemos todas las transacciones que indican propiedad del usuario
                // logeado en memoria.
                List<Transaccion> lista_transaccionesPropiedad =
                    transaccion.traer_listaTransaccionesPropiedadUsuarioLogeado();

                if (lista_transaccionesPropiedad != null)
                {
                    return lista_transaccionesPropiedad;
                }

                // Si envia null significa que el usuario no tiene propiedad de ningun producto.
                return null; 
            }

            transaccion = transaccion.traerTransaccion_id(ID);

            List<Transaccion> resultado_busqueda = new List<Transaccion>();
            resultado_busqueda.Add(transaccion);

            return resultado_busqueda;
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

            // Disminuimos el valor "descripcion" del consecutivo en 1.
            //Consecutivo consecutivo = new Consecutivo();
            //Consecutivo registro_de_consecutivo = consecutivo.traerConsecutivo_registroReflejadoEnDB("transaccion");
            //string valorDescripcionDisminuidoEn1 = Tareas.disminuirColumnaDeConsecutivoEn1(registro_de_consecutivo);
            //registro_de_consecutivo.descripcion = valorDescripcionDisminuidoEn1;
            //consecutivo.actualizarConsecutivo_baseDeDatos(registro_de_consecutivo);

            return "Transaccion " + id + " eliminada.";
        }
    }
}
