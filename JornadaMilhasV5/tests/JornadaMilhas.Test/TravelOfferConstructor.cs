using JornadaMilhas.Model;
using System.Diagnostics;

namespace JornadaMilhas.Test
{
    public class TravelOfferConstructor
    {
        [Fact]
        public void ReturnsValidRouteWhenDataIsValid()
        {
            Route route = new("OrigemTeste", "DestinoTeste");

            Assert.True(route.IsValid);
        }

        [Fact]
        public void ReturnsInvalidRouteAndErrorMessageWhenDataIsInvalid()
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
        public void ReturnInvalidPeriodAndErrorMessageWhenDateIsInvalid()
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

        [Theory]
        [InlineData("", null, "2024-01-01", "2024-01-02", 0, false)]
        [InlineData("OrigemTeste", "DestinoTeste", "2024-02-01", "2024-02-05", 100.0, true)]
        [InlineData(null, "São Paulo", "2024-01-01", "2024-01-02", -1, false)]
        [InlineData("Vitória", "São Paulo", "2024-01-01", "2024-01-01", 0, false)]
        [InlineData("Rio de Janeiro", "São Paulo", "2024-01-01", "2024-01-02", -500.0, false)]
        [InlineData("Rio de Janeiro", "São Paulo", "2024-01-08", "2024-01-02", -500.0, false)]
        public void ReturnOfferIsValidAccordingToInputData(string origin, string destination, string startDate, string endDate, double price, bool validation)
        {
            Route route = new(origin, destination);
            Period period = new(DateTime.Parse(startDate), DateTime.Parse(endDate));

            TravelOffer offer = new(route, period, price);

            Assert.Equal(validation, offer.IsValid);
        }

        [Fact]
        public void ReturnOfferErrorMessageWhenRouteIsNull()
        {
            Route route = null;
            Period period = new(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double price = 100.0;

            TravelOffer offer = new(route, period, price);

            Assert.Contains("A oferta de viagem não possui rota válida.", offer.Errors.Summary);
            Assert.False(offer.IsValid);
        }

        [Fact]
        public void ReturnOfferErrorMessageWhenPeriodIsNull()
        {
            Route route = new("OrigemTeste", "DestinoTeste");
            Period period = null;
            double price = 100.0;

            TravelOffer offer = new(route, period, price);

            Assert.Contains("A oferta de viagem não possui período válido.", offer.Errors.Summary);
            Assert.False(offer.IsValid);
        }

        [Fact]
        public void ReturnOfferErrorMessageWhenRouteIsInvalid()
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

        [Theory]
        [InlineData("OrigemTeste", "DestinoTeste", "2024-02-01", "2024-02-05", -50.0)]
        [InlineData("OrigemTeste", "DestinoTeste", "2024-02-01", "2024-02-05", 0)]
        public void ReturnOfferErrorMessageWhenPriceIsNegativeOrZero(string origin, string destination, string startDate, string endDate, double price)
        {
            Route route = new(origin, destination);
            Period period = new(DateTime.Parse(startDate), DateTime.Parse(endDate));

            TravelOffer offer = new(route, period, price);

            Assert.False(offer.IsValid);
            Assert.Contains("O preço da oferta de viagem deve ser maior que zero.", offer.Errors.Summary);
        }

        [Fact]
        public void ReturnThreeValidationErrorsWhenRoutePeriodAndPriceAreInvalids()
        {
            var errorsCountExpected = 3;

            Route route = null;
            Period period = new(new DateTime(2024, 02, 23), new DateTime(2024, 02, 01));
            var price = 0;

            TravelOffer offer = new(route, period, price);

            Assert.Equal(errorsCountExpected, offer.Errors.Count());
        }
    }
}
