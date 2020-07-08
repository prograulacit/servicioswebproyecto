using System.Data;

namespace BLL.Objeto
{
    public class Usuario
    {
        public int ID { get; set; }
        public string nombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string correoElectronico { get; set; }
        public string nombreUsuario { get; set; }
        public string contrasenia { get; set; }

        public DataSet traerUsuarios()
        {
            return null;
        }

        public void cambiarContrasenia_baseDeDatos(Usuario usuario)
        {

        }

        public void cambiarContrasenia_memoria(Usuario usuario)
        {

        }

        public Usuario()
        {

        }

        public Usuario(int iD, string nombre, string primerApellido, string segundoApellido, string correoElectronico, string nombreUsuario, string contrasenia)
        {
            ID = iD;
            this.nombre = nombre;
            this.primerApellido = primerApellido;
            this.segundoApellido = segundoApellido;
            this.correoElectronico = correoElectronico;
            this.nombreUsuario = nombreUsuario;
            this.contrasenia = contrasenia;
        }
    }
}
