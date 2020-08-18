using BLL.Objeto;
using DAL;
using System.Collections.Generic;

namespace BLL.Logica
{
    public class Memoria
    {
        // Listas de información.
        public static List<Usuario> lista_usuario = new List<Usuario>();
        public static List<Admin> lista_admins = new List<Admin>();
        public static List<Pelicula> lista_peliculas = new List<Pelicula>();
        public static List<Musica> lista_musica = new List<Musica>();
        public static List<Libro> lista_libros = new List<Libro>();
        public static List<Consecutivo> lista_consecutivos = new List<Consecutivo>();
        //public static List<Tarjeta> lista_tarjetas = new List<Tarjeta>();
        //public static List<EasyPay> lista_easyPay = new List<EasyPay>();

        // Guarda los ID de los productos (Musica, Pelicula, Libro).
        public static List<string> carrito_de_compra = new List<string>();

        // Lista de variables bool. Si sessionDeUsuario, por ejemplo, es true significa
        // que el usuario actualmente logeado es un usuario o cliente.
        public static bool sesionSocial = false;
        public static bool sesionDeUsuario = false;
        public static bool sesionDeAdmin = false;

        // Esta variable controla si los datos con los que la aplicación esta trabajando
        // están codificados en Base64. True = trabajando con datos codificados. False =
        // trabajando con datos en texto plano.
        public static bool datos_encriptados = true;

        // Lista de variables objecto/Clase. Si por ejemplo el usuario logeado es un admin,
        // sus datos seran guardados en ésta variale segun corresponda.
        public static Usuario sesionUsuarioDatos;
        public static Admin sesionAdminDatos;

        // Con este objecto vamos a realizar las acciones de la base de datos para
        // crear, leer, actualizar y borrar registros. Al ser un objeto estatico, puede
        // ser accedido desde cualquier lugar de la aplicación en BLL y Web Application desde
        // la clase Memoria. Recibe bool datos_encriptados para determinar si los datos con los
        // que estámos trabajando están códificados en Base64 o texto plano.
        public static DBLogica logica_database = new DBLogica(datos_encriptados);

        /// <summary>
        /// Producto que el usuario ha seleccionado para comprar. Gracias a la instancia
        /// en la memoria del servidor, podemos consultar el producto que el usuario
        /// a seleccionado para comprar en cualquier parte de la aplicación web.
        /// </summary>
        public static ProductoCompra productoAComprar = new ProductoCompra();

        /// <summary>
        /// Variable en la memoria en donde se guarda el metodo de pago a utilizar para
        /// comprar un producto.
        /// </summary>
        public static CompraMetodoDePago compraMetodoDePago = new CompraMetodoDePago();
    }
}