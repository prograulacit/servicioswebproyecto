using BLL.Logica;
using System.Collections.Generic;
using System.Data;

namespace BLL.Objeto
{
    public class Pelicula
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string genero { get; set; }
        public string anio { get; set; }
        public string idioma { get; set; }
        public string actores { get; set; }
        public string nombreArchivoDescarga { get; set; }
        public string nombreArchivoPrevisualizacion { get; set; }
        public string monto { get; set; }

        public List<Pelicula> traerPeliculas()
        {
            DataSet datos = Memoria.logica_database
             .queryConRetornoDeDatos_sinParametros(
             Memoria.logica_database.stringDeConexion_baseDeDatos_principal,
             "sp_pelicula_leer"
             );

            if (datos.Tables[0].Rows.Count > 0)
            {
                List<Pelicula> lista_peliculas = new List<Pelicula>();
                for (int i = 0; i < datos.Tables[0].Rows.Count; i++)
                {
                    lista_peliculas.Add(
                        new Pelicula
                            (
                            Encriptacion.desencriptar(datos.Tables[0].Rows[i]["ID"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["nombre"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["genero"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["anio"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["idioma"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["actores"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["nombreArchivoDescarga"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["nombreArchivoPrevisualizacion"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["monto"].ToString())
                            )
                        );
                }
                return lista_peliculas;
            }
            else
            {
                return null;
            }
        }

        public Pelicula traerPeliculaPorId(string id)
        {
            List<Pelicula> lista_pelicula = traerPeliculas();

            if (lista_pelicula != null)
            {
                for (int i = 0; i < lista_pelicula.Count; i++)
                {
                    if (lista_pelicula[i].id == id)
                    {
                        return lista_pelicula[i];
                    }
                }
            }
            return null;
        }

        public void guardarPelicula(Pelicula pelicula)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_pelicula_crear";

            Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(pelicula));
        }

        public void actualizarPelicula(Pelicula pelicula)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_pelicula_actualizar";

            Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(pelicula));
        }

        public void eliminarPelicula(string id)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_pelicula_eliminar";

            string[] parametros = { "ID" };
            string[] valores = { id };

            Memoria.logica_database
               .querySimple(stringDeConexion
               , nombre_storedProcedure
               , parametros
               , valores);
        }

        public Pelicula() { }

        public Pelicula(string id
            , string nombre
            , string genero
            , string anio
            , string idioma
            , string actores
            , string nombreArchivoDescarga
            , string nombreArchivoPrevisualizacion
            , string monto)
        {
            this.id = id;
            this.nombre = nombre;
            this.genero = genero;
            this.anio = anio;
            this.idioma = idioma;
            this.actores = actores;
            this.nombreArchivoDescarga = nombreArchivoDescarga;
            this.nombreArchivoPrevisualizacion = nombreArchivoPrevisualizacion;
            this.monto = monto;
        }

        string[] parametros = {
                "ID"
                ,"nombre"
                , "genero"
                , "anio"
                , "idioma"
                , "actores"
                , "nombreArchivoDescarga"
                , "nombreArchivoPrevisualizacion"
                , "monto"};

        private string[] return_valores(Pelicula pelicula)
        {
            string[] valores = {
                pelicula.id
                ,pelicula.nombre
                ,pelicula.genero
                ,pelicula.anio
                ,pelicula.idioma
                ,pelicula.actores
                ,pelicula.nombreArchivoDescarga
                ,pelicula.nombreArchivoPrevisualizacion
                ,pelicula.monto
            };
            return valores;
        }
    }
}
