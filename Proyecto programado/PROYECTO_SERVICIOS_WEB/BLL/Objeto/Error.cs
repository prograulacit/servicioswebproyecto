using System.Collections.Generic;
using System.Data;
using BLL.Logica;

namespace BLL.Objeto
{
    public class Error
    {
        public string id { get; set; }
        public string fechaYHora{ get; set; }
        public string idUsuario { get; set; }
        public string mensajeDeError { get; set; }

        public List<Error> traerErrores()
        {
            DataSet datos = Memoria.logica_database
              .queryConRetornoDeDatos_sinParametros(
              Memoria.logica_database.stringDeConexion_baseDeDatos_principal,
              "sp_error_leer"
              );

            if (datos.Tables[0].Rows.Count > 0)
            {
                List<Error> lista_errores = new List<Error>();
                for (int i = 0; i < datos.Tables[0].Rows.Count; i++)
                {
                    lista_errores.Add(
                        new Error
                            (
                            Encriptacion.desencriptar(datos.Tables[0].Rows[i]["ID"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["fechaYHora"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["idUsuario"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["mensajeDeError"].ToString())
                            )
                        );
                }
                return lista_errores;
            }
            else
            {
                return null;
            }
        }

        public void guardarError(Error error)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_error_crear";

            Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(error));
        }

        public void actualizarError(Error error)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_error_actualizar";

            Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(error));
        }

        public void eliminarError(string id)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_error_eliminar";

            string[] parametros = { "ID" };
            string[] valores = { id };

            Memoria.logica_database
               .querySimple(stringDeConexion
               , nombre_storedProcedure
               , parametros
               , valores);
        }

        public Error(string id, string fechaYHora, string idUsuario, string mensajeDeError)
        {
            this.id = id;
            this.fechaYHora = fechaYHora;
            this.idUsuario = idUsuario;
            this.mensajeDeError = mensajeDeError;
        }

        public Error()
        {

        }

        string[] parametros = {
                "ID"
                ,"fechaYHora"
                , "idUsuario"
                , "mensajeDeError"};

        private string[] return_valores(Error error)
        {
            string[] valores = {
                error.id,
                error.fechaYHora,
                error.idUsuario,
                error.mensajeDeError};
            return valores;
        }
    }
}
