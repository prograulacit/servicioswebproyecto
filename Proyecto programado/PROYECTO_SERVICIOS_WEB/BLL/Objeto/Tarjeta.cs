using BLL.Logica;
using System;
using System.Collections.Generic;
using System.Data;

namespace BLL.Objeto
{
    public class Tarjeta
    {
        public string id { get; set; }
        public string usuarioId { get; set; }
        public string numeroTarjeta { get; set; }
        public string mesExpiracion { get; set; }
        public string anioExpiracion { get; set; }
        public string cvv { get; set; }
        public string monto { get; set; }
        public string tipo { get; set; }

        public List<Tarjeta> traerTarjetas()
        {
            DataSet datos = Memoria.logica_database
             .queryConRetornoDeDatos_sinParametros(
             Memoria.logica_database.stringDeConexion_baseDeDatos_pagos,
             "sp_tarjeta_leer"
             );

            if (datos.Tables[0].Rows.Count > 0)
            {
                List<Tarjeta> lista_tarjetas = new List<Tarjeta>();
                for (int i = 0; i < datos.Tables[0].Rows.Count; i++)
                {
                    lista_tarjetas.Add(
                        new Tarjeta
                            (
                            Encriptacion.desencriptar(datos.Tables[0].Rows[i]["ID"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["IDusuario"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["numeroTarjeta"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["mesExpiracion"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["anioExpiracion"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["CVV"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["monto"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["tipo"].ToString())
                            )
                        );
                }
                return lista_tarjetas;
            }
            else
            {
                return null;
            }
        }

        public void guardarTarjeta(Tarjeta tarjeta)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_pagos;
            string nombre_storedProcedure = "sp_tarjeta_crear";

            Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(tarjeta));
        }

        public void actualizarTarjeta(Tarjeta tarjeta)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_pagos;
            string nombre_storedProcedure = "sp_tarjeta_actualizar";

            Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(tarjeta));
        }

        public void eliminarTarjeta(string id)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_pagos;
            string nombre_storedProcedure = "sp_tarjeta_eliminar";

            string[] parametros = { "ID" };
            string[] valores = { id };

            Memoria.logica_database
               .querySimple(stringDeConexion
               , nombre_storedProcedure
               , parametros
               , valores);
        }

        /// <summary>
        /// Retorna una lista de tarjetas asociadas a el ID de un usuario.
        /// </summary>
        /// <param name="usuario_id">ID del usuario asociado a las
        /// tarjetas a buscar.</param>
        /// <returns>Lista de tarjetas con asociacion al usuario.</returns>
        public List<Tarjeta> traerTarjetas_UsuarioId(string usuario_id)
        {
            List<Tarjeta> lista_tarjetas = traerTarjetas();
            List<Tarjeta> listaTarjetas_usuario = new List<Tarjeta>();

            if (lista_tarjetas != null)
            {
                for (int i = 0; i < lista_tarjetas.Count; i++)
                {
                    if (lista_tarjetas[i].usuarioId == usuario_id)
                    {
                        listaTarjetas_usuario.Add(lista_tarjetas[i]);
                    }
                }
                return listaTarjetas_usuario;
            }
            return null;
        }

        /// <summary>
        /// Trae una tarjeta de la base de datos segun el ID dado.
        /// </summary>
        /// <param name="id">ID de la tarjeta a traer</param>
        /// <returns>Retorna objeto Tarjeta solicitado por ID</returns>
        public Tarjeta traerTarjetaPorId(string id_tarjeta)
        {
            Tarjeta tarjeta = new Tarjeta();
            List<Tarjeta> lista_tarjetas = tarjeta.traerTarjetas();
            for (int i = 0; i < lista_tarjetas.Count; i++)
            {
                if (lista_tarjetas[i].id == id_tarjeta)
                {
                    return lista_tarjetas[i];
                }
            }
            return null; // Si no es encontrada retorna null.
        }

        public Tarjeta() { }

        public Tarjeta(string id
            , string usuarioId
            , string numeroTarjeta
            , string mesExpiracion
            , string anioExpiracion
            , string cvv
            , string monto
            , string tipo)
        {
            this.id = id;
            this.usuarioId = usuarioId;
            this.numeroTarjeta = numeroTarjeta;
            this.mesExpiracion = mesExpiracion;
            this.anioExpiracion = anioExpiracion;
            this.cvv = cvv;
            this.monto = monto;
            this.tipo = tipo;
        }

        /// <summary>
        /// Cuando se realiza una compra con cuenta EasyPay, se reduce el saldo de la cuenta EasyPay.
        /// Por ende, debemos actualizar el saldo de las cuentas Tarjetas asociadas a la cuenta EasyPay
        /// utilizada para que el saldo sea el mismo en ambos registros. Recordemos que el saldo
        /// de las Tarjetas es exactamente el mismo que el de las cuentas EasyPay.
        /// </summary>
        /// <param name="easyPay_numeroCuenta">ID de la tarjeta con la que se ha efectuado el pago.</param>
        /// <param name="montoActualizado">Monto con el cual la tarjeta a terminado después
        /// de que se haya reducido su saldo.</param>
        internal void actualizarMonto_compraConEasyPay(string easyPay_numeroCuenta, string saldoActualizado)
        {
            Tarjeta t = new Tarjeta();
            List<Tarjeta> lista_tarjetas = t.traerTarjetas();

            if (lista_tarjetas != null)
            {
                for (int i = 0; i < lista_tarjetas.Count; i++)
                {
                    if (lista_tarjetas[i].id == easyPay_numeroCuenta)
                    {
                        // actualizamos su monto y actualizamos el registro
                        // en la base de datos.
                        lista_tarjetas[i].monto = saldoActualizado;
                        t.actualizarTarjeta(lista_tarjetas[i]);
                    }
                }
            }
        }

        string[] parametros = {
                "ID"
                ,"IDusuario"
                , "numeroTarjeta"
                , "mesExpiracion"
                , "anioExpiracion"
                , "CVV"
                , "monto"
                , "tipo"
                };

        private string[] return_valores(Tarjeta tarjeta)
        {
            string[] valores = {
                tarjeta.id
                ,tarjeta.usuarioId
                ,tarjeta.numeroTarjeta
                ,tarjeta.mesExpiracion
                ,tarjeta.anioExpiracion
                ,tarjeta.cvv
                ,tarjeta.monto
                ,tarjeta.tipo };
            return valores;
        }
    }
}
