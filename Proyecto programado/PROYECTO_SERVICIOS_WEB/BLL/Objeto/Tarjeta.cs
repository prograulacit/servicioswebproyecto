using BLL.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Objeto
{
    public class Tarjeta
    {
        public string id { get; set; }
        public string usuarioId { get; set; }
        public string numeroTarjeta { get; set; }
        public string mesExpiracion { get; set; }
        public string anioExpiracion { get; set; }
        public string cvv { get; set; }
        public string monto { get; set; }
        public string tipo { get; set; }
        public string tarjetaAUsar { get; set; }

        public List<Admin> traerAdmins()
        {
            // Se traen todos los datos de la base de datos cono objeto DataSet.
            DataSet datos = Memoria.logica_database
                .queryConRetornoDeDatos_sinParametros(
                Memoria.logica_database.stringDeConexion_baseDeDatos_principal,
                "sp_admin_traer"
                );

            // Si no hay registros se retorna false.
            if (datos.Tables[0].Rows.Count > 0)
            {
                // Se crea una lista de admins.
                List<Admin> lista_admins = new List<Admin>();
                // Se recorren los datos del DataSet.
                for (int i = 0; i < datos.Tables[0].Rows.Count; i++)
                {
                    // Se agregan objetos Admin a la lista.
                    lista_admins.Add(
                        new Admin
                            (
                            Encriptacion.desencriptar(datos.Tables[0].Rows[i]["ID"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["nombreUsuario"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["contrasenia"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["correoElectronico"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["preguntaSeguridad"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["respuestaSeguridad"].ToString())
                            , Tareas.conversor_booleano(Encriptacion.desencriptar(datos.Tables[0].Rows[i]["adminMaestro"].ToString()))
                            , Tareas.conversor_booleano(Encriptacion.desencriptar(datos.Tables[0].Rows[i]["adminSeguridad"].ToString()))
                            , Tareas.conversor_booleano(Encriptacion.desencriptar(datos.Tables[0].Rows[i]["adminMantenimiento"].ToString()))
                            , Tareas.conversor_booleano(Encriptacion.desencriptar(datos.Tables[0].Rows[i]["adminConsultas"].ToString()))
                            )
                        );
                }
                // Se retorna la lista.
                return lista_admins;
            }
            else
            {
                return null;
            }
        }

        public void actualizarAdmin(Admin admin)
        {
            //string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            //string nombre_storedProcedure = "sp_admin_actualizar";

            //Memoria.logica_database
            //    .querySimple(stringDeConexion
            //    , nombre_storedProcedure
            //    , this.parametros
            //    , return_valores(admin));
        }

        public void eliminarAdmin(string id)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_admin_eliminar";

            string[] parametros = { "ID" };
            string[] valores = { id };

            Memoria.logica_database
               .querySimple(stringDeConexion
               , nombre_storedProcedure
               , parametros
               , valores);
        }

        public void registrarAdmin(Admin admin)
        {
            //string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            //string nombre_storedProcedure = "sp_admin_crear";

            //// Envia los datos para ser guardados en la base de datos.
            //Memoria.logica_database
            //    .querySimple(stringDeConexion
            //    , nombre_storedProcedure
            //    , this.parametros
            //    , return_valores(admin));
        }

        public Tarjeta() { }

        public Tarjeta(string id
            , string usuarioId
            , string numeroTarjeta
            , string mesExpiracion
            , string anioExpiracion
            , string cvv
            , string monto
            , string tipo
            , string tarjetaAUsar)
        {
            this.id = id;
            this.usuarioId = usuarioId;
            this.numeroTarjeta = numeroTarjeta;
            this.mesExpiracion = mesExpiracion;
            this.anioExpiracion = anioExpiracion;
            this.cvv = cvv;
            this.monto = monto;
            this.tipo = tipo;
            this.tarjetaAUsar = tarjetaAUsar;
        }
        string[] parametros = {
                "ID"
                ,"usuarioID"
                , "numeroTarjeta"
                , "mesExpiracion"
                , "cvv"
                , "monto"
                , "tipo"
                , "tarjetaAUsar"
                };

        private string[] return_valores(Tarjeta tarjeta)
        {
            string[] valores = {
                tarjeta.id
                ,tarjeta.usuarioId
                ,tarjeta.numeroTarjeta
                ,tarjeta.mesExpiracion
                ,tarjeta.cvv
                ,tarjeta.monto
                ,tarjeta.tipo
                ,tarjeta.tarjetaAUsar};
            return valores;
        }
    }
}
