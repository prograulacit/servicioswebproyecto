using System.Data;

namespace BLL.Objeto
{
    public class Pelicula
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string genero { get; set; }
        public string anio { get; set; }
        public string idioma { get; set; }
        public string actores { get; set; }
        public string rutaArchivoDescarga { get; set; }
        public string rutaArchivoPrevisualizacion { get; set; }
        public double monto { get; set; }

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

        public Pelicula(int id, string nombre, string genero, string anio, string idioma, string actores, string rutaArchivoDescarga, string rutaArchivoPrevisualizacion, double monto)
        {
            this.id = id;
            this.nombre = nombre;
            this.genero = genero;
            this.anio = anio;
            this.idioma = idioma;
            this.actores = actores;
            this.rutaArchivoDescarga = rutaArchivoDescarga;
            this.rutaArchivoPrevisualizacion = rutaArchivoPrevisualizacion;
            this.monto = monto;
        }
    }
}
