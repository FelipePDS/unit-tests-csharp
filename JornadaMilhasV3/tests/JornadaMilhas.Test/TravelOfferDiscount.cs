using JornadaMilhas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Test
{
    public class TravelOfferDiscount
    {
        [Fact]
        public void ReturnPriceValidWhenDiscountIsApplied()
        {
            Route route = new("OrigemA", "OrigemB");
            Period period = new(new DateTime(2024, 05, 01), new DateTime(2024, 05, 10));
            double originalPrice = 100.00;
            double discount = 20.00;
            double priceWithDiscount = originalPrice - discount;

            TravelOffer offer = new(route, period, originalPrice);

            offer.Discount = discount;

            Assert.Equal(priceWithDiscount, offer.Price);
        }

        [Fact]
        public void ReturnMaxDiscountWhenDiscountIsGreaterThanPrice()
        {
            Route route = new("OrigemA", "OrigemB");
            Period period = new(new DateTime(2024, 05, 01), new DateTime(2024, 05, 10));
            double originalPrice = 100.00;
            double discount = 120.00;
            double priceWithDiscount = 30;

            TravelOffer offer = new(route, period, originalPrice);

            offer.Discount = discount;

            Assert.Equal(priceWithDiscount, offer.Price, 3);
        }
    }
}
