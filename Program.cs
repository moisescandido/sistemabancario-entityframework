using Banco.Dominios;
using Banco.Servicos;

GerenciadorConta gerenciador = new GerenciadorConta();
ContaCorrente usuario = new ContaCorrente();

void Menu()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("1) ENTRAR");
    Console.WriteLine("2) CRIAR CONTA");
    Console.WriteLine("0) SAIR");
    Console.Write("Escolha uma opção: ");

    try
    {
        ushort numero = ushort.Parse(Console.ReadLine());

        switch (numero)
        {
            case 1:
                Entrar();
                break;
            case 2:
                Criar();
                break;
            case 0:
                Environment.Exit(0);
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Digite uma opção correta");
                Thread.Sleep(2000);
                Menu();
                break;
        }
    }
    catch
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Digite uma opção correta");
        Thread.Sleep(2000);
        Menu();
    }
}
void Criar()
{
    Console.Clear();
    using (ContaCorrente usuario = new ContaCorrente())
    {
        Console.Write("Digite seu nome: ");
        usuario.Titular = Console.ReadLine();
        gerenciador.Criar(usuario);

        Console.WriteLine($"Bem vindo(a) {usuario.Titular}, sua conta foi criada!");
        Console.WriteLine($"Número da sua conta é: {usuario.Numero}");
        Thread.Sleep(5000);

    }
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Pressione uma tecla para voltar ao menu");
    Console.ReadKey();
    Menu();
}
void Entrar()
{
    Console.Write("Digite número de sua conta: ");
    string numero = Console.ReadLine();

    if (numero.Length == 0)
    {
        Console.WriteLine("Digite um valor correto!");
    }
    else
    {
        usuario = gerenciador.Entrar(numero);
        if (usuario == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Usuario não encontrado!");
            Thread.Sleep(5000);
            Menu();
        }
        else
        {
            Console.WriteLine("Entrando...");
            MenuUsuario();
        }
    }
}
void MenuUsuario()
{
    using (usuario)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"Número: {usuario.Numero}");
        Console.WriteLine($"Titular: {usuario.Titular}");

        if (usuario.Saldo <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Saldo: {usuario.Saldo}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.WriteLine($"Saldo: {usuario.Saldo}");
        }

        Console.WriteLine();

        Console.WriteLine("1) Transferir dinheiro");
        Console.WriteLine("2) Depositar dinheiro");
        Console.Write("Escolha uma opção: ");
        ushort opcao = ushort.Parse(Console.ReadLine());

        switch (opcao)
        {
            case 1:
                Transferir();
                break;
            case 2:
                Depositar();
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Digite uma opção correta");
                Thread.Sleep(2000);
                MenuUsuario();
                break;
        }
    }
}
void Transferir()
{
    using (usuario)
    {
        Console.ForegroundColor = ConsoleColor.White;
        if (usuario.Saldo <= 0)
        {
            Console.WriteLine("Você não tem saldo para transferir");
        }
        else
        {
            try
            {
                Console.Write("Digite número do destinatário: ");
                string destinatario = Console.ReadLine();

                Console.Write("Digite valor a ser transferido: ");
                double valor = double.Parse(Console.ReadLine());

                if (valor <= 0 || valor == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Digite um valor correto!");
                    Transferir();
                }
                else
                {
                    if (valor > usuario.Saldo)
                    {
                        Console.WriteLine("Você não tem saldo suficiente!");
                    }
                    else
                    {
                        gerenciador.Transferir(usuario.Numero, destinatario, valor);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"R${valor} foram transferidos");

                        usuario = gerenciador.Entrar(usuario.Numero);

                        Thread.Sleep(5000);
                        MenuUsuario();
                    }
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Digite um valor correto!");
                Transferir();
            }
        }
    }
}
void Depositar()
{
    using (usuario)
    {
        Console.ForegroundColor = ConsoleColor.White;
        try
        {
            Console.Write("Digite o valor para depositar: ");
            double valor = double.Parse(Console.ReadLine());

            if (valor <= 0 || valor == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Digite um valor correto!");
                Transferir();
            }
            else
            {
                gerenciador.Depositar(usuario, valor);

                usuario = gerenciador.Entrar(usuario.Numero);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"R${valor} foram depositados em sua conta!");
                Thread.Sleep(5000);
                MenuUsuario();
            }
        }
        catch
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Digite um valor correto!");
            Transferir();
        }
    }
}

Menu();
