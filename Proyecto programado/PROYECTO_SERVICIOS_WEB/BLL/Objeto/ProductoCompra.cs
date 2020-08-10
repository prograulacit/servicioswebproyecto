using System;
using System.Collections.Generic;

namespace BLL.Objeto
{
    public class ProductoCompra
    {
        // Guarda el ID del producto que se va a comprar.
        public string productoCompraId { get; set; }

        // Clases de los productos que van a mantener la información.
        public Pelicula pelicula { get; set; }
        public Musica musica { get; set; }
        public Libro libro { get; set; }

        // Le dice a la logica de la aplicación que tipo de producto
        // se ha elegido.
        public bool esPelicula = false;
        public bool esMusica = false;
        public bool esLibro = false;

        public ProductoCompra() { }

        /// <summary>
        /// Constructor que establece automaticamente que tipo de producto
        /// se va a comprar dado el ID del producto
        /// </summary>
        /// <param name="productoCompraId">ID del producto que se
        /// va a comprar (pelicula, musica o libro).</param>
        public ProductoCompra(string productoCompraId)
        {
            this.productoCompraId = productoCompraId;
            establecerProducto(productoCompraId);
        }

        /// <summary>
        /// Establece en las variables Pelicula, Musica o Libro los datos
        /// correspondientes del producto que se va a comprar.
        /// NOTA: METODO DEBE SER UTILIZADO UNICAMENTE EL EL CONSTRUCTOR.
        /// </summary>
        /// <param name="id">ID del producto</param>
        private void establecerProducto(string id)
        {
            Pelicula p = new Pelicula();
            Libro l = new Libro();
            Musica m = new Musica();

            List<Pelicula> lista_peliculas = p.traerPeliculas();
            List<Musica> lista_musica = m.traerMusicas();
            List<Libro> lista_libro = l.traerLibros();

            // Revisa si el producto es pelicula
            if (lista_peliculas != null)
            {
                for (int i = 0; i < lista_peliculas.Count; i++)
                {
                    if (lista_peliculas[i].id == id)
                    {
                        esPelicula = true;
                        pelicula = lista_peliculas[i];
                        break;
                    }
                }
            }

            // Revisa si el producto es musica
            if (lista_musica != null)
            {
                for (int i = 0; i < lista_musica.Count; i++)
                {
                    if (lista_musica[i].id == id)
                    {
                        esMusica = true;
                        musica = lista_musica[i];
                        break;
                    }
                }
            }

            // Revisa si el producto es libro
            if (lista_libro != null)
            {
                for (int i = 0; i < lista_libro.Count; i++)
                {
                    if (lista_libro[i].id == id)
                    {
                        esLibro = true;
                        libro = lista_libro[i];
                        break;
                    }
                }
            }

            if (!esLibro && !esMusica && !esPelicula)
            {
                throw new Exception("Elemento no encontrado!");
            }
        }

        /// <summary>
        /// Retorna true si el usuario a seleccionado un producto para comprar.
        /// </summary>
        /// <returns>boolean</returns>
        public bool seHaSeleccionadoProductoParaComprar()
        {
            return !string.IsNullOrEmpty(productoCompraId);
        }

        /// <summary>
        /// Retorna un string el cual indica el tipo de producto seleccionado.
        /// </summary>
        /// <returns>string: pelicula | musica | libro</returns>
        public string obtenerTipoProducto()
        {
            if (esPelicula)
            {
                return "pelicula";
            }
            else if (esMusica)
            {
                return "musica";
            }
            else if (esLibro)
            {
                return "libro";
            }
            throw new Exception("Error: producto no establecido!");
        }
    }
}
