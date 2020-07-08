using System.Data;

namespace BLL.Objeto
{
    public class Parametros
    {
        public int id { get; set; }
        public string rutaAlmacenamientoPrevisualizacionLibros{ get; set; }
        public string rutaAlmacenamientoLibros { get; set; }

        public string rutaAlmacenamientoPrevisualizacionPeliculas { get; set; }
        public string rutaAlmacenamientoPeliculas { get; set; }

        public string rutaAlmacenamientoPrevisualizacionMusica { get; set; }
        public string rutaAlmacenamientoMusica { get; set; }

        public DataSet traerParametros()
        {
            return null;
        }

        public void actualizarParametros_baseDeDatos(Parametros parametros)
        {

        }

        public void actualizarParametros_memoria(Parametros parametros)
        {

        }

        public Parametros()
        {

        }

        public Parametros(int id, string rutaAlmacenamientoPrevisualizacionLibros, string rutaAlmacenamientoLibros, string rutaAlmacenamientoPrevisualizacionPeliculas, string rutaAlmacenamientoPeliculas, string rutaAlmacenamientoPrevisualizacionMusica, string rutaAlmacenamientoMusica)
        {
            this.id = id;
            this.rutaAlmacenamientoPrevisualizacionLibros = rutaAlmacenamientoPrevisualizacionLibros;
            this.rutaAlmacenamientoLibros = rutaAlmacenamientoLibros;
            this.rutaAlmacenamientoPrevisualizacionPeliculas = rutaAlmacenamientoPrevisualizacionPeliculas;
            this.rutaAlmacenamientoPeliculas = rutaAlmacenamientoPeliculas;
            this.rutaAlmacenamientoPrevisualizacionMusica = rutaAlmacenamientoPrevisualizacionMusica;
            this.rutaAlmacenamientoMusica = rutaAlmacenamientoMusica;
        }
    }
}
