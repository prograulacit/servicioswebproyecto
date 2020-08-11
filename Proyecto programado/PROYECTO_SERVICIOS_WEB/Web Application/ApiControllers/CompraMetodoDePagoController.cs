using System.Web.Http;
using BLL.Objeto;
using BLL.Logica;

namespace Web_Application.ApiControllers
{
    public class CompraMetodoDePagoController : ApiController
    {
        // GET: api/CompraMetodoDePago
        /// <summary>
        /// Regresa el ID del metodo de pago a utilizar.
        /// </summary>
        /// <returns>String</returns>
        public string Get()
        {
            if (Memoria.compraMetodoDePago.metodoDePagoID != null)
            {
                return Memoria.compraMetodoDePago.metodoDePagoID;
            }
            return "Metodo de pago no establecido";
        }

        // PUT: api/CompraMetodoDePago
        /// <summary>
        /// Dado un ID de una Tarjeta o EasyPay, este sera guardado en la memoria
        /// como metodo de pago de un producto que se desee comprar.
        /// </summary>
        /// <param name="cmp">Objeto CompraMetodoPago el cual guarda el
        /// ID del metodo de pago a utilizar.</param>
        /// <returns></returns>
        public string Put([FromBody]CompraMetodoDePago cmp)
        {
            // Establece el metodo de pago que se va a usar en la memoria.
            Memoria.compraMetodoDePago =
                 new CompraMetodoDePago(cmp.metodoDePagoID);
            return "OK. ID:" + Memoria.compraMetodoDePago.metodoDePagoID;
        }

        // DELETE: api/CompraMetodoDePago
        /// <summary>
        /// Limpia el metodo de pago que se iba a utilizar.
        /// </summary>
        /// <returns>String con mensaje de confirmación.</returns>
        public string Delete()
        {
            Memoria.compraMetodoDePago = new CompraMetodoDePago();
            return "Metodo de pago limpiado";
        }
    }
}
