namespace BLL.Objeto
{
    public class Producto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public double monto { get; set; }
        public string idioma { get; set; }
        public string rutaArchivoDescarga { get; set; }
        public string rutaArchivoPrevisualizacion { get; set; }

        public Producto() { }

        public Producto(int id, string nombre, double monto, string idioma, string rutaArchivoDescarga, string rutaArchivoPrevisualizacion)
        {
            this.id = id;
            this.nombre = nombre;
            this.monto = monto;
            this.idioma = idioma;
            this.rutaArchivoDescarga = rutaArchivoDescarga;
            this.rutaArchivoPrevisualizacion = rutaArchivoPrevisualizacion;
        }
    }
}
