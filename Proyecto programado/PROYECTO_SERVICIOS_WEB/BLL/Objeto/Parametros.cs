using BLL.Logica;
using System.Collections.Generic;
using System.Data;

namespace BLL.Objeto
{
    public class Parametros
    {
        public string id { get; set; }
        public string rutaAlmacenamientoPrevisualizacionLibros { get; set; }
        public string rutaAlmacenamientoLibros { get; set; }

        public string rutaAlmacenamientoPrevisualizacionPeliculas { get; set; }
        public string rutaAlmacenamientoPeliculas { get; set; }

        public string rutaAlmacenamientoPrevisualizacionMusica { get; set; }
        public string rutaAlmacenamientoMusica { get; set; }

        public List<Parametros> traerParametros()
        {
            DataSet datos = Memoria.logica_database
              .queryConRetornoDeDatos_sinParametros(
              Memoria.logica_database.stringDeConexion_baseDeDatos_principal,
              "sp_parametros_leer"
              );

            if (datos.Tables[0].Rows.Count > 0)
            {
                List<Parametros> lista_parametros = new List<Parametros>();
                for (int i = 0; i < datos.Tables[0].Rows.Count; i++)
                {
                    lista_parametros.Add(
                        new Parametros
                            (
                            Desencriptar.desencriptar(datos.Tables[0].Rows[i]["ID"].ToString())
                            , Desencriptar.desencriptar(datos.Tables[0]
                            .Rows[i]["rutaAlmacenamientoPrevisualizacionLibros"].ToString())
                            , Desencriptar.desencriptar(datos.Tables[0]
                            .Rows[i]["rutaAlmacenamientoLibros"].ToString())
                            , Desencriptar.desencriptar(datos.Tables[0]
                            .Rows[i]["rutaAlmacenamientoPrevisualizacionPeliculas"].ToString())
                            , Desencriptar.desencriptar(datos.Tables[0]
                            .Rows[i]["rutaAlmacenamientoPeliculas"].ToString())
                            , Desencriptar.desencriptar(datos.Tables[0]
                            .Rows[i]["rutaAlmacenamientoPrevisualizacionMusica"].ToString())
                            , Desencriptar.desencriptar(datos.Tables[0]
                            .Rows[i]["rutaAlmacenamientoMusica"].ToString())
                            )
                        );
                }
                return lista_parametros;
            }
            else
            {
                return null;
            }
        }

        public void actualizarParametros(Parametros parametros)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_parametros_actualizar";

            Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(parametros));
        }

        public void crearRegistroParametros(Parametros parametros)
        {
            List<Parametros> lista_parametros_temporal = traerParametros();

            // Solo puede existir un registro de Parametros en la base de datos.
            // Si ya existe un registro, no se efectuara la consulta.
            if (lista_parametros_temporal == null)
            {
                string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
                string nombre_storedProcedure = "sp_parametros_crear";

                Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(parametros));
            }
        }

        public void eliminarRegistroParametros(string id)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_parametros_eliminar";

            string[] parametros = { "ID" };
            string[] valores = { id };

            Memoria.logica_database
               .querySimple(stringDeConexion
               , nombre_storedProcedure
               , parametros
               , valores);
        }

        public Parametros() { }

        public Parametros(
            string id
            , string rutaAlmacenamientoPrevisualizacionLibros
            , string rutaAlmacenamientoLibros
            , string rutaAlmacenamientoPrevisualizacionPeliculas
            , string rutaAlmacenamientoPeliculas
            , string rutaAlmacenamientoPrevisualizacionMusica
            , string rutaAlmacenamientoMusica)
        {
            this.id = id;
            this.rutaAlmacenamientoPrevisualizacionLibros = rutaAlmacenamientoPrevisualizacionLibros;
            this.rutaAlmacenamientoLibros = rutaAlmacenamientoLibros;
            this.rutaAlmacenamientoPrevisualizacionPeliculas = rutaAlmacenamientoPrevisualizacionPeliculas;
            this.rutaAlmacenamientoPeliculas = rutaAlmacenamientoPeliculas;
            this.rutaAlmacenamientoPrevisualizacionMusica = rutaAlmacenamientoPrevisualizacionMusica;
            this.rutaAlmacenamientoMusica = rutaAlmacenamientoMusica;
        }

        string[] parametros = {
                "ID"
                ,"rutaAlmacenamientoPrevisualizacionLibros"
                , "rutaAlmacenamientoLibros"
                , "rutaAlmacenamientoPrevisualizacionPeliculas"
                , "rutaAlmacenamientoPeliculas"
                , "rutaAlmacenamientoPrevisualizacionMusica"
                , "rutaAlmacenamientoMusica"};

        private string[] return_valores(Parametros parametros)
        {
            string[] valores = {
                parametros.id
                ,parametros.rutaAlmacenamientoPrevisualizacionLibros
                ,parametros.rutaAlmacenamientoLibros
                ,parametros.rutaAlmacenamientoPrevisualizacionPeliculas
                ,parametros.rutaAlmacenamientoPeliculas
                ,parametros.rutaAlmacenamientoPrevisualizacionMusica
                ,parametros.rutaAlmacenamientoMusica
            };
            return valores;
        }
    }
}
