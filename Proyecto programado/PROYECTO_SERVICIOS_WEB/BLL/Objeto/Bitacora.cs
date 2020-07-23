using BLL.Logica;
using System.Collections.Generic;
using System.Data;

namespace BLL.Objeto
{
    public class Bitacora
    {
        public string id { get; set; }
        public string nombreUsuarioAdmin { get; set; }
        public string fechaYHora { get; set; }
        public string codigoDelRegistro { get; set; }
        public string tipo { get; set; }
        public string descripcion { get; set; }
        public string registroEnDetalle { get; set; }

        public List<Bitacora> traerBitacoras()
        {
            DataSet datos = Memoria.logica_database
               .queryConRetornoDeDatos_sinParametros(
               Memoria.logica_database.stringDeConexion_baseDeDatos_principal,
               "sp_bitacora_traer"
               );

            if (datos.Tables[0].Rows.Count > 0)
            {
                List<Bitacora> lista_bitacoras = new List<Bitacora>();
                for (int i = 0; i < datos.Tables[0].Rows.Count; i++)
                {
                    lista_bitacoras.Add(
                        new Bitacora
                            (
                            Encriptacion.desencriptar(datos.Tables[0].Rows[i]["ID"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["nombreUsuarioAdmin"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["fechaYHora"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["codigoDelRegistro"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["tipo"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["descripcion"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["registroEnDetalle"].ToString())
                            )
                        );
                }
                return lista_bitacoras;
            }
            else
            {
                return null;
            }
        }

        public void guardarBitacora(Bitacora bitacora)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_bitacora_crear";

            Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(bitacora));
        }

        public void actualizarBitacora(Bitacora bitacora)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_bitacora_actualizar";

            Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(bitacora));
        }

        public void eliminarBitacora(string id)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_bitacora_eliminar";

            string[] parametros = { "ID" };
            string[] valores = { id };

            Memoria.logica_database
               .querySimple(stringDeConexion
               , nombre_storedProcedure
               , parametros
               , valores);
        }

        // Guarda una bitacora automaticamente. Solo require que se
        // de el tipo de bitacora, la descripcion y el registro en 
        // detalle.
        public void guardarBitacora_interfazDeUsuario(string tipo
            , string descripcion, string registroEnDetalle)
        {
            Bitacora bitacora = new Bitacora(
                Tareas.generar_nuevo_id_para_un_registro()
                , Memoria.sesionAdminDatos.nombreUsuario
                , Tareas.obtener_fecha_actual()
                , "N/A"
                , tipo
                , descripcion
                , registroEnDetalle
                );
            guardarBitacora(bitacora);
        }

        public Bitacora()
        {

        }

        public Bitacora(string id
            , string nombreUsuarioAdmin
            , string fechaYHora
            , string codigoDelRegistro
            , string tipo
            , string descripcion
            , string registroEnDetalle)
        {
            this.id = id;
            this.nombreUsuarioAdmin = nombreUsuarioAdmin;
            this.fechaYHora = fechaYHora;
            this.codigoDelRegistro = codigoDelRegistro;
            this.tipo = tipo;
            this.descripcion = descripcion;
            this.registroEnDetalle = registroEnDetalle;
        }

        string[] parametros = {
                "ID"
                ,"nombreUsuarioAdmin"
                , "fechaYHora"
                , "codigoDelRegistro"
                , "tipo"
                , "descripcion"
                , "registroEnDetalle"};

        private string[] return_valores(Bitacora bitacora)
        {
            string[] valores = {
                bitacora.id,
                bitacora.nombreUsuarioAdmin,
                bitacora.fechaYHora,
                bitacora.codigoDelRegistro,
                bitacora.tipo,
                bitacora.descripcion,
                bitacora.registroEnDetalle};
            return valores;
        }
    }
}
