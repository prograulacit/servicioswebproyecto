using BLL.Logica;
using BLL.Objeto;
using System;

namespace Web_Application.Paginas.Frontend
{
    public partial class checkout1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Memoria.sesionDeUsuario)
            {
                Response.Redirect("~/Paginas/Compartido/index.aspx");
            }
            establecerContenido_label(
                true
                ,""
                ,""
                ,"");
            transaccion_procesoLogicoInicial();
        }

        /// <summary>
        /// Método principal que comienza todo el proceso de transacción.
        /// </summary>
        private void transaccion_procesoLogicoInicial()
        {
            // Capturamos el método de pago y el producto.
            var compraProducto = Memoria.productoAComprar;
            var compraMetodoDePago = Memoria.compraMetodoDePago;

            if (fondosSuficientes(compraProducto, compraMetodoDePago))
            {
                efectuarCompra_main(compraProducto, compraMetodoDePago);
            }
        }

        private void efectuarCompra_main(ProductoCompra producto, CompraMetodoDePago metodoPago) 
        {
            registrarTransaccion(producto, metodoPago);
            reducirSaldo(producto, metodoPago);
            compraExitosa();
        }

        private void compraExitosa()
        {
            Memoria.compraMetodoDePago = new CompraMetodoDePago();
            Memoria.productoAComprar = new ProductoCompra();
            establecerContenido_label(
                true
                , "¡Gracias!"
                , "La compra ha sido efectuada exitosamente"
                , "Puede revisar sus compras en la página dedicada. <a href='#'>Ver compras</a>");
        }

        private void reducirSaldo(ProductoCompra producto, CompraMetodoDePago metodoPago)
        {
            int montoProducto = producto.obtenerMonto();
            int saldoDisponible = metodoPago.obtenerSaldo();

            int saldoReducido = saldoDisponible - montoProducto;

            metodoPago.actualizarSaldo("" + saldoReducido);
        }

        private void registrarTransaccion(ProductoCompra producto, CompraMetodoDePago metodoPago)
        {
            string tarjeta_id = "";
            string easypay_id = "";

            if (metodoPago.esTarjeta)
            {
                tarjeta_id = metodoPago.metodoDePagoID;
            }

            if (metodoPago.esEasyPay)
            {
                easypay_id = metodoPago.metodoDePagoID;
            }

            Transaccion transaccion = new Transaccion(
                Tareas.generar_nuevo_id_para_un_registro()
                , Tareas.obtener_fecha_actual()
                , "" + producto.obtenerMonto()
                , Memoria.sesionUsuarioDatos.id
                ,producto.productoCompraId
                ,tarjeta_id
                ,easypay_id);

            // Se guarda el registro de transaccion.
            transaccion.crearRegistroTranseccion(transaccion);
        }

        private bool fondosSuficientes(ProductoCompra producto, CompraMetodoDePago metodoPago)
        {
            int saldoDisponible = metodoPago.obtenerSaldo();
            int montoProducto = producto.obtenerMonto();

            if (saldoDisponible >= montoProducto)
            {
                return true;
            }
            else
            {
                establecerContenido_label(
                false
                , "Error durante la transacción"
                , "Saldo insuficiente"
                , "El método de pago utilizado no " +
                "posee los suficientes fondos para " +
                "efectuar la compra. Por favor, vuelva " +
                "a intentarlo con un método de pago diferente.");
                return false;
            }
        }

        /// <summary>
        /// Renderiza el mensaje que se va a ver en pantalla cuando el usuario
        /// se encuentre en la interfaz de checkout.
        /// </summary>
        /// <param name="tipo">Si es true, se muestra mensaje de Success.</param>
        /// <param name="titulo">Titulo del mensaje.</param>
        /// <param name="subtitulo">Subtitulo del mensaje.</param>
        /// <param name="descripcion">Descripcion del mensaje.</param>
        private void establecerContenido_label(
            bool tipo
            , string titulo
            , string subtitulo
            , string descripcion)
        {
            string fondoVerdeRojo = "";

            switch (tipo) // establece el color rojo o verde segun requerido.
            {
                case true:
                    fondoVerdeRojo = @"<div class='alert alert-success'>";
                    break;
                case false:
                    fondoVerdeRojo = @"<div class='alert alert-danger'>";
                    break;
                default:
                    fondoVerdeRojo = @"<div class='alert alert-primary'>";
                    break;
            }

            string html =
                $"{fondoVerdeRojo}" +
                    $"<div class='titulo'>" +
                        $"{titulo}" +
                    $"</div>" +
                    $"<div class='subtitulo'>" +
                        $"{subtitulo}" +
                    $"</div>" +
                    $"<div>" +
                        $"{descripcion}" +
                    $"</div>" +
                $"</div>";

            Label_status.Text = html;
        }
    }
}