using BLL.Logica;
using BLL.Objeto;
using System;

namespace Web_Application.Paginas.Frontend
{
    public partial class checkout1 : System.Web.UI.Page
    {
        ///////////////////////////////////////////////////////////
        /// Metodo inicial. Este metodo realiza toda la lógica de ésta página.
        /// Comenzar a leer aquí para entender la clase.
        ///////////////////////////////////////////////////////////
        protected void Page_Load(object sender, EventArgs e)
        {
            // Validamos que exista la sesión de usuario.
            if (!Memoria.sesionDeUsuario)
            {
                Response.Redirect("~/Paginas/Compartido/index.aspx");
            }
            // Comenzamos el proceso de transacción.
            validacionesIniciales();
        }

        /// <summary>
        /// Método principal que comienza todo el proceso de transacción.
        /// </summary>
        private void validacionesIniciales()
        {
            // Capturamos el método de pago y el producto.
            var Producto = Memoria.productoAComprar;
            var MetodoDePago = Memoria.compraMetodoDePago;

            // Se hacen las validaciones correspondientes.
            if (seHaSeleccionadoProductoYMetodoDePago(Producto, MetodoDePago) &&
                usuarioNoTienePropiedadDelProducto(Producto) &&
                fondosSuficientes(Producto, MetodoDePago))
            {
                // Si llegamos aquí, se comienza a registrar la compra en la base de datos.
                efectuarCompra(Producto, MetodoDePago);
            }
        }

        /// <summary>
        /// Método que realiza la compra una vez las validaciones se hayan hecho y todo
        /// este correcto.
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="metodoPago"></param>
        private void efectuarCompra(ProductoCompra producto, CompraMetodoDePago metodoPago)
        {
            registrarTransaccion(producto, metodoPago); // Guarda en la base de datos la propiedad del producto.
            reducirSaldo(producto, metodoPago); // Reduce el saldo del metodo de pago utilizado.
            compraExitosa(); // Muestra mensaje de compra exitosa. Elimina método de pago y producto de la memoria.

            // Fin del proceso de compra.
        }

        #region Lógica
        /// <summary>
        /// Hace el registro de transacción en la base de datos. En otras palabras, guarda
        /// el registro de propiedad del producto en la base de datos.
        /// </summary>
        /// <param name="producto">Producto seleccionado.</param>
        /// <param name="metodoPago">Método de pago seleccionado.</param>
        private void registrarTransaccion(ProductoCompra producto
            , CompraMetodoDePago metodoPago)
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

            // Registro espejo del registro requerido guardado en la base de datos.
            Consecutivo registro_de_consecutivo = new Consecutivo();
            registro_de_consecutivo = registro_de_consecutivo
                .traerConsecutivo_registroReflejadoEnDB("transaccion");

            // Se actualiza el id de la transaccion como prefijo+numConsecuvito.
            // Ejemplo: tra4 .
            string id_consecutivo =
                 registro_de_consecutivo.prefijo + (int.Parse(registro_de_consecutivo.descripcion));

            // Se crea objeto Transacción.
            Transaccion transaccion = new Transaccion(
                id_consecutivo
                , Tareas.obtener_fecha_actual()
                , "" + producto.obtenerMonto()
                , Memoria.sesionUsuarioDatos.id
                , producto.productoCompraId
                , tarjeta_id
                , easypay_id);

            // Se guarda el registro de transaccion.
            transaccion.crearRegistroTranseccion(transaccion);

            // Aumentamos el valor "descripcion" del consecutivo en 1.
            string valorDescripcionAumentadoEn1 =
                Tareas.aumentarColumnaDeConsecutivoEn1(registro_de_consecutivo);
            registro_de_consecutivo.descripcion = valorDescripcionAumentadoEn1;

            // Actualizamos el consecutivo en la base de datos.
            registro_de_consecutivo
                .actualizarConsecutivo_baseDeDatos(registro_de_consecutivo);
        }

