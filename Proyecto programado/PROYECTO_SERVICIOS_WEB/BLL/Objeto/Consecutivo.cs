using System.Data;

namespace BLL.Objeto
{
    public class Consecutivo
    {
        public int id { get; set; }
        public string tipoConsecutivo { get; set; }
        public string descripcion { get; set; }
        public string prefijo { get; set; }
        public string rangoInicial { get; set; }
        public string rangoFinal { get; set; }

        public DataSet traerConsecutivos()
        {
            return null;
        }

        public void guardarConsecutivo_baseDeDatos(Consecutivo consecutivo)
        {

        }

        public void guardarConsecutivo_memoria(Consecutivo consecutivo)
        {

        }

        public void actualizarConsecutivo_baseDeDatos(Consecutivo consecutivo)
        {

        }

        public void actualizarConsecutivo_memoria(Consecutivo consecutivo)
        {

        }

        public Consecutivo() { }

        public Consecutivo(int id, string tipoConsecutivo, string descripcion, string prefijo, string rangoInicial, string rangoFinal)
        {
            this.id = id;
            this.tipoConsecutivo = tipoConsecutivo;
            this.descripcion = descripcion;
            this.prefijo = prefijo;
            this.rangoInicial = rangoInicial;
            this.rangoFinal = rangoFinal;
        }
    }
}
