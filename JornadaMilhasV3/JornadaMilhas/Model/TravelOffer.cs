using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Model
{
    public class TravelOffer : Validator
    {
        public const double MAX_DISCOUNT = 0.7;
        private double discount;

        public int Id { get; set; }
        public Route Route { get; set; }
        public Period Period { get; set; }
        public double Price { get; set; }
        public double Discount
        {
            get => discount;
            set
            {
                discount = value;

                if (discount > Price)
                {
                    Price *= (1 - MAX_DISCOUNT);
                }
                else
                {
                    Price -= discount;
                }
            }
        }

        public TravelOffer(Route route, Period period, double price)
        {
            Route = route;
            Period = period;
            Price = price;
            Validate();
        }

        public override string ToString()
        {
            return $"Origem: {Route.Origin}, Destino: {Route.Destination}, Data de Ida: {Period.StartDate.ToShortDateString()}, Data de Volta: {Period.EndDate.ToShortDateString()}, Preço: {Price:C}";
        }

        protected override void Validate()
        {
            if (Route == null || Period == null)
            {
                Errors.RegisterError("A oferta de viagem não possui rota ou período válidos.");
            }
            else
            {
                if (!Period.IsValid)
                    Errors.RegisterError(Period.Errors.Summary);

                if (!Route.IsValid)
                    Errors.RegisterError(Route.Errors.Summary);
            }

            if (Price <= 0)
                Errors.RegisterError("O preço da oferta de viagem deve ser maior que zero.");
        }
    }
}
