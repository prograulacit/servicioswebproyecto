using BLL.Logica;
using System.Collections.Generic;
using System.Data;

namespace BLL.Objeto
{
    public class Libro
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string categoria { get; set; }
        public string autor { get; set; }
        public string idioma { get; set; }
        public string editorial { get; set; }
        public string anioPublicacion { get; set; }
        public string nombreArchivoDescarga { get; set; }
        public string nombreArchivoPrevisualizacion { get; set; }
        public string monto { get; set; }

        public List<Libro> traerLibros()
        {
            DataSet datos = Memoria.logica_database
             .queryConRetornoDeDatos_sinParametros(
             Memoria.logica_database.stringDeConexion_baseDeDatos_principal,
             "sp_libro_leer"
             );

            if (datos.Tables[0].Rows.Count > 0)
            {
                List<Libro> lista_libros = new List<Libro>();
                for (int i = 0; i < datos.Tables[0].Rows.Count; i++)
                {
                    lista_libros.Add(
                        new Libro
                            (
                            Encriptacion.desencriptar(datos.Tables[0].Rows[i]["ID"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["nombre"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["categoria"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["autor"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["idioma"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["editorial"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["anioPublicacion"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["nombreArchivoDescarga"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["nombreArchivoPrevisualizacion"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["monto"].ToString())
                            )
                        );
                }
                return lista_libros;
            }
            else
            {
                return null;
            }
        }

        public void guardarLibro(Libro libro)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_libro_crear";

            Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(libro));
        }

        public void actualizarLibro(Libro libro)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_libro_actualizar";

            Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(libro));
        }

        public void eliminarLibro(string id)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_libro_eliminar";

            string[] parametros = { "ID" };
            string[] valores = { id };

            Memoria.logica_database
               .querySimple(stringDeConexion
               , nombre_storedProcedure
               , parametros
               , valores);
        }

        public Libro() { }

        public Libro(string id
            , string nombre
            , string categoria
            , string autor
            , string idioma
            , string editorial
            , string anioPublicacion
            , string nombreArchivoDescarga
            , string nombreArchivoPrevisualizacion
            , string monto)
        {
            this.id = id;
            this.nombre = nombre;
            this.categoria = categoria;
            this.autor = autor;
            this.idioma = idioma;
            this.editorial = editorial;
            this.anioPublicacion = anioPublicacion;
            this.nombreArchivoDescarga = nombreArchivoDescarga;
            this.nombreArchivoPrevisualizacion = nombreArchivoPrevisualizacion;
            this.monto = monto;
        }

        string[] parametros = {
                "ID"
                ,"nombre"
                , "categoria"
                , "autor"
                , "idioma"
                , "editorial"
                , "anioPublicacion"
                , "nombreArchivoDescarga"
                , "nombreArchivoPrevisualizacion"
                , "monto"};

        private string[] return_valores(Libro libro)
        {
            string[] valores = {
                libro.id
                ,libro.nombre
                ,libro.categoria
                ,libro.autor
                ,libro.idioma
                ,libro.editorial
                ,libro.anioPublicacion
                ,libro.nombreArchivoDescarga
                ,libro.nombreArchivoPrevisualizacion
                ,libro.monto
            };
            return valores;
        }
    }
}
