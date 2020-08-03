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

        // GET: api/EasyPay/5
        public EasyPay Get(string id)
        {
            EasyPay ep = new EasyPay();

            // Recorre todos los easypays
            foreach (EasyPay e in ep.traer_easyPays()) 
            {
                if(e.id == id) // si encuentra coincidencia, lo retorna.
                {
                    return e;
                }
            }
            return null; // retorna null si no fue encontrado.
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

        // DELETE: api/EasyPay/5
        public string Delete(string id)
        {
            EasyPay easypay = new EasyPay();
            easypay.eliminar_easypay(id);
            return "EasyPay " + id + " eliminada.";
        }
    }
}
