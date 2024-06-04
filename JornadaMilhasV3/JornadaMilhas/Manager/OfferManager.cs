using JornadaMilhas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Manager
{
    public class OfferManager
    {
        private List<TravelOffer> travelOffer = new List<TravelOffer>();

        public OfferManager(List<TravelOffer> travelOffer)
        {
            this.travelOffer = travelOffer;
        }

        public void RegisterOffer()
        {
            Console.WriteLine("-- Cadastro de ofertas --");
            Console.WriteLine("Informe a cidade de origem: ");
            string origin = Console.ReadLine();

            Console.WriteLine("Informe a cidade de destino: ");
            string destination = Console.ReadLine();

            Console.WriteLine("Informe a data de ida (DD/MM/AAAA): ");
            DateTime startDate;
            if (!DateTime.TryParse(Console.ReadLine(), out startDate))
            {
                Console.WriteLine("Data de ida inválida.");
                return;
            }

            Console.WriteLine("Informe a data de volta (DD/MM/AAAA): ");
            DateTime endDate;
            if (!DateTime.TryParse(Console.ReadLine(), out endDate))
            {
                Console.WriteLine("Data de volta inválida.");
                return;
            }

            Console.WriteLine("Informe o preço: ");
            double price;
            if (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Formato de preço inválido.");
                return;
            }

            TravelOffer registerOffer = new TravelOffer(new Route(origin, destination), new Period(startDate, endDate), price);
            AddOfferInList(registerOffer);

            Console.WriteLine("\nOferta cadastrada com sucesso.");
        }

        public bool AddOfferInList(TravelOffer registerOffer)
        {
            if (registerOffer != null)
            {
                travelOffer.Add(registerOffer);
                return true;
            }
            return false;

        }


        public void LoadOffers()
        {
            AddOfferInList(new TravelOffer(new Route("São Paulo", "Curitiba"), new Period(new DateTime(2024, 1, 15), new DateTime(2024, 1, 20)), 500));
            AddOfferInList(new TravelOffer(new Route("Recife", "Rio de Janeiro"), new Period(new DateTime(2024, 2, 10), new DateTime(2024, 2, 15)), 700));
            AddOfferInList(new TravelOffer(new Route("Acre", "Brasília"), new Period(new DateTime(2024, 3, 5), new DateTime(2024, 3, 10)), 600));
        }

        public void ShowAllOffers()
        {
            Console.WriteLine("\nTodas as ofertas cadastradas: ");
            foreach (var oferta in travelOffer)
            {
                Console.WriteLine(oferta);
            }
        }
    }
}
