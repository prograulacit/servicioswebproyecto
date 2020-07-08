using BLL.Objeto;
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

        public static List<Producto> carrito_de_compra = new List<Producto>();

        // Lista de variables bool.
        public static bool sesionDeUsuario = false;
        public static bool sesionDeAdmin = false;

        // Lista de variables objecto/Clase.
        public static Usuario sesionUsuario;
        public static Admin sesionAdmin;


    }
}
