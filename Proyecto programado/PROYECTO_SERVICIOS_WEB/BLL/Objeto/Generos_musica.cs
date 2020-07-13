using BLL.Logica;
using System.Collections.Generic;
using System.Data;

namespace BLL.Objeto
{
    public class Generos_musica
    {
        public string id { get; set; }
        public string genero { get; set; }

        public List<Generos_musica> traer_generosMusica()
        {
            DataSet datos = Memoria.logica_database
             .queryConRetornoDeDatos_sinParametros(
             Memoria.logica_database.stringDeConexion_baseDeDatos_principal,
             "sp_generos_musica_leer"
             );

            if (datos.Tables[0].Rows.Count > 0)
            {
                List<Generos_musica> lista_generosMusica = new List<Generos_musica>();
                for (int i = 0; i < datos.Tables[0].Rows.Count; i++)
                {
                    lista_generosMusica.Add(
                        new Generos_musica
                            (
                            Encriptacion.desencriptar(datos.Tables[0].Rows[i]["ID"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["genero"].ToString())
                            )
                        );
                }
                return lista_generosMusica;
            }
            else
            {
                return null;
            }
        }

        public void guardar_generosMusica(Generos_musica generos_musica)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_generos_musica_crear";

            Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(generos_musica));
        }

        public void actualizar_generosMusica(Generos_musica generos_musica)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_generos_musica_actualizar";

            Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(generos_musica));
        }

        public void eliminar_generosMusica(string id)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_generos_musica_eliminar";

            string[] parametros = { "ID" };
            string[] valores = { id };

            Memoria.logica_database
               .querySimple(stringDeConexion
               , nombre_storedProcedure
               , parametros
               , valores);
        }

        public Generos_musica() { }

        public Generos_musica(string id, string genero)
        {
            this.id = id;
            this.genero = genero;
        }

        string[] parametros = {
                "ID"
                ,"genero"};

        private string[] return_valores(Generos_musica generos_musica)
        {
            string[] valores = {
                generos_musica.id
                ,generos_musica.genero
            };
            return valores;
        }
    }
}