        /// <summary>
        /// Reduce el saldo del método de pago en haras al producto seleccionado.
        /// </summary>
        /// <param name="producto">Producto seleccionado.</param>
        /// <param name="metodoPago">Método de pago seleccionado.</param>
        private void reducirSaldo(ProductoCompra producto
            , CompraMetodoDePago metodoPago)
        {
            int montoProducto = producto.obtenerMonto();
            int saldoDisponible = metodoPago.obtenerSaldo();

            int saldoReducido = saldoDisponible - montoProducto; // Reducción de saldo.

            metodoPago.actualizarSaldo("" + saldoReducido);
        }

        /// <summary>
        /// Muestra mensaje de compra exitosa. 
        /// Elimina método de pago y producto de la memoria.
        /// </summary>
        private void compraExitosa()
        {
            // Limpia la memoria del producto y método de pago.
            Memoria.compraMetodoDePago = new CompraMetodoDePago();
            Memoria.productoAComprar = new ProductoCompra();

            // Muestra mensaje de compra exitosa.
            establecerContenido_label(
                true
                , "¡Gracias!"
                , "La compra ha sido efectuada exitosamente"
                , "Puede revisar sus compras en la página dedicada. <a href='#'>Ver compras</a>");
        }
        #endregion

        #region Validaciones
        /// <summary>
        /// Valida que el usuario haya elegido un metodo de pago y un producto para comprar.
        /// </summary>
        /// <param name="compraProducto">Objeto del producto que se desea comprar.</param>
        /// <param name="compraMetodoDePago">Objeto del metodo de pago elegido.</param>
        /// <returns>True si se han especificado metodo de pago y producto.</returns>
        private bool seHaSeleccionadoProductoYMetodoDePago(
            ProductoCompra compraProducto
            , CompraMetodoDePago compraMetodoDePago)
        {
            if (compraProducto.seHaSeleccionadoProductoParaComprar() &&
                compraMetodoDePago.seHaSeleccionadoMetodoDePago())
            {
                return true;
            }
            else
            {
                establecerContenido_label(false,
                    "Ha ocurrido un error"
                    , "Error interno del sistema."
                    , "El usuario no ha especificado un producto o método de pago para" +
                    " efectuar la compra. Por favor, regrese al ménu principal.");
                return false;
            }
        }

        /// <summary>
        /// Valida si el usuario no es dueño aun del producto que intenta comprar.
        /// Un usuario no puede comprar el mismo producto dos veces.
        /// </summary>
        /// <param name="producto">Producto seleccionado para comprar.</param>
        /// <returns>True si el usuario no tiene propiedad del producto en este
        /// momento.</returns>
        private bool usuarioNoTienePropiedadDelProducto(ProductoCompra producto)
        {
            string producto_id = producto.productoCompraId;
            string usuario_id = Memoria.sesionUsuarioDatos.id;

            Transaccion transaccion = new Transaccion();

            if (transaccion.usuarioNoTienePropiedadDeProducto
                (usuario_id, producto_id))
            {
                return true;
            }
            else
            {
                establecerContenido_label(true
                    , "Error en la transacción"
                    , "Prodiedad del producto ya adquirida."
                    , "El producto que está intentando comprar ya es de su propiedad. " +
                    "No se han efectuado cargos a su saldo.");
                return false;
            }
        }

        /// <summary>
        /// Comprueba si el método de pago elegido contiene los fondos suficientes para realizar la compra.
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="metodoPago"></param>
        /// <returns>True si se cuenta con fondos suficientes.</returns>
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
                "posee los fondos suficientes para " +
                "efectuar la compra. Por favor, vuelva " +
                "a intentarlo con un método de pago diferente.");
                return false;
            }
        }
        #endregion

        /// <summary>
        /// Renderiza el mensaje que se va a mostrar en pantalla cuando el usuario
        /// se encuentre en la interfaz de checkout.
        /// </summary>
        /// <param name="tipo">Si es true, se muestra el mensaje con un fondo verde.
        /// Si es false, se muestra el mensaje con un fondo rojo.</param>
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