using DAL;
using BLL.Logica;
using BLL.Objeto;
using System;

namespace DATABASE_HANDLER
{
    public class Funciones
    {
        // Exporta objeto DBLogica de DAL. La encriptación de la base de datos está determinada segun la variable
        // datos_encriptados el cual se encuentra en BLL/Logica/Memoria.cs
        public static DBLogica database_logica = new DBLogica(Memoria.datos_encriptados);

        /// <summary>
        /// Crea un nuevo administrador y lo guarda en la base de datos.
        /// </summary>
        public static void crear_admin(string id
            , string nombreUsuario
            , string contrasenia
            , string correoElectronico
            , string preguntaSeguridad
            , string respuestaSeguridad
            , string adminMaestro
            , string adminSeguridad
            , string adminMantenimiento
            , string adminConsultas)
        {
            Console.WriteLine("Secuencia -> Crear admin nuevo -> Iniciada");
            // Parametros y valores del admin nuevo.
            string[] parametrosAdmin =
                {"ID"
                ,"nombreUsuario"
                , "contrasenia"
                , "correoElectronico"
                , "preguntaSeguridad"
                , "respuestaSeguridad"
                , "adminMaestro"
                , "adminSeguridad"
                , "adminMantenimiento"
                , "adminConsultas" };
            string[] valoresAdmin = {
                id,
                nombreUsuario,
                contrasenia,
                correoElectronico,
                preguntaSeguridad,
                respuestaSeguridad,
                adminMaestro,
                adminSeguridad,
                adminMantenimiento,
                adminConsultas};
            database_logica.querySimple(
                database_logica.stringDeConexion_baseDeDatos_principal,
                "sp_admin_crear",
                parametrosAdmin, valoresAdmin);

            Console.WriteLine("Admin nuevo creado. OK.");
            Console.WriteLine("Secuencia -> Crear nuevo maestro -> Terminada");
        }

        /// <summary>
        /// Crea un nuevo usuario y lo guarda en la base de datos.
        /// a partir del metodo. Si se establece id, se concatena id + 
        /// Tareas.generar_nuevo_id_para_un_registro().</param>
        /// </summary>
        /// <param name="id">Si es escrito "vacio" se generara un id
        public static void crear_usuario(string id
            , string nombre
            , string apellido_paterno
            , string apellido_materno
            , string correo
            , string username
            , string password)
        {
            Console.WriteLine("Secuencia -> Crear usuario iniciada.");

            string id_resultado = "";

            if (!id.Equals("vacio"))
            {
                id_resultado = id + BLL.Logica.Tareas.generar_nuevo_id_para_un_registro();
            }
            else
            {
                id_resultado = BLL.Logica.Tareas.generar_nuevo_id_para_un_registro();
            }

            Usuario u = new Usuario(id_resultado
                , nombre
                , apellido_paterno
                , apellido_materno
                , correo
                , username, password
                );
            u.guardarNuevoUsuario(u);
            Console.WriteLine("Secuencia -> Crear usuario terminada.OK.");
        }
    }
}
