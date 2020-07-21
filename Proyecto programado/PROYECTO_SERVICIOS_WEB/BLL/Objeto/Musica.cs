using BLL.Logica;
using System.Collections.Generic;
using System.Data;

namespace BLL.Objeto
{
    public class Musica
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string genero { get; set; }
        public string tipoInterpretacion { get; set; }
        public string idioma { get; set; }
        public string pais { get; set; }
        public string disquera { get; set; }
        public string nombreDisco { get; set; }
        public string anio { get; set; }
        public string nombreArchivoDescarga { get; set; }
        public string nombreArchivoPrevisualizacion { get; set; }
        public string monto { get; set; }

        public List<Musica> traerMusicas()
        {
            DataSet datos = Memoria.logica_database
             .queryConRetornoDeDatos_sinParametros(
             Memoria.logica_database.stringDeConexion_baseDeDatos_principal,
             "sp_musica_leer"
             );

            if (datos.Tables[0].Rows.Count > 0)
            {
                List<Musica> lista_musica = new List<Musica>();
                for (int i = 0; i < datos.Tables[0].Rows.Count; i++)
                {
                    lista_musica.Add(
                        new Musica
                            (
                            Encriptacion.desencriptar(datos.Tables[0].Rows[i]["ID"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["nombre"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["genero"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["tipoInterpretacion"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["idioma"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["pais"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["disquera"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["nombreDisco"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["anio"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["nombreArchivoDescarga"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["nombreArchivoPrevisualizacion"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["monto"].ToString())
                            )
                        );
                }
                return lista_musica;
            }
            else
            {
                return null;
            }
        }

        public void guardarMusica(Musica musica)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_musica_crear";

            Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(musica));
        }

        public void actualizarMusica(Musica musica)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_musica_actualizar";

            Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(musica));
        }

        public void eliminarMusica(string id)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_musica_eliminar";

            string[] parametros = { "ID" };
            string[] valores = { id };

            Memoria.logica_database
               .querySimple(stringDeConexion
               , nombre_storedProcedure
               , parametros
               , valores);
        }

        public Musica() { }

        public Musica(string id
            , string nombre
            , string genero
            , string tipoInterpretacion
            , string idioma
            , string pais
            , string disquera
            , string nombreDisco
            , string anio
            , string nombreArchivoDescarga
            , string nombreArchivoPrevisualizacion
            , string monto)
        {
            this.id = id;
            this.nombre = nombre;
            this.genero = genero;
            this.tipoInterpretacion = tipoInterpretacion;
            this.idioma = idioma;
            this.pais = pais;
            this.disquera = disquera;
            this.nombreDisco = nombreDisco;
            this.anio = anio;
            this.nombreArchivoDescarga = nombreArchivoDescarga;
            this.nombreArchivoPrevisualizacion = nombreArchivoPrevisualizacion;
            this.monto = monto;
        }

        string[] parametros = {
                "ID"
                ,"nombre"
                , "genero"
                , "tipoInterpretacion"
                , "idioma"
                , "pais"
                , "disquera"
                , "nombreDisco"
                , "anio"
                , "nombreArchivoDescarga"
                , "nombreArchivoPrevisualizacion"
                , "monto"};

        private string[] return_valores(Musica musica)
        {
            string[] valores = {
                musica.id
                ,musica.nombre
                ,musica.genero
                ,musica.tipoInterpretacion
                ,musica.idioma
                ,musica.pais
                ,musica.disquera
                ,musica.nombreDisco
                ,musica.anio
                ,musica.nombreArchivoDescarga
                ,musica.nombreArchivoPrevisualizacion
                ,musica.monto
            };
            return valores;
        }
    }
}
