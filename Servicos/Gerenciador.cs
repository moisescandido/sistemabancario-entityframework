using Banco.Dominios;

namespace Banco.Servicos
{
    public class GerenciadorConta
    {
        public GerenciadorConta()
        {
            AppDbContext _db = new AppDbContext();
            db = _db;
        }
        public AppDbContext db { get; set; }
        public void Criar(ContaCorrente conta)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            db.ContaCorrente.Add(conta);
            db.SaveChanges();
        }

        public ContaCorrente Entrar(string numeroConta)
        {
            ContaCorrente _conta = new ContaCorrente();
            _conta = db.ContaCorrente.FirstOrDefault(x => x.Numero == numeroConta);
            return _conta;

        }
        public void Depositar(ContaCorrente conta, double valor)
        {
            ContaCorrente _conta = new ContaCorrente();

            _conta = db.ContaCorrente.FirstOrDefault(x => x.Numero == conta.Numero);
            _conta.Saldo += valor;

            db.ContaCorrente.Update(_conta);
            db.SaveChanges();
        }
        public void Transferir(string numeroContaRemetente, string numeroContaDestinatario, double valor)
        {
            ContaCorrente _contaRemetente = new ContaCorrente();
            ContaCorrente _contaDestinatario = new ContaCorrente();

            _contaRemetente = db.ContaCorrente.FirstOrDefault(x => x.Numero == numeroContaRemetente);
            _contaDestinatario = db.ContaCorrente.FirstOrDefault(x => x.Numero == numeroContaDestinatario);

            if (_contaDestinatario == null)
            {
                Console.WriteLine("Destinatário não existe! ");
            }
            else
            {
                _contaRemetente.Saldo = _contaRemetente.Saldo - valor;
                db.ContaCorrente.Update(_contaRemetente);
                db.SaveChanges();

                _contaDestinatario.Saldo = _contaDestinatario.Saldo + valor;
                db.ContaCorrente.Update(_contaDestinatario);
                db.SaveChanges();
            }
        }
    }
}
