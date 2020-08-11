using System;
using System.Collections.Generic;

namespace BLL.Objeto
{
    public class CompraMetodoDePago
    {
        public string metodoDePagoID { get; set; }
        public bool esTarjeta = false;
        public bool esEasyPay = false;

        public CompraMetodoDePago() { }

        public CompraMetodoDePago(string metodoDePagoID)
        {
            this.metodoDePagoID = metodoDePagoID;
            traerTarjetaOEasyPayAsociado();
        }

        /// <summary>
        /// Trae el registro de EasyPay de la base de datos segun
        /// el ID guardado en metodoDePagoID. Retorna null si no es
        /// encontrado.
        /// </summary>
        /// <returns>EasyPay o null</returns>
        private EasyPay traerEasyPayAsociado()
        {
            string easyPay_id = metodoDePagoID;

            if (!string.IsNullOrEmpty(easyPay_id))
            {
                EasyPay easypay = new EasyPay();
                List<EasyPay> lista_easyPays = easypay.traer_easyPays();

                if (lista_easyPays != null)
                {
                    for (int i = 0; i < lista_easyPays.Count; i++)
                    {
                        if (lista_easyPays[i].id == easyPay_id)
                        {
                            esEasyPay = true;
                            esTarjeta = false;
                            return lista_easyPays[i];
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Trae el registro de la tarjeta de la base de datos segun
        /// el ID guardado en metodoDePagoID. Retorna null si no es
        /// encontrado.
        /// </summary>
        /// <returns>Tarjeta o null</returns>
        private Tarjeta traerTarjetaAsociada()
        {
            string tarjeta_id = metodoDePagoID;

            if (!string.IsNullOrEmpty(tarjeta_id))
            {
                Tarjeta tarjeta = new Tarjeta();
                List<Tarjeta> lista_tarjetas = tarjeta.traerTarjetas();

                if (lista_tarjetas != null)
                {
                    for (int i = 0; i < lista_tarjetas.Count; i++)
                    {
                        if (lista_tarjetas[i].id == tarjeta_id)
                        {
                            esTarjeta = true;
                            esEasyPay = false;
                            return lista_tarjetas[i];
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Trae la Tarjeta o EasyPay asociado. Retorna null si el
        /// registro no es encontrado.
        /// </summary>
        /// <returns>Tarjeta | EasyPay | null</returns>
        public Object traerTarjetaOEasyPayAsociado()
        {
            var TarjetaOEasyPay = traerTarjetaAsociada();
            if (TarjetaOEasyPay != null)
            {
                esTarjeta = true;
                esEasyPay = false;
                return TarjetaOEasyPay;
            }
            else
            {
                esTarjeta = false;
                esEasyPay = true;
                return traerEasyPayAsociado();
            }
        }

        /// <summary>
        /// Retorna true si se ha seleccionado metodo de pago.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool seHaSeleccionadoMetodoDePago()
        {
            return !string.IsNullOrEmpty(metodoDePagoID);
        }

        /// <summary>
        /// Retorna el tipo de metodo de pago en forma de string
        /// </summary>
        /// <returns>String:tarjeta | String:easypay | null
        /// si no esta establecido.</returns>
        public string obtenerTipoMetodoDePago()
        {
            if (esTarjeta)
            {
                return "tarjeta";
            }
            else if(esEasyPay)
            {
                return "easypay";
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Retorna el saldo actual del metodo de pago que estamos utilizando.
        /// </summary>
        /// <returns>Int:saldo actual</returns>
        public int obtenerSaldo()
        {
            if (esTarjeta)
            {
                Tarjeta tarjeta = traerTarjetaAsociada();
                return Int32.Parse(tarjeta.monto);
            }
            else if (esEasyPay)
            {
                EasyPay ep = traerEasyPayAsociado();
                return Int32.Parse(ep.monto);
            }
            else
            {
                throw new Exception("Elemento no encontrado.");
            }
        }

        public void actualizarSaldo(string saldoActualizado)
        {
            if (esTarjeta)
            {
                Tarjeta t = traerTarjetaAsociada();
                t.monto = saldoActualizado;
                t.actualizarTarjeta(t);
            }
            else if(esEasyPay)
            {
                EasyPay ep = traerEasyPayAsociado();
                ep.monto = saldoActualizado;
                ep.actualizar_easypay(ep);
            }
        }
    }
}
