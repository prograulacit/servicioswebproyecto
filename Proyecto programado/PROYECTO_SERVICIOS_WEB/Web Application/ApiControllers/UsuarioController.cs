using System.Collections.Generic;
using System.Web.Http;
using BLL.Objeto;
using BLL.Logica;
namespace Web_Application.ApiControllers
{
    public class UsuarioController : ApiController
    {
        // GET: api/Usuario
        public IEnumerable<Usuario> Get()
        {
            Usuario usuario = new Usuario();
            List<Usuario> lista_usuarios = usuario.traerUsuarios();
            return lista_usuarios;
        }

        // GET: api/Usuario/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Usuario
        public string Post([FromBody]Usuario usuario)
        {
            #region Plantilla Postman -> Abrir para ver.
            //{
            //    "nombre":"Antonio",
            //    "primerApellido": "Tenorio",
            //    "segundoApellido":"Parra",
            //    "correoElectronico":"antepa@e-corp-usa.com",
            //    "nombreUsuario":"antonio93",
            //    "contrasenia":"123"
            //}
            #endregion
            string nuevo_id = Tareas.generar_nuevo_id_para_un_registro();
            Usuario usuario_temp = new Usuario(
                nuevo_id
                , usuario.nombre
                , usuario.primerApellido
                , usuario.segundoApellido
                , usuario.correoElectronico
                , usuario.nombreUsuario
                , usuario.contrasenia
                );

            usuario_temp.guardarNuevoUsuario(usuario_temp);
            return "Usuario " + nuevo_id + " registrado.";
        }

        // PUT: api/Usuario/5
        public string Put([FromBody]Usuario usuario)
        {
            #region Plantilla Postman -> Abrir para ver
            //{
            //    "ID":"idDelUsuario",
            //    "nombre":"Antonio",
            //    "primerApellido": "Tenorio",
            //    "segundoApellido":"Parra",
            //    "correoElectronico":"antepa@e-corp-usa.com",
            //    "nombreUsuario":"antonio93",
            //    "contrasenia":"123"
            //}
            #endregion
            Usuario usuario_temp = new Usuario(
                usuario.id
                , usuario.nombre
                , usuario.primerApellido
                , usuario.segundoApellido
                , usuario.correoElectronico
                , usuario.nombreUsuario
                , usuario.contrasenia
                );

            usuario_temp.actualizarUsuario(usuario_temp);
            return "Usuario " + usuario.id + " actualizado.";
        }

        // DELETE: api/Usuario/5
        public string Delete(string id)
        {
            Usuario usuario = new Usuario();
            usuario.eliminarUsuario(id);
            return "Usuario " + id + " eliminado.";
        }
    }
}
