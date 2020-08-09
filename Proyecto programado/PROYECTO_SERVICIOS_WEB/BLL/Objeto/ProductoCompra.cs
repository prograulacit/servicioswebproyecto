using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Objeto
{
    public class ProductoCompra
    {
        // Guarda el ID del producto que se va a comprar.
        public string productoCompraId{ get; set; }

        // Clases de los productos que van a mantener la información.
        public Pelicula pelicula { get; set; }
        public Musica musica { get; set; }
        public Libro libro { get; set; }

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
        /// <param name="id"></param>
        private void establecerProducto(string id)
        {
            var peliculaLibroOMusica = traerProducto(id);
        }

        /// <summary>
        /// Dependiendo del id dado, traera el producto reflejado en la
        /// base de datos.
        /// NOTA: METODO DEBE SER UTILIZADO UNICAMENTE EL EL CONSTRUCTOR.
        /// </summary>
        /// <param name="id">ID del producto a traer de la base de datos</param>
        /// <returns>Pelicula, Musica o Libro</returns>
        private object traerProducto(string id)
        {
            List<Pelicula> lista_peliculas = pelicula.traerPeliculas();
            List<Musica> lista_musica = musica.traerMusicas();
            List<Libro> lista_libro = libro.traerLibros();

            // Revisa si el producto es pelicula
            if (lista_peliculas != null)
            {
                for (int i = 0; i < lista_peliculas.Count; i++)
                {
                    if (lista_peliculas[i].id == id)
                    {
                        return lista_peliculas[i];
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
                        return lista_musica[i];
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
                        return lista_libro[i];
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Elimina la información del producto a comprar.
        /// </summary>
        public void limpiarProducto()
        {
            productoCompraId = null;
            pelicula = null;
            musica = null;
            libro = null;
        }
    }
}
