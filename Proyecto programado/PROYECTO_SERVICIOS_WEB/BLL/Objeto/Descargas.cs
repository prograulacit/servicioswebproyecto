using BLL.Logica;
using System.Collections.Generic;
using System.Data;
namespace BLL.Objeto
{
    public class Descargas
    {
        public string ID { get; set; }
        public string IDconsecutivo { get; set; }
        public string nombre { get; set; }
        public string cantidad { get; set; }
        public string fechaYHora { get; set; }
        public string tipo { get; set; }

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
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["nombre"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["cantidad"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["fechaYHora"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["tipo"].ToString())
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

        public int traerContadorDescargaConsecutivo(string idConsecutivo)
        {
            List<Descargas> lista_descargas = traerDescargas();
            int contador = 0;

            if (lista_descargas != null )
            {
                for (int i = 0; i < lista_descargas.Count; i++)
                {
                    if (lista_descargas[i].IDconsecutivo == idConsecutivo)
                    {
                        contador++;
                    }
                }
            }
            return contador;
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

        public Descargas(string iD, string iDconsecutivo, string Nombre, string Cantidad, string FechaYHora, string Tipo)
        {
            ID = iD;
            IDconsecutivo = iDconsecutivo;
            nombre = Nombre;
            cantidad = Cantidad;
            fechaYHora = FechaYHora;
            tipo = Tipo;
        }

        string[] parametros = {
                "ID"
                ,"IDconsecutivo"
                ,"nombre"
                ,"cantidad"
                ,"fechaYHora"
                ,"tipo"};

        private string[] return_valores(Descargas descargas)
        {
            string[] valores = {
                descargas.ID,
                descargas.IDconsecutivo,
                descargas.nombre,
                descargas.cantidad,
                descargas.fechaYHora,
                descargas.tipo
                };
            return valores;
        }
    }
}
