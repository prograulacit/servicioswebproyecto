using System.Collections.Generic;
using System.Web.Http;
using BLL.Logica;
using BLL.Objeto;

namespace Web_Application.ApiControllers
{
    public class DescargasController : ApiController
    {
        // GET: api/Descargas
        public IEnumerable<Descargas> Get()
        {
            Descargas descargas = new Descargas();
            List<Descargas> lista_descargas = descargas.traerDescargas();
            return lista_descargas;
        }

        // POST: api/Descargas
        public string Post([FromBody]Descargas descargas)
        {
            #region Plantilla Postman -> Abrir para ver.
            /*{
                "IDconsecutivo": "producto",
                "IDusuario":"usuarioIdONombreUsuario"
            }*/
            #endregion
            string nuevo_id = Tareas.generar_nuevo_id_para_un_registro();

            descargas.ID = nuevo_id;

            descargas.crearRegistroDescarga(descargas);

            return "Descarga " + nuevo_id + " agregada.";
        }

        // PUT: api/Descargas/5
        public string Put([FromBody]Descargas descargas)
        {
            #region Plantilla Postman -> Abrir para ver.
            /*{
                "ID":"idDescarga",
                "IDconsecutivo": "producto",
                "IDusuario":"usuarioIdONombreUsuario"
            }*/
            #endregion
            descargas.actualizarRegistroDescarga(descargas);
            return "Descarga " + descargas.ID + " actualizada.";
        }

        // DELETE: api/Descargas/5
        public string Delete(string id)
        {
            Descargas descargas = new Descargas();
            descargas.eliminarRegistroDescarga(id);
            return "Descarga " + id + " eliminada.";
        }
    }
}
