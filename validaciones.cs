using System;
using System.Text.RegularExpressions;

namespace Validaciones
{
    public class Validador
    {
        Regex regexSoloNumeros = new Regex(@"^[0-9]+$");
        Regex regexSoloLetras = new Regex(@"^[a-zA-Záéíóú]+$");
        Regex regexMail = new Regex(@"^[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z]{2,4}$");

        public bool validarSoloNumeros(string numero)
        {
            return regexSoloNumeros.IsMatch(numero);
        }

        public bool validarSoloLetras(string nombre)
        {
            return regexSoloLetras.IsMatch(nombre);
        }

        public bool validarMail(string mail)
        {
            return regexMail.IsMatch(mail);
        }
    }
}
