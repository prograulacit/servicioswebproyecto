using System.Collections.Generic;
using System.Web.Http;
using BLL.Logica;
using BLL.Objeto;

namespace Web_Application.ApiControllers
{
    public class PeliculaController : ApiController
    {
        // GET: api/Pelicula
        public IEnumerable<Pelicula> Get()
        {
            Pelicula pelicula = new Pelicula();
            List<Pelicula> lista_peliculas = pelicula.traerPeliculas();
            return lista_peliculas;
        }

        // GET: api/Pelicula/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Pelicula
        public string Post([FromBody]Pelicula pelicula)
        {
            #region Plantilla Postman -> Abrir para ver.
            /*{
                "nombre":"NombreDePelicula",
                "genero": "generoDePelicula",
                "anio":"anioDeLaPelicula",
                "idioma":"idiomaDeLaPelicula",
                "actores":"actoresDeLaPelicula",
                "nombreArchivoDescarga":"registroEnDetallePlaceholder",
                "nombreArchivoPrevisualizacion":"registroEnDetallePlaceholder",
                "monto":"registroEnDetallePlaceholder"
            }*/
            #endregion

            Consecutivo consecutivo = new Consecutivo();

            // Registro espejo del registro requerido guardado en la base de datos.
            Consecutivo registro_de_consecutivo = 
                consecutivo.traerConsecutivo_registroReflejadoEnDB("pelicula");

            // Se actualiza el id de la pelicula como prefijo+numConsecuvito.
            // Ejemplo: pel4 .
            pelicula.id =
                registro_de_consecutivo.prefijo + (int.Parse(registro_de_consecutivo.descripcion) + 1);

            // Aumentamos el valor "descripcion" del consecutivo en 1.
            string valorDescripcionAumentadoEn1 =
                Tareas.aumentarColumnaDeConsecutivoEn1(registro_de_consecutivo);
            registro_de_consecutivo.descripcion = valorDescripcionAumentadoEn1;

            // Guardamos el nuevo registro en la base de datos.
            pelicula.guardarPelicula(pelicula);

            // Actualizamos el consecutivo en la base de datos.
            consecutivo.actualizarConsecutivo_baseDeDatos(registro_de_consecutivo);

            // Agregar registro en bitacora
            Bitacora bitacora = new Bitacora();
            string registroEnDetalle = "Id=" + pelicula.id + " | " + "Nombre=" + pelicula.nombre + " | " +
                "Genero=" + pelicula.genero + " | " + "Anio=" + pelicula.anio + " | " +
                "idioma=" + pelicula.idioma + " | " + "Actores=" + pelicula.actores + " | " +
                "nombreArchivoDescarga=" + pelicula.nombreArchivoDescarga + " | " +
                "nombreArchivoPrevisualizacion=" + pelicula.nombreArchivoPrevisualizacion + " | " +
                "Monto=" + pelicula.monto + " | ";
            bitacora.guardarBitacora_interfazDeUsuario("Agregar", "Insercion de una nueva Pelicula", registroEnDetalle);

            return "Pelicula " + pelicula.id + " guardada.";
        }

        // PUT: api/Pelicula/5
        public string Put([FromBody]Pelicula pelicula)
        {
            #region Plantilla Postman -> Abrir para ver.
            //{
            //    "ID":"IDadminResponsable",
            //    "nombre":"IDadminResponsable",
            //    "genero": "codigoDelRegistroPlaceholder",
            //    "anio":"tipoBitacoraPlaceholder",
            //    "idioma":"descripcionPlaceholder",
            //    "actores":"registroEnDetallePlaceholder",
            //    "nombreArchivoDescarga":"registroEnDetallePlaceholder",
            //    "nombreArchivoPrevisualizacion":"registroEnDetallePlaceholder",
            //    "monto":"registroEnDetallePlaceholder"
            //}
            #endregion

            pelicula.actualizarPelicula(pelicula);

            // Agregar registro en bitacora
            Bitacora bitacora = new Bitacora();
            string registroEnDetalle = "Id=" + pelicula.id + " | " + "Nombre=" + pelicula.nombre + " | " +
                "Genero=" + pelicula.genero + " | " + "Anio=" + pelicula.anio + " | " +
                "idioma=" + pelicula.idioma + " | " + "Actores=" + pelicula.actores + " | " +
                "nombreArchivoDescarga=" + pelicula.nombreArchivoDescarga + " | " +
                "nombreArchivoPrevisualizacion=" + pelicula.nombreArchivoPrevisualizacion + " | " +
                "Monto=" + pelicula.monto + " | ";
            bitacora.guardarBitacora_interfazDeUsuario("Modificar", "Modificacion de Pelicula", registroEnDetalle);

            return "Pelicula " + pelicula.id + " actualizada.";
        }

        // DELETE: api/Pelicula/5
        public string Delete(string id)
        {
            Pelicula pelicula = new Pelicula();
            pelicula.eliminarPelicula(id);

            // Disminuimos el valor "descripcion" del consecutivo en 1.
            Consecutivo consecutivo = new Consecutivo();
            Consecutivo registro_de_consecutivo = consecutivo.traerConsecutivo_registroReflejadoEnDB("pelicula");
            string valorDescripcionDisminuidoEn1 = Tareas.disminuirColumnaDeConsecutivoEn1(registro_de_consecutivo);
            registro_de_consecutivo.descripcion = valorDescripcionDisminuidoEn1;
            consecutivo.actualizarConsecutivo_baseDeDatos(registro_de_consecutivo);

            // Agregar registro en bitacora
            Bitacora bitacora = new Bitacora();
            bitacora.guardarBitacora_interfazDeUsuario("Eliminar", "Eliminacion de Pelicula", "");

            return "Pelicula " + id + " eliminada.";
        }
    }
}
