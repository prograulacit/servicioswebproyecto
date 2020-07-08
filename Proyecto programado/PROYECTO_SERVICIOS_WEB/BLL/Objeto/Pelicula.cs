using System.Data;

namespace BLL.Objeto
{
    public class Pelicula : Producto
    {
        public string genero { get; set; }
        public string anio { get; set; }
        public string actores { get; set; }

        public DataSet traerPeliculas()
        {
            return null;
        }

        public void guardarPelicula_baseDeDatos(Pelicula pelicula)
        {

        }

        public void guardarPelicula_memoria(Pelicula pelicula)
        {

        }

        public void actualizarPelicula_baseDeDatos(Pelicula pelicula)
        {

        }

        public void actualizarPelicula_memoria(Pelicula pelicula)
        {

        }

        public void eliminarPelicula_baseDeDatos(Pelicula pelicula)
        {

        }

        public void eliminarPelicula_memoria(Pelicula pelicula)
        {

        }

        public Pelicula() { }

        public Pelicula(int id, string nombre, double monto, string idioma, string rutaArchivoDescarga, string rutaArchivoPrevisualizacion,
            string genero, string anio, string actores)
        {
            this.id = id;
            this.nombre = nombre;
            this.monto = monto;
            this.idioma = idioma;
            this.rutaArchivoDescarga = rutaArchivoDescarga;
            this.rutaArchivoPrevisualizacion = rutaArchivoPrevisualizacion;

            this.genero = genero;
            this.anio = anio;
            this.actores = actores;
        }
    }
}
