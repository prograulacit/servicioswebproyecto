using BLL.Logica;
using BLL.Objeto;
using System.Web.Http;
using System.Windows.Forms;

namespace Web_Application.ApiControllers
{
    public class ProductoCompraController : ApiController
    {
        // GET: api/ProductoCompra
        public string Get()
        {
            if (Memoria.productoAComprar.productoCompraId != null)
            {
                return Memoria.productoAComprar.productoCompraId;
            }
            return "Sin producto seleccionado.";
        }

        // PUT: api/ProductoCompra/5
        /// <summary>
        /// Obtiene el producto que el usuario eligio por su ID.
        /// </summary>
        /// <param name="pdID">Contiene el ID del producto
        /// que el usuario desea comprar en su variable productoCompraID</param>
        /// <returns></returns>
        public string Put([FromBody]ProductoCompra pdID)
        {
           // Establece el producto que se va a comprar en la memoria.
           Memoria.productoAComprar = 
                new ProductoCompra(pdID.productoCompraId);
            return "OK. ID:" + Memoria.productoAComprar.productoCompraId;
        }

        // DELETE: api/ProductoCompra
        public string Delete()
        {
            Memoria.productoAComprar = new ProductoCompra();
            return "Producto limpiado";
        }
    }
}
