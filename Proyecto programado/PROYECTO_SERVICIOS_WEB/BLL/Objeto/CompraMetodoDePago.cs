using System.Collections.Generic;

namespace BLL.Objeto
{
    public class CompraMetodoDePago
    {
        public string metodoDePagoID { get; set; }

        public CompraMetodoDePago() { }

        public CompraMetodoDePago(string metodoDePagoID)
        {
            this.metodoDePagoID = metodoDePagoID;
        }

        /// <summary>
        /// Trae el registro de EasyPay de la base de datos segun
        /// el ID guardado en metodoDePagoID. Retorna null si no es
        /// encontrado.
        /// </summary>
        /// <returns>EasyPay o null</returns>
        public EasyPay traerEasyPayAsociado()
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
        public Tarjeta traerTarjetaAsociada()
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
                            return lista_tarjetas[i];
                        }
                    }
                }
            }
            return null;
        }
    }
}
