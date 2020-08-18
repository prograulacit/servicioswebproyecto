using BLL.Logica;
using System;
using System.Collections.Generic;
using System.Data;

namespace BLL.Objeto
{
    public class Usuario
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string correoElectronico { get; set; }
        public string nombreUsuario { get; set; }
        public string contrasenia { get; set; }

        public List<Usuario> traerUsuarios()
        {
            DataSet datos = Memoria.logica_database
              .queryConRetornoDeDatos_sinParametros(
              Memoria.logica_database.stringDeConexion_baseDeDatos_principal,
              "sp_usuario_leer"
              );

            if (datos.Tables[0].Rows.Count > 0)
            {
                List<Usuario> lista_usuarios = new List<Usuario>();
                for (int i = 0; i < datos.Tables[0].Rows.Count; i++)
                {
                    lista_usuarios.Add(
                        new Usuario
                            (
                            Desencriptar.desencriptar(datos.Tables[0].Rows[i]["ID"].ToString())
                            , Desencriptar.desencriptar(datos.Tables[0].Rows[i]["nombre"].ToString())
                            , Desencriptar.desencriptar(datos.Tables[0].Rows[i]["primerApellido"].ToString())
                            , Desencriptar.desencriptar(datos.Tables[0].Rows[i]["segundoApellido"].ToString())
                            , Desencriptar.desencriptar(datos.Tables[0].Rows[i]["correoElectronico"].ToString())
                            , Desencriptar.desencriptar(datos.Tables[0].Rows[i]["nombreUsuario"].ToString())
                            , Desencriptar.desencriptar(datos.Tables[0].Rows[i]["contrasenia"].ToString())
                            )
                        );
                }
                return lista_usuarios;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Elimina la cuenta del usuario en la memoria.
        /// El usuario es eliminado de la base de datos tambien.
        /// </summary>
        public void borrarCuenta()
        {
            // Eliminar el usuario de la base de datos.
            eliminarUsuario(Memoria.sesionUsuarioDatos.id);

            Memoria.sesionDeUsuario = false;
            Memoria.sesionUsuarioDatos = new Usuario();
        }

        public void guardarNuevoUsuario(Usuario usuario)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_usuario_crear";

            Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(usuario));
        }

        public void eliminarUsuario(string id)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_usuario_eliminar";

            string[] parametros = { "ID" };
            string[] valores = { id };

            Memoria.logica_database
               .querySimple(stringDeConexion
               , nombre_storedProcedure
               , parametros
               , valores);
        }

        public void actualizarUsuario(Usuario usuario)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_usuario_actualizar";

            Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(usuario));
        }

        public void cambiarContrasenia(Usuario usuario)
        {
            // Se hará despues en la fase 3.
        }

        public void deslogeo()
        {
            // No existe sesion de admin.
            Memoria.sesionDeUsuario = false;

            // Datos del admin logeado borrados.
            Memoria.sesionUsuarioDatos = new Usuario();
        }

        public Usuario() { }

        public Usuario(string id
            , string nombre
            , string primerApellido
            , string segundoApellido
            , string correoElectronico
            , string nombreUsuario
            , string contrasenia)
        {
            this.id = id;
            this.nombre = nombre;
            this.primerApellido = primerApellido;
            this.segundoApellido = segundoApellido;
            this.correoElectronico = correoElectronico;
            this.nombreUsuario = nombreUsuario;
            this.contrasenia = contrasenia;
        }

        string[] parametros = {
                "ID"
                ,"nombre"
                , "primerApellido"
                , "segundoApellido"
                , "correoElectronico"
                , "nombreUsuario"
                , "contrasenia"};

        private string[] return_valores(Usuario usuario)
        {
            string[] valores = {
                usuario.id
                ,usuario.nombre
                ,usuario.primerApellido
                ,usuario.segundoApellido
                ,usuario.correoElectronico
                ,usuario.nombreUsuario
                ,usuario.contrasenia
            };
            return valores;
        }
    }
}
