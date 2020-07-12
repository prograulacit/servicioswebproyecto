using System;
using System.Linq;

namespace BLL.Logica
{
    public class Tareas
    {
        #region Conversores de datos
        // Conversores de datos.
        // Dado que la base de datos es toda NVARCHAR/string,
        // estos metodos retornan el valor correcto para ser
        // trabajado por la lógica del programa. Ejemplo:
        // AdminMaestro en la base de datos se guarda como
        // "true" o "false" en formato string. Si pasamos
        // el valor a conversor_booleano, este retornara true
        // o false.
        public static int conversor_integer(string input)
        {
            return Int32.Parse(input);
        }

        // Resive un string que dice true o false. Retorna true o false
        // en booleano.
        public static bool conversor_booleando(string input)
        {
            if (input.Equals("true"))
            {
                return true;
            }
            else if (input.Equals("false"))
            {
                return false;
            }
            else
            {
                Console.Error.WriteLine("Input recibido no es true ni false.");
                return false;
            }
        }

        // Resive un booleano. Retorna true o false en string.
        public static string conversor_booleandoInverso(bool input)
        {
            if (input)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }
        #endregion

        // Generar nuevo ID. Dado que toda la base de datos está en
        // NVARCHAR/string. Es imposible generar ID's autoincrementables
        // en valores enteros. Por lo tanto, se optara por crear IDs a 
        // partir de un string aleatorio generado por el sistema backend.
        public static string generar_nuevo_id_para_un_registro()
        {
            string resultado = "";

            // Genera un numero aleatorio.
            Random rnd = new Random();
            resultado += "" + rnd.Next(1, 99999999);

            // Genera un string aleatorio de 15 caracteres de largo.
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string random_strings = new string(Enumerable.Repeat(chars, 15)
                .Select(s => s[rnd.Next(s.Length)]).ToArray());

            resultado += random_strings;
            return resultado;
        }

        // Retorna la fecha actual del computador donde el servidor está ospedado.
        // Retorna la fecha en formato dia/mes/año hora:minuto:segundo.
        // Retorna el resultado en String.
        public static string obtener_fecha_actual()
        {
            return DateTime.Now.ToString();
        }
    }
}
