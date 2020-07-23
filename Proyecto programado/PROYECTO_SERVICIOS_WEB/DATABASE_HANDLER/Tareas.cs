using BLL.Objeto;
using System;

namespace DATABASE_HANDLER
{
    public class Tareas
    {
        // Exporta objeto DBLogica. La encriptación de la base de datos está determinada segun la variable
        // datos_encriptados el cual se encuentra en BLL/Logica/Memoria.cs
        DAL.DBLogica database_logica = new DAL.DBLogica(BLL.Logica.Memoria.datos_encriptados);

        public void crear_admin_maestro()
        {
            Console.WriteLine("Secuencia -> Crear admin maestro -> Iniciada");
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
                "adm1",
                "adminMaestro",
                "admin",
                "admin@e-descargas.com",
                "Respuesta de pregunta de seguridad:respuesta",
                "respuesta",
                "true",
                "false",
                "false",
                "false"};
            database_logica.querySimple(
                database_logica.stringDeConexion_baseDeDatos_principal,
                "sp_admin_crear",
                parametrosAdmin, valoresAdmin);

            Console.WriteLine("Admin maestro creado. OK.");
            Console.WriteLine("Secuencia -> Crear admin maestro -> Terminada");
        }

        // Crea nuevos admins para el sistema.
        public void crear_admin(string id
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

        // Crea los registros de Transaccion, Admin, Pelicula, Musica y Libro.
        public void crear_registros_de_consecutivos()
        {
            Console.WriteLine("Secuencia -> Crear consecutivos -> Iniciada");
            // Se utiliza un ID personalizado para efectos de indentifiación más rápida.

            // Parametros y valores del registro de consecutivo admin.
            string[] parametros_admin =
                {"ID"
                ,"tipoConsecutivo"
                , "descripcion"
                , "prefijo"
                , "rangoInicial"
                , "rangoFinal" };
            string[] valores_admin = {
                "admin"
                ,"admin"
                ,"5" // 5 porqué ya existen 4 admins: maestro, seguridad, mantenimiento y consultas.
                ,"adm"
                ,"0"
                ,"200" };

            database_logica.querySimple(
                database_logica.stringDeConexion_baseDeDatos_principal,
                "sp_consecutivo_crear",
                parametros_admin, valores_admin);
            Console.WriteLine("Consecutivo admin creado. OK");

            // Parametros y valores del registro de consecutivo transaccion.
            string[] parametros_transaccion =
                {"ID"
                ,"tipoConsecutivo"
                , "descripcion"
                , "prefijo"
                , "rangoInicial"
                , "rangoFinal" };
            string[] valores_transaccion = {
                "transaccion"
                ,"transaccion"
                ,"1"
                ,"tra"
                ,"0"
                ,"200" };

            database_logica.querySimple(
                database_logica.stringDeConexion_baseDeDatos_principal,
                "sp_consecutivo_crear",
                parametros_transaccion, valores_transaccion);
            Console.WriteLine("Consecutivo transaccion creado. OK");

            // Parametros y valores del registro de consecutivo pelicula.
            string[] parametros_pelicula =
                {"ID"
                ,"tipoConsecutivo"
                , "descripcion"
                , "prefijo"
                , "rangoInicial"
                , "rangoFinal" };
            string[] valores_pelicula = {
                "pelicula"
                ,"pelicula"
                ,"1"
                ,"pel"
                ,"0"
                ,"200" };

            database_logica.querySimple(
                database_logica.stringDeConexion_baseDeDatos_principal,
                "sp_consecutivo_crear",
                parametros_pelicula, valores_pelicula);
            Console.WriteLine("Consecutivo pelicula creado. OK");

            // Parametros y valores del registro de consecutivo musica.
            string[] parametros_musica =
                {"ID"
                ,"tipoConsecutivo"
                , "descripcion"
                , "prefijo"
                , "rangoInicial"
                , "rangoFinal" };
            string[] valores_musica = {
                "musica"
                ,"musica"
                ,"1"
                ,"mus"
                ,"0"
                ,"200" };

            database_logica.querySimple(
                database_logica.stringDeConexion_baseDeDatos_principal,
                "sp_consecutivo_crear",
                parametros_musica, valores_musica);
            Console.WriteLine("Consecutivo musica creado. OK");

            // Parametros y valores del registro de consecutivo libro.
            string[] parametros_libro =
                {"ID"
                ,"tipoConsecutivo"
                , "descripcion"
                , "prefijo"
                , "rangoInicial"
                , "rangoFinal" };
            string[] valores_libro = {
                "libro"
                ,"libro"
                ,"1"
                ,"lib"
                ,"0"
                ,"200" };

            database_logica.querySimple(
                database_logica.stringDeConexion_baseDeDatos_principal,
                "sp_consecutivo_crear",
                parametros_libro, valores_libro);
            Console.WriteLine("Consecutivo libro creado. OK");
            Console.WriteLine("Secuencia -> Crear consecutivos -> Terminada");
        }

        public void crear_parametros()
        {
            Console.WriteLine("Secuencia -> Parametros iniciada.");
            Parametros p = new Parametros(
                   "par"
                , "PlaceholderRutaPreLibros"
                , "PlaceholderRutaLibros"
                , "PlaceholderRutaPrePeliculas"
                , "PlaceholderRutaPeliculas"
                , "PlaceholderRutaPreMusica"
                , "PlaceholderRutaMusica"
                );
            p.crearRegistroParametros(p);
            Console.WriteLine("Secuencia -> Parametros termianda. OK");
        }

        public void crear_usuario()
        {
            Console.WriteLine("Secuencia -> Crear usuario iniciada.");
            Usuario u = new Usuario("firstUser"
                ,"Juan"
                ,"Mora"
                ,"Tenorio"
                ,"juanMoraTenorio@gmail.com"
                , "user","password"
                );
            u.guardarNuevoUsuario(u);
            Console.WriteLine("Secuencia -> Crear usuario terminada.OK.");
        }
    }
}
