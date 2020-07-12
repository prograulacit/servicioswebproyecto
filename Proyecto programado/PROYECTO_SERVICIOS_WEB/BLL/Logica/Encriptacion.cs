using System;
using System.Text;

namespace BLL.Logica
{
    public class Encriptacion
    {
        // Este metodo de encriptación se encuentra en DAL/Encriptacion.

        // Resive una cadena de texto como input en Base64 y retorna
        // su equivalente en texto plano. Para un control más rápido
        // datos encriptados o no, se usa el control true false de
        // la variable datos encriptados.
        // En otras palabras, si los datos están en Base64, se decodificaran
        // Si no estan en Base64, se regresara el mismo input
        public static string desencriptar(string input)
        {
            if (Memoria.datos_encriptados)
            {
                try
                {
                    string resultado = string.Empty;
                    Byte[] desencriptar = Convert.FromBase64String(input);
                    return new UnicodeEncoding().GetString(desencriptar);
                }
                catch (Exception)
                {
                    // Si hay un error, probablemente sea porqué los datos no estan
                    // codifidados en Base64; por lo que se retorna el input.
                    return input;
                }
            }
            else
            {
                return input;
            }
        }
    }
}
