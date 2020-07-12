using System.Collections.Generic;
using System.Data;
using BLL.Logica;

namespace BLL.Objeto
{
    public class Admin
    {
        public string id { get; set; }
        public string nombreUsuario { get; set; }
        public string contrasenia { get; set; }
        public string correoElectronico { get; set; }
        public string preguntaSeguridad { get; set; }
        public string respuestaSeguridad { get; set; }
        public bool adminMaestro { get; set; }
        public bool adminSeguridad { get; set; }
        public bool adminMantenimiento { get; set; }
        public bool adminConsultas { get; set; }

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
                            , Tareas.conversor_booleando(Encriptacion.desencriptar(datos.Tables[0].Rows[i]["adminMaestro"].ToString()))
                            , Tareas.conversor_booleando(Encriptacion.desencriptar(datos.Tables[0].Rows[i]["adminSeguridad"].ToString()))
                            , Tareas.conversor_booleando(Encriptacion.desencriptar(datos.Tables[0].Rows[i]["adminMantenimiento"].ToString()))
                            , Tareas.conversor_booleando(Encriptacion.desencriptar(datos.Tables[0].Rows[i]["adminConsultas"].ToString()))
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

        public void actualizarAdmin_baseDeDatos(Admin admin)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_admin_actualizar";

            Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(admin));
        }

        public void borrarAdmin_baseDeDatos(string id)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_admin_eliminar";

            string[] parametros = {"ID"};
            string[] valores = { id };

            Memoria.logica_database
               .querySimple(stringDeConexion
               , nombre_storedProcedure
               , parametros
               , valores);
        }

        public void insertarAdmin_baseDeDatos(Admin admin)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_admin_crear";

            // Envia los datos para ser guardados en la base de datos.
            Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(admin));
        }

        public Admin()
        {

        }

        public Admin(string id
            , string nombreUsuario
            , string contrasenia
            , string correoElectronico
            , string preguntaSeguridad
            , string respuestaSeguridad
            , bool adminMaestro
            , bool adminSeguridad
            , bool adminMantenimiento
            , bool adminConsultas)
        {
            this.id = id;
            this.nombreUsuario = nombreUsuario;
            this.contrasenia = contrasenia;
            this.correoElectronico = correoElectronico;
            this.preguntaSeguridad = preguntaSeguridad;
            this.respuestaSeguridad = respuestaSeguridad;
            this.adminMaestro = adminMaestro;
            this.adminSeguridad = adminSeguridad;
            this.adminMantenimiento = adminMantenimiento;
            this.adminConsultas = adminConsultas;
        }

        string[] parametros = {
                "ID"
                ,"nombreUsuario"
                , "contrasenia"
                , "correoElectronico"
                , "preguntaSeguridad"
                , "respuestaSeguridad"
                , "adminMaestro"
                , "adminSeguridad"
                , "adminMantenimiento"
                , "adminConsultas" };

        // Crea un array string con los valores admin que
        // se hayan pasado al metodo como input
        private string[] return_valores(Admin admin)
        {
            string[] valores = {
                admin.id,
                admin.nombreUsuario,
                admin.contrasenia,
                admin.correoElectronico,
                admin.preguntaSeguridad,
                admin.respuestaSeguridad,
                Tareas.conversor_booleandoInverso(admin.adminMaestro),
                Tareas.conversor_booleandoInverso(admin.adminSeguridad),
                Tareas.conversor_booleandoInverso(admin.adminMantenimiento),
                Tareas.conversor_booleandoInverso(admin.adminConsultas)};
            return valores;
        }
    }
}
