using System.ComponentModel.DataAnnotations;
using Banco.Servicos;

namespace Banco.Dominios
{
    public class ContaCorrente : IDisposable
    {
        public ContaCorrente()
        {
            Random rnd = new Random();
            Numero = rnd.Next(1000000, 9999999).ToString("00000-00");
        }
        public string Titular { get; set; }
        public double Saldo { get; set; }

        [Key]
        public string Numero { get; set; }

        public void Dispose()
        {
        }
    }
}