//Gabriel Velho dos Santos

using System.Text.RegularExpressions;

namespace AcademiaDoZe.Dominio.Services
{
    public static partial class NormalizadoService
    {
        public static string LimparEspacos(string? texto) => string.IsNullOrWhiteSpace(texto) ? string.Empty : EspacosRegex().Replace(texto, " ").Trim();
        public static string LimparTodosEspacos(string? texto) => string.IsNullOrWhiteSpace(texto) ? string.Empty : texto.Replace(" ", string.Empty);
        public static string ParaMaiusculo(string? texto) => string.IsNullOrEmpty(texto) ? string.Empty : texto.ToUpperInvariant();
        public static string LimparEDigitos(string? texto) => string.IsNullOrEmpty(texto) ? string.Empty : new string([.. texto.Where(char.IsDigit)]);

        public static bool TextoVazioOuNulo(string? texto) => string.IsNullOrEmpty(texto) || string.IsNullOrWhiteSpace(texto);

        private static readonly Func<string, bool> EmailEhValido = email =>
        !string.IsNullOrWhiteSpace(email) &&
        Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        private static readonly Func<string, bool> SenhaEhValida = senha =>
        !string.IsNullOrWhiteSpace(senha) &&
        Regex.IsMatch(senha, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+{}\[\]:;<>,.?~\\/-]).{8,}$");

        public static bool ValidarEmail(string email) => EmailEhValido(email);
        public static bool ValidarSenha(string senha) => SenhaEhValida(senha);

        [GeneratedRegex(@"\s+")]

       
        private static partial Regex EspacosRegex();
    }
}