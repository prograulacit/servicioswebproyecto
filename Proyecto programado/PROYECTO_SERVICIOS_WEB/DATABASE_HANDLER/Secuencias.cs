using BLL.Objeto;
using System;

namespace DATABASE_HANDLER
{
    public class Secuencias
    {
        public void crearAdmin_maestro()
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
            Funciones.database_logica.querySimple(
                Funciones.database_logica.stringDeConexion_baseDeDatos_principal,
                "sp_admin_crear",
                parametrosAdmin, valoresAdmin);

            Console.WriteLine("Admin maestro creado. OK.");
            Console.WriteLine("Secuencia -> Crear admin maestro -> Terminada");
        }

        /// <summary>
        /// Crea los registros de Transaccion, Admin, Pelicula, Musica y Libro.
        /// </summary>
        public void crearRegistros_consecutivo()
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
                ,"4"
                ,"adm"
                ,"0"
                ,"200" };

            Funciones.database_logica.querySimple(
                Funciones.database_logica.stringDeConexion_baseDeDatos_principal,
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
                ,"0"
                ,"tra"
                ,"0"
                ,"200" };

            Funciones.database_logica.querySimple(
                Funciones.database_logica.stringDeConexion_baseDeDatos_principal,
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
                ,"0"
                ,"pel"
                ,"0"
                ,"200" };

            Funciones.database_logica.querySimple(
                Funciones.database_logica.stringDeConexion_baseDeDatos_principal,
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
                ,"0"
                ,"mus"
                ,"0"
                ,"200" };

            Funciones.database_logica.querySimple(
                Funciones.database_logica.stringDeConexion_baseDeDatos_principal,
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
                ,"0"
                ,"lib"
                ,"0"
                ,"200" };

            Funciones.database_logica.querySimple(
                Funciones.database_logica.stringDeConexion_baseDeDatos_principal,
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

        // Crea los admins de seguridad, mantenimiento y consultas.
        public void crearAdmin_seguridadMantenimientoConsultas()
        {
            // Crear admin de seguridad.
            Funciones.crear_admin("adm2"
                , "adminSeguridad"
                , "admin"
                , "adminSeguridad@e-shop.com"
                , "Respuesta de pregunta de seguridad:respuesta"
                , "respuesta"
                , "false"
                , "true"
                , "false"
                , "false");
            // Crear admin de mantenimiento.
            Funciones.crear_admin("adm3"
                , "adminMantenimiento"
                , "admin"
                , "adminMantenimiento@e-shop.com"
                , "Respuesta de pregunta de seguridad:respuesta"
                , "respuesta"
                , "false"
                , "false"
                , "true"
                , "false");
            // Crear admin de consultas.
            Funciones.crear_admin("adm4"
                , "adminConsultas"
                , "admin"
                , "adminConsultas@e-shop.com"
                , "Respuesta de pregunta de seguridad:respuesta"
                , "respuesta"
                , "false"
                , "false"
                , "false"
                , "true");
        }

        public void crearUsuarios()
        {
            Funciones.crear_usuario("juanid", "Juan", "Mora", "Tenorio", "juantenorio@e-corp.usa", "user", "password");
            Funciones.crear_usuario("cameronid", "Cameron", "Hidalgo", "Tenorio", "cameronhidalgo@e-corp.usa", "cameron", "password");
            Funciones.crear_usuario("elliotid", "Elliot", "Alderson", "Seppion", "elliotalderson@e-corp.usa", "elliot", "password");
            Funciones.crear_usuario("doloresid", "Dolores", "Haze", "Moggly", "doloreshaze@e-corp.usa", "dolores", "password");
        }

    }
}
