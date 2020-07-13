using BLL.Logica;
using System.Collections.Generic;
using System.Data;

namespace BLL.Objeto
{
    public class Generos_peliculas
    {
        public string id { get; set; }
        public string genero { get; set; }

        public List<Generos_peliculas> traer_generosPelicula()
        {
            DataSet datos = Memoria.logica_database
             .queryConRetornoDeDatos_sinParametros(
             Memoria.logica_database.stringDeConexion_baseDeDatos_principal,
             "sp_generos_pelicula_leer"
             );

            if (datos.Tables[0].Rows.Count > 0)
            {
                List<Generos_peliculas> lista_generosPelicula = new List<Generos_peliculas>();
                for (int i = 0; i < datos.Tables[0].Rows.Count; i++)
                {
                    lista_generosPelicula.Add(
                        new Generos_peliculas
                            (
                            Encriptacion.desencriptar(datos.Tables[0].Rows[i]["ID"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["genero"].ToString())
                            )
                        );
                }
                return lista_generosPelicula;
            }
            else
            {
                return null;
            }
        }

        public void guardar_generosPelicula(Generos_peliculas generos_peliculas)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_generos_peliculas_crear";

            Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(generos_peliculas));
        }

        public void actualizar_generosPelicula(Generos_peliculas generos_peliculas)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_generos_peliculas_actualizar";

            Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(generos_peliculas));
        }

        public void eliminar_generosPelicula(string id)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_generos_peliculas_eliminar";

            string[] parametros = { "ID" };
            string[] valores = { id };

            Memoria.logica_database
               .querySimple(stringDeConexion
               , nombre_storedProcedure
               , parametros
               , valores);
        }

        public Generos_peliculas() { }

        public Generos_peliculas(string id, string genero)
        {
            this.id = id;
            this.genero = genero;
        }

        string[] parametros = {
                "ID"
                ,"genero"};

        private string[] return_valores(Generos_peliculas generos_peliculas)
        {
            string[] valores = {
                generos_peliculas.id
                ,generos_peliculas.genero
            };
            return valores;
        }
    }
}
