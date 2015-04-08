using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security.Cryptography;

namespace ClinicaFRBA.Utils.Seguridad
{
    static class Encriptador
    {
        public static string encriptar(string valorAEncriptar)
        {
            SHA256Managed passwd = new SHA256Managed();
            byte[] textoSinEncriptar = System.Text.Encoding.ASCII.GetBytes(valorAEncriptar);
            byte[] textoEncriptado = passwd.ComputeHash(textoSinEncriptar);
            string contrasena = Convert.ToBase64String(textoEncriptado);
            return contrasena;
        }
    }
}
