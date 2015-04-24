using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace OperacionesDB.Cifrado
{
    class Cifrador
    {
        public static string Cifrar (string valorACifrar)
        {
            SHA256Managed contraseña = new SHA256Managed();

            //Guardamos en un Array el texto sin cifrar
            byte[] sinCifrar = System.Text.Encoding.ASCII.GetBytes(valorACifrar);

            //Guardamos en un Array el texto cifrado
            byte[] cifrado = contraseña.ComputeHash(sinCifrar);

            //Convertimos a String lo cifrado
            string password = Convert.ToBase64String(cifrado);

            //Retornamos el password cifrado
            return password; 
        }
    }
}
