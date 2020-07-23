using BLL.Logica;
using System.Collections.Generic;
using System.Data;
namespace BLL.Objeto
{
    public class Descargas
    {
        public string ID { get; set; }
        public string IDconsecutivo { get; set; }
        public string IDusuario { get; set; }

        public List<Descargas> traerDescargas()
        {
            DataSet datos = Memoria.logica_database
                .queryConRetornoDeDatos_sinParametros(
                Memoria.logica_database.stringDeConexion_baseDeDatos_principal,
                "sp_descargas_leer"
                );

            if (datos.Tables[0].Rows.Count > 0)
            {
                List<Descargas> lista_descargas = new List<Descargas>();

                for (int i = 0; i < datos.Tables[0].Rows.Count; i++)
                {
                    lista_descargas.Add(
                        new Descargas
                            (
                            Encriptacion.desencriptar(datos.Tables[0].Rows[i]["ID"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["IDconsecutivo"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["IDusuario"].ToString())
                            )
                        );
                }
                return lista_descargas;
            }
            else
            {
                return null;
            }
        }

        public void crearRegistroDescarga(Descargas descargas)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_descargas_crear";

            Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(descargas));
        }

        public void actualizarRegistroDescarga(Descargas descargas)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_descargas_actualizar";

            Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(descargas));
        }

        public void eliminarRegistroDescarga(string id)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_descargas_eliminar";

            string[] parametros = { "ID" };
            string[] valores = { id };

            Memoria.logica_database
               .querySimple(stringDeConexion
               , nombre_storedProcedure
               , parametros
               , valores);
        }

        public Descargas() {}

        public Descargas(string iD, string iDconsecutivo, string iDusuario)
        {
            ID = iD;
            IDconsecutivo = iDconsecutivo;
            IDusuario = iDusuario;
        }

        string[] parametros = {
                "ID"
                ,"IDconsecutivo"
                , "IDusuario" };

        private string[] return_valores(Descargas descargas)
        {
            string[] valores = {
                descargas.ID,
                descargas.IDconsecutivo,
                descargas.IDusuario
                };
            return valores;
        }
    }
}
