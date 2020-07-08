using System.Data;

namespace BLL.Objeto
{
    public class Bitacora
    {
        public int id { get; set; }
        public string nombreUsuarioResponsable { get; set; }
        public string fechaYHora { get; set; }
        public string codigoDelRegistro { get; set; }
        public string tipo { get; set; }
        public string descripcion { get; set; }
        public string registroEnDetalle { get; set; }

        public DataSet traerBitacoras()
        {
            return null;
        }

        public void guardarBitacora(Bitacora bitacora)
        {

        }
        
        public Bitacora()
        {

        }

        public Bitacora(int id, string nombreUsuarioResponsable, string fechaYHora, string codigoDelRegistro, string tipo, string descripcion, string registroEnDetalle)
        {
            this.id = id;
            this.nombreUsuarioResponsable = nombreUsuarioResponsable;
            this.fechaYHora = fechaYHora;
            this.codigoDelRegistro = codigoDelRegistro;
            this.tipo = tipo;
            this.descripcion = descripcion;
            this.registroEnDetalle = registroEnDetalle;
        }
    }
}
