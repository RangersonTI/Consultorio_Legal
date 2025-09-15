using System;

namespace Core.Shared.ModelViews
{
    /// <summary>
    ///     Objeto utilizado para inserção de um novo cliente!
    /// </summary>
    public class NovoCliente
    {   
        /// <summary>
        ///     Nome do cliente
        /// </summary>
        /// <example></example>
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        /// <example>M</example>
        public char Sexo { get; set; }
        public string Telefone { get; set; }
        /// <summary>
        ///     CPF, RG ou CNH
        /// </summary>
        public string Documento { get; set; }
    }
}

