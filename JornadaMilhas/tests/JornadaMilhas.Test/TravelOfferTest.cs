using JornadaMilhas.Model;

namespace JornadaMilhas.Test
{
    public class TravelOfferTest
    {
        [Fact]
        public void RouteIsValid()
        {
            Route route = new("OrigemTeste", "DestinoTeste");

            Assert.True(route.IsValid);
        }

        [Fact]
        public void RouteIsInvalid()
        {
            Route routeWithOriginNull = new(null, "DestinoTeste");
            Route routeWithRouteEmpty = new(string.Empty, "DestinoTeste");

            Assert.Contains("A rota não pode possuir uma origem nula ou vazia.", routeWithOriginNull.Errors.Summary);
            Assert.DoesNotContain("A rota não pode possuir um destino nulo ou vazio.", routeWithOriginNull.Errors.Summary);
            Assert.False(routeWithOriginNull.IsValid);

            Assert.Contains("A rota não pode possuir uma origem nula ou vazia.", routeWithRouteEmpty.Errors.Summary);
            Assert.DoesNotContain("A rota não pode possuir um destino nulo ou vazio.", routeWithRouteEmpty.Errors.Summary);
            Assert.False(routeWithRouteEmpty.IsValid);

            Route routeWithDestinationNull = new("OrigemTeste", null);
            Route routeWithDestinationEmpty = new("OrigemTeste", string.Empty);

            Assert.Contains("A rota não pode possuir um destino nulo ou vazio.", routeWithDestinationNull.Errors.Summary);
            Assert.DoesNotContain("A rota não pode possuir uma origem nula ou vazia.", routeWithDestinationNull.Errors.Summary);
            Assert.False(routeWithDestinationNull.IsValid);

            Assert.Contains("A rota não pode possuir um destino nulo ou vazio.", routeWithDestinationEmpty.Errors.Summary);
            Assert.DoesNotContain("A rota não pode possuir uma origem nula ou vazia.", routeWithDestinationEmpty.Errors.Summary);
            Assert.False(routeWithDestinationEmpty.IsValid);

            Route routeNull = new(null, null);

            Assert.Contains("A rota não pode possuir uma origem nula ou vazia.", routeNull.Errors.Summary);
            Assert.Contains("A rota não pode possuir um destino nulo ou vazio.", routeNull.Errors.Summary);
            Assert.False(routeNull.IsValid);
        }

        [Fact]
        public void PeriodIsValid()
        {
            Period period = new(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));

            Assert.True(period.IsValid);
        }

        [Fact]
        public void PeriodIsInvalid()
        {
            Period periodWithoutStartDate = new(new DateTime(), new DateTime(2024, 2, 5));
            Period periodWithoutEndDate = new(new DateTime(2024, 2, 1), new DateTime());
            Period periodWithLaterStartDate = new(new DateTime(2024, 2, 5), new DateTime(2024, 2, 1));

            Assert.False(periodWithoutStartDate.IsValid);
            Assert.Contains("Erro: Data de ida não pode estar vazia.", periodWithoutStartDate.Errors.Summary);

            Assert.False(periodWithoutEndDate.IsValid);
            Assert.Contains("Erro: Data de volta não pode estar vazia.", periodWithoutEndDate.Errors.Summary);

            Assert.False(periodWithLaterStartDate.IsValid);
            Assert.Contains("Erro: Data de ida não pode ser maior que a data de volta.", periodWithLaterStartDate.Errors.Summary);
        }

        [Fact]
        public void OfferIsValid()
        {
            Route route = new("OrigemTeste", "DestinoTeste");
            Period period = new(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double price = 100.0;

            TravelOffer offer = new(route, period, price);

            Assert.True(offer.IsValid);
        }

        [Fact]
        public void OfferWithRouteNull()
        {
            Route route = null;
            Period period = new(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double price = 100.0;

            TravelOffer offer = new(route, period, price);

            Assert.Contains("A oferta de viagem não possui rota ou período válidos.", offer.Errors.Summary);
            Assert.False(offer.IsValid);
        }

        [Fact]
        public void OfferWithPeriodNull()
        {
            Route route = new("OrigemTeste", "DestinoTeste");
            Period period = null;
            double price = 100.0;

            TravelOffer offer = new(route, period, price);

            Assert.Contains("A oferta de viagem não possui rota ou período válidos.", offer.Errors.Summary);
            Assert.False(offer.IsValid);
        }

        [Fact]
        public void OfferWithoutPrice()
        {
            Route route = new("OrigemTeste", "DestinoTeste");
            Period period = new(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double price = 0;

            TravelOffer offer = new(route, period, price);

            Assert.Contains("O preço da oferta de viagem deve ser maior que zero.", offer.Errors.Summary);
            Assert.False(offer.IsValid);
        }

        [Fact]
        public void OfferWithRouteInvalid()
        {
            Route routeWithoutOrigin = new(null, "DestinoTeste");
            Route routeWithoutDestination = new("OrigemTeste", null);
            Period period = new(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double price = 0;

            TravelOffer offerWithoutRouteOrigin = new(routeWithoutOrigin, period, price);
            TravelOffer offerWithoutRoutePeriod = new(routeWithoutDestination, period, price);

            Assert.Contains("A rota não pode possuir uma origem nula ou vazia.", offerWithoutRouteOrigin.Errors.Summary);
            Assert.False(offerWithoutRouteOrigin.IsValid);

            Assert.Contains("A rota não pode possuir um destino nulo ou vazio.", offerWithoutRoutePeriod.Errors.Summary);
            Assert.False(offerWithoutRoutePeriod.IsValid);
        }

        //[Fact]
        //public void OfferWithPeriodInvalid()
        //{
            
        //}
    }
}
