using JornadaMilhas.Manager;
using JornadaMilhas.Model;

List<TravelOffer> travelOfferList = new List<TravelOffer>();
var manager = new OfferManager(travelOfferList);

manager.LoadOffers();

while (true)
{
    ShowMenu();

    Console.WriteLine("Boas vindas ao Jornada Milhas. Escolha uma opção:");
    string option = Console.ReadLine()!;

    switch (option)
    {
        case "1":
            manager.RegisterOffer();
            break;
        case "2":
            manager.ShowAllOffers();
            break;
        case "3":
            Console.WriteLine("Ofertas com maior desconto:");
            return;
        case "4":
            Console.WriteLine("Obrigada por utilizar o Jornada Milhas. Até mais!");
            return;
        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }

    Console.WriteLine("\nPressione qualquer tecla para continuar...");
    Console.ReadKey();
    Console.Clear();
}

static void ShowMenu()
{
    Console.WriteLine("-------- Painel Administrativo - Jornada Milhas --------");
    Console.WriteLine("1. Cadastrar Ofertas");
    Console.WriteLine("2. Mostrar Todas as Ofertas");
    Console.WriteLine("3. Exibir maiores descontos");
    Console.WriteLine("4. Sair");
}
