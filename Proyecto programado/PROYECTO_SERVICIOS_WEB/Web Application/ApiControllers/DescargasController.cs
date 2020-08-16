using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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

        // GET: api/Descargas/?archivoDescarga=nombre_archivo
        public HttpResponseMessage Get(string archivoDescarga)
        {
            Parametros parametros = new Parametros();
            List<Parametros> lista_parametros = parametros.traerParametros();
            string pathMusica = lista_parametros.First().rutaAlmacenamientoMusica + "\\" + archivoDescarga;
            string pathLibro = lista_parametros.First().rutaAlmacenamientoLibros + "\\" + archivoDescarga;
            string pathPelicula = lista_parametros.First().rutaAlmacenamientoPeliculas + "\\" + archivoDescarga;
            string pathDescarga = null;
            string tipoDescarga = "";

            if (File.Exists(pathMusica))
            {
                pathDescarga = pathMusica;
                tipoDescarga = "audio/mp3";
            }
            else if (File.Exists(pathLibro))
            {
                pathDescarga = pathLibro;
                tipoDescarga = "application/pdf";
            }
            else if (File.Exists(pathPelicula))
            {
                pathDescarga = pathPelicula;
                tipoDescarga = "video/mp4";
            }

            if (pathDescarga != null)
            {
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                var stream = new FileStream(pathDescarga, FileMode.Open);
                result.Content = new StreamContent(stream);
                result.Content.Headers.ContentType = new MediaTypeHeaderValue(tipoDescarga);
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                result.Content.Headers.ContentDisposition.FileName = archivoDescarga;
                return result;
            }
            return new HttpResponseMessage(HttpStatusCode.NotFound);
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
