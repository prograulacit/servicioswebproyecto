using System.Collections.Generic;
using System.Web.Http;
using BLL.Logica;
using BLL.Objeto;

namespace Web_Application.ApiControllers
{
    public class Categorias_librosController : ApiController
    {
        // GET: api/Categorias_libros
        public IEnumerable<Categorias_libros> Get()
        {
            Categorias_libros cate_lib = new Categorias_libros();
            List<Categorias_libros> lista_catLib = cate_lib.traerCategorias_libros();
            return lista_catLib;
        }

        // POST: api/Categorias_libros
        public string Post([FromBody]Categorias_libros categorias_libros)
        {
            #region Plantilla Postman -> Abrir para ver.
            //{
            //    "categoria": "codigoDelRegistroPlaceholder"
            //}
            #endregion
            string nuevo_id = Tareas.generar_nuevo_id_para_un_registro();

            categorias_libros.id = nuevo_id;

            categorias_libros.guardar_categoriaLibros(categorias_libros);
            return "Categoria de libro " + nuevo_id + " guardada.";
        }

        // PUT: api/Categorias_libros/5
        public string Put([FromBody]Categorias_libros categorias_Libros)
        {
            #region Plantilla Postman -> Abrir para ver.
            //{
            //    "ID":"IDadminResponsable",
            //    "categoria":"IDadminResponsable"
            //}
            #endregion

            categorias_Libros.actualizar_categoriaLibro(categorias_Libros);
            return "Categoria de libro " + categorias_Libros.id + " actualizada.";
        }

        // DELETE: api/Categorias_libros/5
        public string Delete(string id)
        {
            Categorias_libros categorias_libros = new Categorias_libros();
            categorias_libros.eliminar_categoriaLibro(id);
            return "Categoria de libro " + id + " eliminada.";
        }
    }
}
