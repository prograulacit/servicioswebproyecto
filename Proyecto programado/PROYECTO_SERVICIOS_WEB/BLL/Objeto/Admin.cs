using System.Collections.Generic;

namespace BLL.Objeto
{
    public class Admin
    {
        public int id { get; set; }
        public int nombreUsuario { get; set; }
        public string correoElectronico { get; set; }
        public bool adminMaestro { get; set; }
        public bool adminSeguridad { get; set; }
        public bool adminMantenimiento { get; set; }
        public bool adminConsultas { get; set; }
        public string contrasenia { get; set; }
        public string preguntaSeguridad{ get; set; }
        public string respuestaSeguridad { get; set; }
        public bool activado { get; set; }

        public List<Admin> traerAdmins()
        {
            return null;
        }

        public void actualizarAdmin_baseDeDatos(Admin admin)
        {

        }

        public void actualizarAdmin_memoria(Admin admin)
        {

        }

        public Admin()
        {

        }

        public Admin(int id, int nombreUsuario, string correoElectronico, bool adminMaestro, bool adminSeguridad, bool adminMantenimiento, bool adminConsultas, string contrasenia, string preguntaSeguridad, string respuestaSeguridad, bool activado)
        {
            this.id = id;
            this.nombreUsuario = nombreUsuario;
            this.correoElectronico = correoElectronico;
            this.adminMaestro = adminMaestro;
            this.adminSeguridad = adminSeguridad;
            this.adminMantenimiento = adminMantenimiento;
            this.adminConsultas = adminConsultas;
            this.contrasenia = contrasenia;
            this.preguntaSeguridad = preguntaSeguridad;
            this.respuestaSeguridad = respuestaSeguridad;
            this.activado = activado;
        }
    }
}
