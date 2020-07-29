using System;
using System.Collections.Generic;
using System.Web.Http;
using BLL.Logica;
using BLL.Objeto;

namespace Web_Application.ApiControllers
{
    public class TarjetaController : ApiController
    {
        // GET: api/Tarjeta
        public IEnumerable<Tarjeta> Get()
        {
            Tarjeta tarjeta = new Tarjeta();
            List<Tarjeta> lista_tarjetas = tarjeta.traerTarjetas();
            return lista_tarjetas;
        }

        // GET: api/Tarjeta/5
        // Resive un id de usuario y retorna JSON con
        // tarjetas asociadas con ese id.
        public IEnumerable<Tarjeta> Get(string user_id)
        {

            Tarjeta t = new Tarjeta();
            List<Tarjeta> listaTarjetas_asociadas = 
                t.traerTarjetas_UsuarioId(user_id);

            if (listaTarjetas_asociadas.Count > 0 )
            {
                return listaTarjetas_asociadas;
            }

            // Si no hay tarjetas asociadas, retorna null.
            return null;
        }

        // POST: api/Tarjeta
        public string Post([FromBody]Tarjeta tarjeta)
        {
            #region Plantilla Postman -> Abrir para ver.
            /*{
                "usuarioID": "xxxxxxxxxxxx",
                "numeroTarjeta": "xxxxxxxxxxxx",
                "mesExpiracion": "xxxxxxxxxxxx",
                "anioExpiracion": "xxxxxxxxxxxx",
                "CVV": "xxxxxxxxxxxx",
                "monto": "xxxxxxxxxxxx",
                "tipo": "xxxxxxxxxxxx"
            }*/
            #endregion
            try
            {
                tarjeta.id = Tareas.generar_nuevo_id_para_un_registro();
                tarjeta.guardarTarjeta(tarjeta);
                return "Tarjeta " + tarjeta.id + " guardada.";
            }
            catch (Exception e)
            {
                return "Fallo en guardar la tarjeta. Revise los datos enviados.\n\n" + e;
            }
        }

        // PUT: api/Tarjeta/5
        public string Put([FromBody]Tarjeta tarjeta)
        {
            #region Plantilla Postman -> Abrir para ver.
            /*{
                "ID":"xxxxxxxxxxxx",
                "usuarioID": "xxxxxxxxxxxx",
                "numeroTarjeta": "xxxxxxxxxxxx",
                "mesExpiracion": "xxxxxxxxxxxx",
                "anioExpiracion": "xxxxxxxxxxxx",
                "CVV": "xxxxxxxxxxxx",
                "monto": "xxxxxxxxxxxx",
                "tipo": "xxxxxxxxxxxx"
            }*/
            #endregion

            tarjeta.actualizarTarjeta(tarjeta);
            return "Tarjeta " + tarjeta.id + " actualizada.";
        }

        // DELETE: api/Tarjeta/5
        public string Delete(string id)
        {
            Tarjeta tarjeta = new Tarjeta();
            tarjeta.eliminarTarjeta(id);
            return "Tarjeta " + id + " eliminada.";
        }
    }
}
