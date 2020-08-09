using BLL.Logica;
using BLL.Objeto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
        public string Put([FromBody]string productoCompraId)
        {
            Memoria.productoAComprar.productoCompraId = productoCompraId;
            return "";
        }

        // DELETE: api/ProductoCompra/5
        public void Delete(int id)
        {
        }
    }
}
