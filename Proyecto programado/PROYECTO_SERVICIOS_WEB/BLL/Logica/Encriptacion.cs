﻿using System;
using System.Text;

namespace BLL.Logica
{
    public class Encriptacion
    {
        // Resive una cadena de texto como input en texto plano y retorna
        // su equivalente en Base64.
        public string encriptar(string input)
        {
            string resultado = string.Empty;
            Byte[] encriptar = new UnicodeEncoding().GetBytes(input);
            return Convert.ToBase64String(encriptar);
        }

        // Resive una cadena de texto como input en Base64 y retorna
        // su equivalente en texto plano
        public string desencriptar(string input)
        {
            if (Memoria.datos_encriptados)
            {
                string resultado = string.Empty;
                Byte[] desencriptar = Convert.FromBase64String(input);
                return new UnicodeEncoding().GetString(desencriptar);
            }
            else
            {
                return input;
            }
        }
    }
}
