using AgendaTelefonicaComBancoDeDados.Context;
using AgendaTelefonicaComBancoDeDados.Models;


public class program
{
    static async Task Main()
    {
        Console.WriteLine("Bem vindo ao sistema de Agendas. \n" +
                          "Pressione qualquer tecla para iniciar.");
        Console.ReadKey();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Escolha uma das seguintes opções e tecle ENTER");
            Console.Write("1: Para cadastrar um contato. \n" +
                          "2: Modificar algum contato. \n" +
                          "3: Exibir um contato. \n" +
                          "4: Exibir TODOS contatos \n" +
                          "Para SAIR pressione qualquer outra tecla \n" +
                          "Sua opção: ");

            int opcao = int.TryParse(Console.ReadLine(), out opcao) ? opcao : 0;
            Console.Clear();
            if (opcao != 0) Console.WriteLine($"Você digitou {opcao}! \n");

            switch (opcao)
            {
                case 1:
                    await CadastrarContato();
                    break;

                case 2:
                    await ModificarContato();

                    break;

                default:
                    Console.WriteLine("Obrigado por utilizar nossos serviços!");
                    Console.WriteLine("Pressione qualquer tecla para SAIR.");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
            }
        }
    }

    static async Task CadastrarContato()
    {
        var contato = new Agenda();
        Console.WriteLine($"Cadastrar contato...");
        Console.Write("Digite o nome do contato: ");
        contato.Nome = Console.ReadLine();
        Console.Write("Digite o número do telefone (apenas números): ");
        while (true)
        {
            if (uint.TryParse(Console.ReadLine(), out uint telefone))
            {
                contato.NumeroTelefone = telefone.ToString();
                break;
            }

            else
                Console.WriteLine("Erro de digitação!");

            Console.WriteLine("\nPressione qualquer tecla para VOLTAR. \n");
            Console.ReadKey();
        }
        Console.Write("Digite o email do contato: ");
        contato.Email = Console.ReadLine();

        using (var context = new DataBaseContext())
        {
            context.Agendas.Add(contato);
            await context.SaveChangesAsync();
            Console.WriteLine("Contato Adicionado");
            Console.WriteLine("Pressione qualquer tecla para retornar");
            Console.ReadKey();
        }

    }

    static async Task ModificarContato()
    {
        //int id;
        var contato = new Agenda();

        while (true)
        {
            Console.Clear();
            Console.Write("Digite o ID do contato: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                contato.Id = id;
                break;
            }
            else
            {
                Console.WriteLine("Erro de digitação!");
            }
            Console.WriteLine("\nPressione qualquer tecla para VOLTAR. \n");
            Console.ReadKey();
        }

        Console.Write("Digite o nome do contato: ");
        contato.Nome = Console.ReadLine();
        //contato.Nome = string.IsNullOrEmpty(nome) ? contato.Email : nome;

        Console.Write("Digite o email do contato: ");
        contato.Email = Console.ReadLine();
        //contato.Email = string.IsNullOrEmpty(email) ? contato.Email : email;



        while (true)
        {
            //Console.Clear();
            Console.Write("Digite o número do telefone (apenas números): ");
            if (uint.TryParse(Console.ReadLine(), out uint telefone))
            {
                contato.NumeroTelefone = telefone.ToString();
                break;
            }

            else
                Console.WriteLine("Erro de digitação!");

            Console.WriteLine("\nPressione qualquer tecla para VOLTAR. \n");
            Console.ReadKey();
        }
        Agenda resultadoAgenda;
        using (var context = new DataBaseContext())
        {
            resultadoAgenda = context.Agendas.FirstOrDefault(x => x.Id == contato.Id);

            contato.Nome = string.IsNullOrEmpty(contato.Nome) ? resultadoAgenda.Nome : contato.Nome;
            contato.Email = string.IsNullOrEmpty(contato.Email) ? resultadoAgenda.Email : contato.Email;

            if (resultadoAgenda == null)
            {
                Console.WriteLine("Contato Inexistente");
                Console.ReadKey();
            }
            else
            {
                try
                {
                    int DecorarId = resultadoAgenda.Id;
                    var resultado = Clonar(contato, resultadoAgenda);
                    resultado.Id = DecorarId;
                    context.Agendas.Update(resultado);
                    await context.SaveChangesAsync();
                    Console.WriteLine("Contato Atualizado");
                    Console.WriteLine("Pressione qualquer tecla para retornar");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            }

        }


    }
    // Método que clona propriedades para poder atualizar
    static Agenda Clonar(Agenda entrada, Agenda saida)
    {
        Type propType1 = entrada.GetType();
        Type propType2 = saida.GetType();
        foreach (var info in propType1.GetProperties())
        {
            propType2.GetProperty(info.Name)
                .SetValue(saida, info.GetValue(entrada));
        }
        return saida;
    }

}









/* 
Abre uma instância do banco e cria as tabelas caso não existam. 
Se criar uma nova tabela, esse comando não funciona mais
using (var context = new DataBaseContext())
{
    context.Database.EnsureCreated();
    
    Console.WriteLine("Hello, Worldxxxxxxxxxxxx!");
}
*/




