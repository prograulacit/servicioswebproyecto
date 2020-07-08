using System.Data;

namespace BLL.Objeto
{
    public class Error
    {
        public int id { get; set; }
        public string fechaYHora{ get; set; }
        public string nombreUsuarioResponsable { get; set; }
        public string mensajeDeError { get; set; }

        public DataSet traerErrores()
        {
            return null;
        }

        public void guardarError(Error error)
        {

        }

        public Error(int id, string fechaYHora, string nombreUsuarioResponsable, string mensajeDeError)
        {
            this.id = id;
            this.fechaYHora = fechaYHora;
            this.nombreUsuarioResponsable = nombreUsuarioResponsable;
            this.mensajeDeError = mensajeDeError;
        }

        public Error()
        {

        }

    }
}
