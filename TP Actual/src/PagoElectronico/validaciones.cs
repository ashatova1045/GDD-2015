using System.Text.RegularExpressions;

namespace PagoElectronico
{
    public static class ValidadorHelper
    {
        static Regex regexSoloNumeros = new Regex(@"^[0-9]+$");
        static Regex regexSoloLetras = new Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚ]+$");
        static Regex regexMail = new Regex(@"^[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z]{2,4}$");
        static Regex regexSolofrases = new Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚ ]+$");
        static Regex regexLetrasGuiones = new Regex(@"^[-_a-zA-ZáéíóúÁÉÍÓÚ]+$");

        public static bool validar16Numeros(string numero)
        {
            return validarSoloNumeros(numero) && numero.Length == 16;
        }

        public static bool validarSoloNumeros(string numero)
        {
            return regexSoloNumeros.IsMatch(numero);
        }

        public static bool validarSoloLetras(string nombre)
        {
            return regexSoloLetras.IsMatch(nombre);
        }

        public static bool validarMail(string mail)
        {
            return regexMail.IsMatch(mail);
        }

        public static bool ValidarFrase(string frase)
        {
            return regexSolofrases.IsMatch(frase);
        }

        public static bool ValidarLetrasGuiones(string cadena)
        {
            return regexLetrasGuiones.IsMatch(cadena);
        }
    }
}
