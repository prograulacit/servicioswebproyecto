using System.Collections.Generic;
using System.Web.Http;
using BLL.Objeto;
using BLL.Logica;

namespace Web_Application.ApiControllers
{
    public class AdminController : ApiController
    {
        // GET: api/Admin
        public IEnumerable<Admin> Get()
        {
            Admin admin = new Admin();
            List<Admin> lista_admins = admin.traerAdmins();
            return lista_admins;
        }

        // GET: api/Admin/5
        public string Get(string id)
        {
            return "Not working yet";
        }

        // POST: api/Admin
        public string Post([FromBody]Admin admin)
        {
            #region Plantilla Postman -> Abrir para ver.
            //{
            //    "nombreUsuario":"admin_post",
            //    "contrasenia": "admin",
            //    "correoElectronico":"admin_post@e-descargas.com",
            //    "preguntaSeguridad":"pregunta",
            //    "respuestaSeguridad":"respuesta",
            //    "adminMaestro":true,
            //    "adminSeguridad":false,
            //    "adminMantenimiento":false,
            //    "adminConsultas":false
            //}
            #endregion

            Consecutivo consecutivo = new Consecutivo();

            // Registro espejo del registro requerido guardado en la base de datos.
            Consecutivo registro_de_consecutivo =
                consecutivo.traerConsecutivo_registroReflejadoEnDB("admin");

            // Se actualiza el id de la pelicula como prefijo+numConsecuvito.
            // Ejemplo: ele4 .
            admin.id =
                registro_de_consecutivo.prefijo + (int.Parse(registro_de_consecutivo.descripcion) + 1);

            // Aumentamos el valor "descripcion" del consecutivo en 1.
            string valorDescripcionAumentadoEn1 =
                Tareas.aumentarColumnaDeConsecutivoEn1(registro_de_consecutivo);
            registro_de_consecutivo.descripcion = valorDescripcionAumentadoEn1;

            // Guardamos el nuevo registro en la base de datos.
            admin.registrarAdmin(admin);

            // Actualizamos el consecutivo en la base de datos.
            consecutivo.actualizarConsecutivo_baseDeDatos(registro_de_consecutivo);

            return "Admin " + admin.id + " agregado.";
        }

        // PUT: api/Admin/5
        public string Put([FromBody]Admin admin)
        {
            #region Plantilla Postman -> Abrir para ver
            /*{
                "ID":"idplaceholder",
                "nombreUsuario":"admin_editado",
                "contrasenia": "editado",
                "correoElectronico":"editado",
                "preguntaSeguridad":"editado",
                "respuestaSeguridad":"editado",
                "adminMaestro":true,
                "adminSeguridad":true,
                "adminMantenimiento":true,
                "adminConsultas":true
            }*/
            #endregion

            admin.actualizarAdmin(admin);

                if (Memoria.sesionAdminDatos.id == admin.id)
                {
                    // El admin que se está editando por REST API es el mismo
                    // que esta logeado por medio de interfaz de usuario.
                    // Por lo tanto actualizamos los datos.
                    Memoria.sesionAdminDatos.nombreUsuario = admin.nombreUsuario;
                    Memoria.sesionAdminDatos.contrasenia = admin.contrasenia;
                    Memoria.sesionAdminDatos.correoElectronico = admin.correoElectronico;
                    Memoria.sesionAdminDatos.preguntaSeguridad = admin.preguntaSeguridad;
                    Memoria.sesionAdminDatos.respuestaSeguridad = admin.respuestaSeguridad;
                    Memoria.sesionAdminDatos.adminMaestro = admin.adminMaestro;
                    Memoria.sesionAdminDatos.adminSeguridad = admin.adminSeguridad;
                    Memoria.sesionAdminDatos.adminMantenimiento = admin.adminMantenimiento;
                    Memoria.sesionAdminDatos.adminConsultas = admin.adminConsultas;
                }
            
            return "Admin " + admin.id + " actualizado.";
        }

        // DELETE: api/Admin/5
        public string Delete(string id)
        {
            // Para eliminar en Postman ->
            // Seleccionar Api DELETE
            // Seleccionar Params
            // Escribir una key como "id"
            // Escribir value como el ID guardado en la base de datos.
            // Pulsar Send.
            Admin admin = new Admin();

            if (Memoria.sesionAdminDatos.id == id)
            {
                // El admin que se está eliminando por REST API es el mismo
                // que esta logeado por medio de interfaz de usuario.
                // Por lo tanto terminamos la sesión de usuario.
                admin.deslogeo();
            }

            admin.eliminarAdmin(id);

            // Disminuimos el valor "descripcion" del consecutivo en 1.
            //Consecutivo consecutivo = new Consecutivo();
            //Consecutivo registro_de_consecutivo = consecutivo.traerConsecutivo_registroReflejadoEnDB("admin");
            //string valorDescripcionDisminuidoEn1 = Tareas.disminuirColumnaDeConsecutivoEn1(registro_de_consecutivo);
            //registro_de_consecutivo.descripcion = valorDescripcionDisminuidoEn1;
            //consecutivo.actualizarConsecutivo_baseDeDatos(registro_de_consecutivo);

            return "Admin " + id + " eliminado.";
        }
    }
}
