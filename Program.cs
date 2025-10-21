using System.Text;
using DesafioProjetoHospedagem.Models;
using Newtonsoft.Json;

Suite _suite;
Reserva _reserva1;
int _quantidadeHospedes = 0;

Console.OutputEncoding = Encoding.UTF8;

//
LeituraArquivo leituraArquivoSuite = new LeituraArquivo();
if (!leituraArquivoSuite.VerificarSeExisteArquivo(@"Arquivos/suites.json"))
{
    Console.WriteLine("Arquivo Criado");
    LeituraArquivo.MontarArquivoSuites();
}

Console.WriteLine(leituraArquivoSuite.VerificarSeExisteArquivo(@"Arquivos/suites.json"));

//Console.WriteLine(suiteSeialize);

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

Pessoa p1 = new Pessoa(nome: "Hóspede 1");
Pessoa p2 = new Pessoa(nome: "Hóspede 2");

hospedes.Add(p1);
hospedes.Add(p2);

// Cria a suíte
//Suite suite = new Suite(id: 1, tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);
List<Suite> listSuitesOpcoes = leituraArquivoSuite.LerArquivo(@"Arquivos/suites.json");

//Escolha Uma Suite
Console.WriteLine("Digite Sua Opcao de Suite");
foreach (Suite item in listSuitesOpcoes)
{
    Console.WriteLine($"{item.Id} - {item.TipoSuite} - Capacidade: {item.Capacidade} - Diaria: {item.ValorDiaria:c}");
}

switch (Console.ReadLine())
{
    case "1":

        Console.WriteLine("Digite Quantidade De Hospedes");
        _quantidadeHospedes = int.Parse(Console.ReadLine());
        // Cria uma nova reserva, passando a suíte e os hóspedes
        _reserva1 = new Reserva(diasReservados: 10);
        //int id, string tipoSuite, int capacidade, decimal valorDiaria
        _suite = new Suite(listSuitesOpcoes[0].Id, listSuitesOpcoes[0].TipoSuite, listSuitesOpcoes[0].Capacidade, listSuitesOpcoes[0].ValorDiaria);
        _reserva1.CadastrarSuite(_suite);
        _reserva1.CadastrarHospedes(hospedes, _quantidadeHospedes);

        Console.WriteLine($"Hóspedes: {_reserva1.ObterQuantidadeHospedes()}");
        Console.WriteLine($"Valor diária: {_reserva1.CalcularValorDiaria():c}" + (_reserva1.DiasReservados >= 10 ? " Teve desconto de 10%" : ""));


        Console.WriteLine("-------------- Resultado Dentro da escolha");
        break;
    case "2":
        Console.WriteLine("Digite Quantidade De Hospedes");
        _quantidadeHospedes = int.Parse(Console.ReadLine());
        // Cria uma nova reserva, passando a suíte e os hóspedes
        _reserva1 = new Reserva(diasReservados: 5);
        //int id, string tipoSuite, int capacidade, decimal valorDiaria
        _suite = new Suite(listSuitesOpcoes[1].Id, listSuitesOpcoes[1].TipoSuite, listSuitesOpcoes[1].Capacidade, listSuitesOpcoes[1].ValorDiaria);
        _reserva1.CadastrarSuite(_suite);
        _reserva1.CadastrarHospedes(hospedes, _quantidadeHospedes);

        Console.WriteLine($"Hóspedes: {_reserva1.ObterQuantidadeHospedes()}");
        Console.WriteLine($"Valor diária: {_reserva1.CalcularValorDiaria()}");

        Console.WriteLine("-------------- Resultado Dentro da escolha");
        break;
    case "3":
        Console.WriteLine("Digite Quantidade De Hospedes");
        _quantidadeHospedes = int.Parse(Console.ReadLine());
        // Cria uma nova reserva, passando a suíte e os hóspedes
        _reserva1 = new Reserva(diasReservados: 5);
        //int id, string tipoSuite, int capacidade, decimal valorDiaria
        _suite = new Suite(listSuitesOpcoes[2].Id, listSuitesOpcoes[2].TipoSuite, listSuitesOpcoes[2].Capacidade, listSuitesOpcoes[2].ValorDiaria);
        _reserva1.CadastrarSuite(_suite);
        _reserva1.CadastrarHospedes(hospedes, _quantidadeHospedes);

        Console.WriteLine($"Hóspedes: {_reserva1.ObterQuantidadeHospedes()}");
        Console.WriteLine($"Valor diária: {_reserva1.CalcularValorDiaria()}");

        Console.WriteLine("-------------- Resultado Dentro da escolha");
        break;
    default:
        Console.WriteLine("escolha invalida");
        break;
}

Console.WriteLine("INICIANDO TESTE JA PREENCHIDO");
Suite suite = new Suite(id: 1, tipoSuite: "MASTER", capacidade: 6, valorDiaria: 80);
// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva(diasReservados: 10);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes, 6);

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria():c}" + (reserva.DiasReservados >= 10 && reserva.CalcularValorDiaria() > 0 ? " Teve Desconto de 10 %" : ""));


Console.WriteLine("INICIANDO TESTE 2 JA PREENCHIDO");
Suite suite2 = new Suite(id: 2, tipoSuite: "DUPLEX", capacidade: 2, valorDiaria: 30);
// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva2 = new Reserva(diasReservados: 6);
reserva2.CadastrarSuite(suite2);
reserva2.CadastrarHospedes(hospedes, 3);

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine($"Hóspedes: {reserva2.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor diária: {reserva2.CalcularValorDiaria():c}" + (reserva2.DiasReservados >= 10 && reserva2.CalcularValorDiaria() > 0 ? " Teve Desconto de 10 %" : ""));

Console.WriteLine("INICIANDO TESTE 2 JA PREENCHIDO");
Suite suite3 = new Suite(id: 2, tipoSuite: "PREMIUM", capacidade: 4, valorDiaria: 70);
// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva3 = new Reserva(diasReservados: 9);
reserva3.CadastrarSuite(suite2);
reserva3.CadastrarHospedes(hospedes, 4);

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine($"Hóspedes: {reserva3.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor diária: {reserva3.CalcularValorDiaria():c}" + (reserva3.DiasReservados >= 10 && reserva3.CalcularValorDiaria() > 0 ? " Teve Desconto de 10 %" : ""));