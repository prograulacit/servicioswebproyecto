using System;
using System.Text;

namespace DAL
{
    public class Encriptacion
    {
        // Resive una cadena de texto como input en texto plano y retorna
        // su equivalente en Base64.
        // Este metodo es usado en DAL/DBLogica para encriptar los datos que se
        // envian a la base de datos.
        public static string encriptar(string input)
        {
            try
            {
                string resultado = string.Empty;
                Byte[] encriptar = new UnicodeEncoding().GetBytes(input);
                return Convert.ToBase64String(encriptar);
            }
            catch (Exception)
            {
                // Si hay un error de datos no convertibles de Base64 a string
                // se retorna el valor de input.
                return input;
            }
        }

        // El metodo de desencriptacion se encuentra en BLL/Logica/Encriptacion
    }
}
