using BLL.Logica;
using System.Collections.Generic;
using System.Data;

namespace BLL.Objeto
{
    public class Categorias_libros
    {
        public string id { get; set; }
        public string categoria { get; set; }

        public List<Categorias_libros> traerCategorias_libros()
        {
            DataSet datos = Memoria.logica_database
             .queryConRetornoDeDatos_sinParametros(
             Memoria.logica_database.stringDeConexion_baseDeDatos_principal,
             "sp_categorias_libros_leer"
             );

            if (datos.Tables[0].Rows.Count > 0)
            {
                List<Categorias_libros> lista_categoriasLibros = new List<Categorias_libros>();
                for (int i = 0; i < datos.Tables[0].Rows.Count; i++)
                {
                    lista_categoriasLibros.Add(
                        new Categorias_libros
                            (
                            Desencriptar.desencriptar(datos.Tables[0].Rows[i]["ID"].ToString())
                            , Desencriptar.desencriptar(datos.Tables[0].Rows[i]["categoria"].ToString())
                            )
                        );
                }
                return lista_categoriasLibros;
            }
            else
            {
                return null;
            }
        }

        public void guardar_categoriaLibros(Categorias_libros categoria_libros)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_categorias_libros_crear";

            Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(categoria_libros));
        }

        public void actualizar_categoriaLibro(Categorias_libros categoria_libros)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_categorias_libros_actualizar";

            Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(categoria_libros));
        }

        public void eliminar_categoriaLibro(string id)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_categorias_libros_eliminar";

            string[] parametros = { "ID" };
            string[] valores = { id };

            Memoria.logica_database
               .querySimple(stringDeConexion
               , nombre_storedProcedure
               , parametros
               , valores);
        }

        public Categorias_libros() { }

        public Categorias_libros(string id, string categoria)
        {
            this.id = id;
            this.categoria = categoria;
        }

        string[] parametros = {
                "ID"
                ,"categoria"};

        private string[] return_valores(Categorias_libros categoria_libros)
        {
            string[] valores = {
                categoria_libros.id
                ,categoria_libros.categoria
            };
            return valores;
        }
    }
}
