using BLL.Logica;
using System;
using System.Collections.Generic;
using System.Data;

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
                for (int i = 0; i < lista_tarjetas.Count; i++)
                {
                    if (lista_tarjetas[i].id == this.numeroCuenta)
                    {
                        return lista_tarjetas[i];
                    }
                }
            }
            return null; // Si no encuentra la tarjeta asociada retorna null.
        }

        /// <summary>
        /// Retorna el saldo actual del EasyPay. Lo calcula por medio
        /// de su tarjeta asociada.
        /// </summary>
        /// <returns>Saldo o monto actual.</returns>
        public string obtenerMontoActual()
        {
            Tarjeta t = traerTarjetaAsociada();
            if (t == null)
            {
                throw new Exception("Tarjeta no fue encontrada.");
            }
            string monto = t.monto;
            return monto;
        }

        /// <summary>
        /// Regresa el numero de tarjeta asociada a la
        /// cuenta de EasyPay en formato "xxxx9383".
        /// </summary>
        /// <returns>String con numero de tarjeta
        /// formateada.</returns>
        public string obtenerNumeroTarjetaFormateada(EasyPay easyPay)
        {
            Tarjeta tarjeta = new Tarjeta();
            tarjeta = tarjeta.traerTarjetaPorId(easyPay.numeroCuenta);

            string numeroTarjeta = tarjeta.numeroTarjeta;
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
                        // Se establece el numero de tarjeta formateada.
                        lista_easypays[i].numeroCuenta = 
                            obtenerNumeroTarjetaFormateada(lista_easypays[i]);
                        listaEasypays_usuario.Add(lista_easypays[i]);
                    }
                }
                return listaEasypays_usuario;
            }
            return null;
        }

        /// <summary>
        /// Genera los codigos de seguridad los cuales son numeros de 4 digitos.
        /// </summary>
        /// <returns>Numero de 4 digitos entre 1000 y 9999.</returns>
        public string generarCodigoDeSeguridad()
        {
            // Genera y retorna un numero aleatorio entre 1000 y 9999.
            Random rnd = new Random();
            return "" + rnd.Next(1000, 9999);
        }

        /// <summary>
        /// Trae un registro de EasyPay en forma de objeto dando como parametro
        /// su ID,
        /// </summary>
        /// <param name="id">ID del EasyPay</param>
        /// <returns>Objeto EasyPay cuyo ID concuerde.</returns>
        public EasyPay traerEasyPay_porID(string id)
        {
            EasyPay e = new EasyPay();
            List<EasyPay> lista_easyPay = traer_easyPays();
            if (lista_easyPay != null)
            {
                for (int i = 0; i < lista_easyPay.Count; i++)
                {
                    if (lista_easyPay[i].id == id)
                    {
                        return lista_easyPay[i];
                    }
                }
            }
            return null; // Retorna null si no se encontró.
        }

        /// <summary>
        /// Elimina de la base de datos todos los EasyPay que esten asociados a
        /// una tarjeta. Este metodo se utiliza cuando una tarjeta es eliminada 
        /// del sistema y, por ende, los EasyPays asociados a esa tarjeta deben
        /// ser eliminados tambien.
        /// </summary>
        /// <param name="tarjetaId">ID de la tarjeta que se ha eliminado
        /// del sistema.</param>
        public void eliminarEasyPays_asociadosATarjetaID(string tarjetaId)
        {
            // Se traen los EasyPay de la base de datos.
            EasyPay e = new EasyPay();
            List<EasyPay> listaEasyPays = e.traer_easyPays();

            if (listaEasyPays != null)
            {
                for (int i = 0; i < listaEasyPays.Count; i++)
                {
                    // El número de cuenta es el ID de la tarjeta.
                    if (listaEasyPays[i].numeroCuenta == tarjetaId)
                    {
                        e.eliminar_easypay(listaEasyPays[i].id);
                    }
                }
            }
        }

        /// <summary>
        /// Cuando se realiza una compra con una tarjeta, se reduce el saldo de la tarjeta.
        /// Por ende, debemos actualizar el saldo de las cuentas EasyPay asociadas a la tarjeta
        /// utilizada para que el saldo sea el mismo en ambos registros. Recordemos que el saldo
        /// de los EasyPay es exactamente el mismo que el de las tarjetas.
        /// </summary>
        /// <param name="tarjetaId">ID de la tarjeta con la que se ha efectuado el pago.</param>
        /// <param name="montoActualizado">Monto con el cual la tarjeta a terminado después
        /// de que se haya reducido su saldo.</param>
        public void actualizarMonto_compraConTarjeta(string tarjetaId, string montoActualizado)
        {
            EasyPay e = new EasyPay();
            List<EasyPay> listaEasyPays = e.traer_easyPays();

            if (listaEasyPays != null) 
            {
                for (int i = 0; i < listaEasyPays.Count; i++)
                {
                    // si es una cuenta asociada a la tarjeta.
                    if (listaEasyPays[i].numeroCuenta == tarjetaId) 
                    {
                        // actualizamos su monto y actualizamos el registro
                        // en la base de datos.
                        listaEasyPays[i].monto = montoActualizado;
                        e.actualizar_easypay(listaEasyPays[i]);
                    }
                }
            }
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
