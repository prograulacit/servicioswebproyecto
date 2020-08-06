using System;
using System.Collections.Generic;
using System.Web.Http;
using BLL.Logica;
using BLL.Objeto;

namespace Web_Application.ApiControllers
{
    public class EasyPayController : ApiController
    {
        // GET: api/EasyPay
        public IEnumerable<EasyPay> Get()
        {
            EasyPay ep = new EasyPay();
            return ep.traer_easyPays();
        }

        /// <summary>
        /// Envia al cliente una lista de EasyPays asociados
        /// con el ID que se haya dado.
        /// </summary>
        /// <param name="user_id">ID del usuario. Si es
        /// escrito como ID "asociada" se envia segun el usuario
        /// logeado en memoria.</param>
        /// <returns>Lista de tarjetas asociadas al usuario
        /// cuyo ID fue dado.</returns>
        public IEnumerable<EasyPay> Get(string user_id)
        {
            EasyPay e = new EasyPay();

            switch (user_id)
            {
                // Se requieren los easypays asociadas al usuario 
                // logeado en memoria.
                case "asociada":
                    if (Memoria.sesionUsuarioDatos != null)
                    {
                        List<EasyPay> listaEasypays_asociados =
                            e.traerEasyPays_UsuarioId(
                                Memoria.sesionUsuarioDatos.id);

                        if (listaEasypays_asociados != null)
                        {
                            return listaEasypays_asociados;
                        }
                    }
                    // Retorna nulo si no hay sesion de usuario o
                    // no hay EasyPays asociados.
                    return null;

                // Retorna EasyPays segun el ID del usuario dado.
                default:
                    List<EasyPay> listaEasyPays_asociados =
                    e.traerEasyPays_UsuarioId(user_id);

                    if (listaEasyPays_asociados != null)
                    {
                        return listaEasyPays_asociados;
                    }
                    return null; // Retorna null si no existen cuentas EasyPay.
            }
        }

        // POST: api/EasyPay
        public string Post([FromBody]EasyPay easypay)
        {
            #region Plantilla Postman -> Abrir para ver.
            /*{
                "IDusuario": "xxxxxxxxxxxxxx",
                "numeroCuenta": "xxxxxxxxxxxxxx",
                "codigoSeguridad": "xxxxxxxxxxxxxx",
                "contrasenia": "xxxxxxxxxxxxxx",
                "monto": "xxxxxxxxxxxxxx"
            }*/
            #endregion
            string nuevo_id = Tareas.generar_nuevo_id_para_un_registro();
            easypay.id = nuevo_id;

            easypay.guardar_easyPay(easypay);
            return "EasyPay " + easypay.id + " guardado.";
        }

        // PUT: api/EasyPay/5
        public string Put([FromBody]EasyPay easypay)
        {
            /*{
                "ID": "xxxxxxxxxxxxxx",
                "IDusuario": "editado",
                "numeroCuenta": "editado",
                "codigoSeguridad": "editado",
                "contrasenia": "editado",
                "monto": "editado"
            }*/

            easypay.actualizar_easypay(easypay);
            return "EasyPay " + easypay.id + " actualizado.";
        }

        /// <summary>
        /// Cambia el codigo de seguridad de un EasyPay.
        /// </summary>
        /// <param name="easypay_id">ID del EasyPay a actualizar</param>
        /// <returns>Nuevo código de seguridad.</returns>
        public string Put(string easypay_id) 
        {
            #region Plantilla Postman
            /*
             Params -> 
             KEY: easypay_id
             VALUE: [ID del easy pay a actualizar]
             */
            #endregion

            EasyPay easyPay = new EasyPay();
            easyPay = easyPay.traerEasyPay_porID(easypay_id);

            // Actualiza codigo de seguridad y actualiza registro en base de datos.
            easyPay.codigoSeguridad = easyPay.generarCodigoDeSeguridad();
            easyPay.actualizar_easypay(easyPay);

            return easyPay.codigoSeguridad;
        }

        // DELETE: api/EasyPay/5
        public string Delete(string id)
        {
            EasyPay easypay = new EasyPay();
            easypay.eliminar_easypay(id);
            return "EasyPay " + id + " eliminada.";
        }
    }
}
