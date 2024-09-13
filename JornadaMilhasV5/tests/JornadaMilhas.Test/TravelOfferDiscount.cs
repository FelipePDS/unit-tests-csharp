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

        [Theory]
        [InlineData(120.00, 30)]
        [InlineData(100.00, 30)]
        public void ReturnMaxDiscountWhenDiscountIsGreaterOrEqualsThanPrice(double discount, double priceWithDiscount)
        {
            Route route = new("OrigemA", "OrigemB");
            Period period = new(new DateTime(2024, 05, 01), new DateTime(2024, 05, 10));
            double originalPrice = 100.00;

            TravelOffer offer = new(route, period, originalPrice);

            offer.Discount = discount;

            Assert.Equal(priceWithDiscount, offer.Price, 3);
        }

        [Fact]
        public void ReturnPriceValidWhenDiscountIsNegative()
        {
            Route route = new("OrigemA", "OrigemB");
            Period period = new(new DateTime(2024, 05, 01), new DateTime(2024, 05, 10));
            double originalPrice = 100.00;
            double discount = -35.00;
            double priceWithDiscount = 100.00;

            TravelOffer offer = new(route, period, originalPrice);

            offer.Discount = discount;

            Assert.Equal(priceWithDiscount, offer.Price);
        }
    }
}
