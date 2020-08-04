using BLL.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Objeto
{
    public class EasyPay
    {
        public string id { get; set; }
        public string IDusuario { get; set; }
        public string numeroCuenta { get; set; } // ID de tarjeta.
        public string codigoSeguridad { get; set; }
        public string contrasenia { get; set; }
        public string monto { get; set; }

        public List<EasyPay> traer_easyPays()
        {
            DataSet datos = Memoria.logica_database
             .queryConRetornoDeDatos_sinParametros(
             Memoria.logica_database.stringDeConexion_baseDeDatos_pagos,
             "sp_easypay_leer"
             );

            if (datos.Tables[0].Rows.Count > 0)
            {
                List<EasyPay> lista_easyPays = new List<EasyPay>();
                for (int i = 0; i < datos.Tables[0].Rows.Count; i++)
                {
                    lista_easyPays.Add(
                        new EasyPay
                            (
                            Encriptacion.desencriptar(datos.Tables[0].Rows[i]["ID"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["IDusuario"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["numeroCuenta"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["codigoSeguridad"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["contrasenia"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["monto"].ToString())
                            )
                        );
                }
                return lista_easyPays;
            }
            else
            {
                return null;
            }
        }

        public void guardar_easyPay(EasyPay easypay)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_pagos;
            string nombre_storedProcedure = "sp_easypay_crear";

            Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(easypay));
        }

        public void actualizar_easypay(EasyPay easypay)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_pagos;
            string nombre_storedProcedure = "sp_easypay_actualizar";

            Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(easypay));
        }

        public void eliminar_easypay(string id)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_pagos;
            string nombre_storedProcedure = "sp_easypay_eliminar";

            string[] parametros = { "ID" };
            string[] valores = { id };

            Memoria.logica_database
               .querySimple(stringDeConexion
               , nombre_storedProcedure
               , parametros
               , valores);
        }

        /// <summary>
        /// Las cuentas EasyPay tienen una tarjeta asociada. Este
        /// metodo retorna la tarjeta asociada.
        /// </summary>
        /// <returns>Retorna la tarjeta asociada al EasyPay</returns>
        public Tarjeta traerTarjetaAsociada()
        {
            Tarjeta t = new Tarjeta();
            List<Tarjeta> lista_tarjetas = t.traerTarjetas();
            if (lista_tarjetas != null)
            {
                foreach (var tarjeta in lista_tarjetas)
                {
                    if (tarjeta.numeroTarjeta == this.numeroCuenta) { return tarjeta; }
                }
            }
            return null; // Si no encuentra la tarjeta asociada retorna null.
        }

        /// <summary>
        /// Retorna el saldo actual del EasyPay
        /// </summary>
        /// <returns>Saldo o monto actual.</returns>
        public string obtenerMontoActual()
        {
            Tarjeta t = traerTarjetaAsociada();
            string saldo = t.monto;
            return saldo;
        }

        /// <summary>
        /// Regresa el numero de tarjeta vinculada a la
        /// cuenta de EasyPay en formato "xxxx9383".
        /// </summary>
        /// <returns>String con numero de tarjeta
        /// formateada.</returns>
        public string obtenerNumeroTarjetaFormateada()
        {
            Tarjeta t = traerTarjetaAsociada();

            string numeroTarjeta = t.numeroTarjeta;
            int length = numeroTarjeta.Length;

            // Pasamos el numero de tarjeta a formato "xxxx9281".
            string tarjetaFormateada =
                "xxxx" + 
                Char.ToString(numeroTarjeta[length - 4]) +
                Char.ToString(numeroTarjeta[length - 3]) +
                Char.ToString(numeroTarjeta[length - 2]) +
                Char.ToString(numeroTarjeta[length - 1]);

            return tarjetaFormateada;
        }

        /// <summary>
        /// Retorna una lista de EasyPays asociados a el ID de un usuario.
        /// </summary>
        /// <param name="usuario_id">ID del usuario asociado a los
        /// EasyPays a buscar.</param>
        /// <returns>Lista de EasyPays con asociacion al ID del usuario dado.</returns>
        public List<EasyPay> traerEasyPays_UsuarioId(string usuario_id)
        {
            List<EasyPay> lista_easypays = traer_easyPays();
            List<EasyPay> listaEasypays_usuario = new List<EasyPay>();

            if (lista_easypays != null)
            {
                for (int i = 0; i < lista_easypays.Count; i++)
                {
                    if (lista_easypays[i].IDusuario == usuario_id)
                    {
                        // Se establece el monto actual con reflejo al 
                        // de la tarjeta asociada.
                        lista_easypays[i].monto = obtenerMontoActual();

                        // Se establece el numero de tarjeta formateada.
                        lista_easypays[i].monto = obtenerNumeroTarjetaFormateada();
                        listaEasypays_usuario.Add(lista_easypays[i]);
                    }
                }
                return listaEasypays_usuario;
            }
            return null;
        }

        public EasyPay() { }

        public EasyPay(string id
            , string iDusuario
            , string numeroCuenta
            , string codigoSeguridad
            , string contrasenia
            , string monto)
        {
            this.id = id;
            IDusuario = iDusuario;
            this.numeroCuenta = numeroCuenta;
            this.codigoSeguridad = codigoSeguridad;
            this.contrasenia = contrasenia;
            this.monto = monto;
        }

        string[] parametros = {
                "ID"
                ,"IDusuario"
                ,"numeroCuenta"
                ,"codigoSeguridad"
                ,"contrasenia"
                ,"monto"};

        private string[] return_valores(EasyPay easypay)
        {
            string[] valores = {
                easypay.id
                ,easypay.IDusuario
                ,easypay.numeroCuenta
                ,easypay.codigoSeguridad
                ,easypay.contrasenia
                ,easypay.monto
            };
            return valores;
        }
    }
}
