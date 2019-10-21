using System;
using System.Text.RegularExpressions;

namespace DefenseIO.Infra.Shared.Utils
{
    public static class CpfCnpjUtils
    {
        private static readonly string RegexSomenteNumeros = "[^0-9]";

        public static string NormalizarCPF(string cpf) => ExtrairSomenteNumeros(cpf);
        public static string NormalizarCNPJ(string cnpj) => ExtrairSomenteNumeros(cnpj);

        private static string ExtrairSomenteNumeros(string value) 
            => (!string.IsNullOrEmpty(value)) 
            ? Regex.Replace(value, RegexSomenteNumeros, "") 
            : value;

    }
}
