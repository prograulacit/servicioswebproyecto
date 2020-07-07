using System;
using BLL;

namespace DATABASE_HANDLER
{
    public class Tareas
    {
        public static void crear_admin_maestro()
        {
            // Parametros y valores del consecutivo.
            string[] parametrosConsecutivo =
                {"ID","tipoConsecutivo", "descripcion", "prefijo", "rangoInicial", "rangoFinal" };
            string[] valoresConsecutivo = {
                BLL.Logica.Encriptacion.encriptar("1"),
                BLL.Logica.Encriptacion.encriptar("admin"),
                BLL.Logica.Encriptacion.encriptar("desc aqui"),
                BLL.Logica.Encriptacion.encriptar("prefijo aqui"),
                BLL.Logica.Encriptacion.encriptar("0"),
                BLL.Logica.Encriptacion.encriptar("0") };

            // Parametros y valores del admin nuevo.
            string[] parametrosAdmin =
                {"ID","nombreUsuario", "contrasenia", "correoElectronico"
                , "preguntaSeguridad", "respuestaSeguridad", "adminMaestro", "adminSeguridad"
                , "adminMantenimiento", "adminConsultas" };
            string[] valoresAdmin = {
                BLL.Logica.Encriptacion.encriptar("1"),
                BLL.Logica.Encriptacion.encriptar("admin"),
                BLL.Logica.Encriptacion.encriptar("admin123"),
                BLL.Logica.Encriptacion.encriptar("admin@serweb.com"),
                BLL.Logica.Encriptacion.encriptar("pregunta"),
                BLL.Logica.Encriptacion.encriptar("respuesta"),
                BLL.Logica.Encriptacion.encriptar("true"),
                BLL.Logica.Encriptacion.encriptar("false"),
                BLL.Logica.Encriptacion.encriptar("false"),
                BLL.Logica.Encriptacion.encriptar("false")};

            DAL.DBLogica.querySimple(
                DAL.DBLogica.stringDeConexion_baseDeDatos_principal,
                "sp_consecutivo_crear",
                parametrosConsecutivo, valoresConsecutivo);

            DAL.DBLogica.querySimple(
                DAL.DBLogica.stringDeConexion_baseDeDatos_principal,
                "sp_admin_crear",
                parametrosAdmin, valoresAdmin);

            Console.WriteLine("Admin maestro creado. OK.");
        }
    }
}
