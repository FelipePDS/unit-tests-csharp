using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using JornadaMilhas.Manager;
using JornadaMilhas.Model;

namespace JornadaMilhas.Test
{
    public class OfferManagerGetBetterDiscount
    {
        [Fact]
        public void ReturnsOfferNullWhenListIsEmpty()
        {
            var list = new List<TravelOffer>();
            var manager = new OfferManager(list);
            Func<TravelOffer, bool> filter = o => o.Route.Destination.Equals("São Paulo");

            var offer = manager.GetBetterDiscount(filter);

            Assert.Null(offer);
        }

        [Fact]
        public void ReturnsSpecificOfferWhenDestinationSaoPauloAndDiscount40()
        {
            var fakerPeriod = new Faker<Period>()
                .CustomInstantiator(f =>
                {
                    DateTime startDate = f.Date.Soon();
                    return new Period(startDate, startDate.AddDays(30));
                });

            var route = new Route("Curitiba", "São Paulo");

            var fakerOffer = new Faker<TravelOffer>()
                .CustomInstantiator(f => new TravelOffer(
                    route,
                    fakerPeriod.Generate(),
                    100 * f.Random.Int(1, 100)
                ))
                .RuleFor(o => o.Discount, f => 40)
                .RuleFor(o => o.Active, f => true);

            var chosenOffer = new TravelOffer(route, fakerPeriod.Generate(), 80)
            {
                Discount = 40,
                Active = true
            };

            var inactiveOffer = new TravelOffer(route, fakerPeriod.Generate(), 70)
            {
                Discount = 40,
                Active = false
            };

            var offerList = fakerOffer.Generate(200);
            offerList.Add(chosenOffer);
            offerList.Add(inactiveOffer);

            var manager = new OfferManager(offerList);

            Func<TravelOffer, bool> filter = o => o.Route.Destination.Equals("São Paulo");
            var price = 40;

            var offer = manager.GetBetterDiscount(filter);

            Assert.NotNull(offer);
            Assert.Equal(price, offer.Price, 3);
        }
    }
}
