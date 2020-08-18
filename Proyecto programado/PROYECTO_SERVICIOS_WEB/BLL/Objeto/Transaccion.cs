using BLL.Logica;
using System.Collections.Generic;
using System.Data;

namespace BLL.Objeto
{
    public class Transaccion
    {
        public string id { get; set; }
        public string fechaCompra { get; set; }
        public string monto { get; set; }
        public string usuarioID { get; set; }
        public string consecutivoProductoID { get; set; }
        public string tarjetaID { get; set; }
        public string easyPayID { get; set; }

        public Transaccion() { }

        public List<Transaccion> traerTransacciones()
        {
            // Se traen todos los datos de la base de datos cono objeto DataSet.
            DataSet datos = Memoria.logica_database
                .queryConRetornoDeDatos_sinParametros(
                Memoria.logica_database.stringDeConexion_baseDeDatos_principal,
                "sp_transaccion_leer"
                );

            if (datos.Tables[0].Rows.Count > 0)
            {
                List<Transaccion> lista_transacciones = new List<Transaccion>();

                for (int i = 0; i < datos.Tables[0].Rows.Count; i++)
                {
                    lista_transacciones.Add(
                        new Transaccion
                            (
                            Desencriptar.desencriptar(datos.Tables[0].Rows[i]["ID"].ToString())
                            , Desencriptar.desencriptar(datos.Tables[0].Rows[i]["fechaCompra"].ToString())
                            , Desencriptar.desencriptar(datos.Tables[0].Rows[i]["monto"].ToString())
                            , Desencriptar.desencriptar(datos.Tables[0].Rows[i]["usuarioID"].ToString())
                            , Desencriptar.desencriptar(datos.Tables[0].Rows[i]["consecutivoProductoID"].ToString())
                            , Desencriptar.desencriptar(datos.Tables[0].Rows[i]["tarjetaID"].ToString())
                            , Desencriptar.desencriptar(datos.Tables[0].Rows[i]["easyPayID"].ToString())
                            )
                        );
                }

                return lista_transacciones;
            }
            else
            {
                return null;
            }
        }

        public void crearRegistroTranseccion(Transaccion transaccion)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_transaccion_crear";

            Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(transaccion));
        }

        public void actualizarRegistroTransaccion(Transaccion transaccion)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_transaccion_actualizar";

            Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(transaccion));
        }

        public void eliminarTransaccion(string id)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_transaccion_eliminar";

            string[] parametros = { "ID" };
            string[] valores = { id };

            Memoria.logica_database
               .querySimple(stringDeConexion
               , nombre_storedProcedure
               , parametros
               , valores);
        }

        public string traerFechaCompra_porId(string id)
        {
            List<Transaccion> lista_transacciones = traerTransacciones();

            for (int i = 0; i < lista_transacciones.Count; i++)
            {
                if (lista_transacciones[i].id == id)
                {
                    return lista_transacciones[i].fechaCompra;
                }
            }
            // Si por alguna razón no se encuentra la fecha original, se envia
            // una nueva fecha.
            return Tareas.obtener_fecha_actual();
        }

        /// <summary>
        /// Trae el registro de una transaccion dado un ID.
        /// </summary>
        /// <param name="id">ID del registro de transaccion
        /// que se desea traer de la base de datos.</param>
        /// <returns>Transaccion | null si no es encontrado.</returns>
        public Transaccion traerTransaccion_id(string id)
        {
            List<Transaccion> lista_transacciones = traerTransacciones();

            if (lista_transacciones != null)
            {
                for (int i = 0; i < lista_transacciones.Count; i++)
                {
                    if (lista_transacciones[i].id == id)
                    {
                        return lista_transacciones[i];
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Trae una lista con todos los productos que pertenecen al usuario logeado
        /// en la memoria.
        /// </summary>
        /// <returns>List<Transaccion> || null si no encontro registros.</returns>
        public List<Transaccion> traer_listaTransaccionesPropiedadUsuarioLogeado()
        {
            List<Transaccion> lista_transacciones = traerTransacciones();
            List<Transaccion> lista_transaccionesPropiedad = new List<Transaccion>();

            if (lista_transacciones != null &&
                Memoria.sesionUsuarioDatos != null)
            {
                for (int i = 0; i < lista_transacciones.Count; i++)
                {
                    if (lista_transacciones[i].usuarioID == Memoria.sesionUsuarioDatos.id)
                    {
                        lista_transaccionesPropiedad.Add(lista_transacciones[i]);
                    }
                }
                return lista_transaccionesPropiedad;
            }
            return null;
        }

        /// <summary>
        /// Revisa en la base de datos en la tabla transacciones si no existe
        /// ningun registro que concuerde con el ID del usuario dado y el 
        /// producto comprado dado. Este método, por lo tanto, funciona para
        /// verificar si el usuario en cuestion tiene propiedad de un producto
        /// especifico.
        /// </summary>
        /// <param name="usuario_id">ID del usuario a consultar.</param>
        /// <param name="producto_id">ID del producto a consultar</param>
        /// <returns>Retorna true si el usuario NO tiene propiedad del producto
        /// a consultar.</returns>
        public bool usuarioNoTienePropiedadDeProducto(
            string usuario_id, string producto_id)
        {
            List<Transaccion> lista_transacciones = traerTransacciones();

            if (lista_transacciones != null)
            {
                for (int i = 0; i < lista_transacciones.Count; i++)
                {
                    if (lista_transacciones[i].usuarioID == usuario_id &&
                        lista_transacciones[i].consecutivoProductoID == producto_id)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public Transaccion(string id
            , string fechaCompra
            , string monto
            , string usuarioID
            , string productoId
            , string tarjetaId
            , string easyPayId)
        {
            this.id = id;
            this.fechaCompra = fechaCompra;
            this.monto = monto;
            this.usuarioID = usuarioID;
            this.consecutivoProductoID = productoId;
            this.tarjetaID = tarjetaId;
            this.easyPayID = easyPayId;
        }

        string[] parametros = {
                "ID"
                ,"fechaCompra"
                , "monto"
                , "usuarioID"
                , "consecutivoProductoID"
                , "tarjetaID"
                , "easyPayID" };

        private string[] return_valores(Transaccion transaccion)
        {
            string[] valores = {
                transaccion.id,
                transaccion.fechaCompra,
                transaccion.monto,
                transaccion.usuarioID,
                transaccion.consecutivoProductoID,
                transaccion.tarjetaID,
                transaccion.easyPayID
                };
            return valores;
        }
    }
}

