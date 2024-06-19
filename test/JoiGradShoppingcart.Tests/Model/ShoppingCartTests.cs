using System.Collections.Generic;
using JoiGradShoppingcart.Model;
using Xunit;

namespace JoiGradShoppingcart.Tests.Model
{
    public class ShoppingCartTests
    {
        [Fact]
        public void should_calculate_price_for_no_discount()
        {
            var shoppingCart = new ShoppingCart(new Customer("test"), new List<Product>
            {
                new Product(100, "No_discount_ABCD", "T")
            });

            var order = shoppingCart.Checkout();

            Assert.Equal(100.0, order.TotalPrice);
        }

        [Fact]
        public void should_calculate_loyalty_points_for_no_discount()
        {
            var shoppingCart = new ShoppingCart(new Customer("test"), new List<Product>
            {
                new Product(100, "No_discount_ABCD", "T")
            });

            var order = shoppingCart.Checkout();

            Assert.Equal(20, order.LoyaltyPoints);
        }

        [Fact]
        public void should_calculate_price_for_10_percent_discount()
        {
            var shoppingCart = new ShoppingCart(new Customer("test"), new List<Product>
            {
                new Product(100, "DIS_10_ABCD", "T")
            });

            var order = shoppingCart.Checkout();

            Assert.Equal(90.0, order.TotalPrice);
        }

        [Fact]
        public void should_calculate_loyalty_for_10_percent_discount()
        {
            var shoppingCart = new ShoppingCart(new Customer("test"), new List<Product>
            {
                new Product(100, "DIS_10_ABCD", "T")
            });

            var order = shoppingCart.Checkout();

            Assert.Equal(10, order.LoyaltyPoints);
        }

        [Fact]
        public void should_calculate_price_for_15_percent_discount()
        {
            var shoppingCart = new ShoppingCart(new Customer("test"), new List<Product>
            {
                new Product(100, "DIS_15_ABCD", "T")
            });

            var order = shoppingCart.Checkout();

            Assert.Equal(85.0, order.TotalPrice);
        }

        [Fact]
        public void should_calculate_loyalty_for_15_percent_discount()
        {
            var shoppingCart = new ShoppingCart(new Customer("test"), new List<Product>
            {
                new Product(100, "DIS_15_ABCD", "T")
            });

            var order = shoppingCart.Checkout();

            Assert.Equal(6, order.LoyaltyPoints);
        }


        [Fact]
        public void should_calculate_price_for_20_percent_discount()
        {
            var shoppingCart = new ShoppingCart(new Customer("test"), new List<Product>
            {
                new Product(100, "DIS_20_ABCD", "T")
            });

            var order = shoppingCart.Checkout();

            Assert.Equal(80.0, order.TotalPrice);
        }

        [Fact]
        public void should_calculate_loyalty_for_20_percent_discount()
        {
            var shoppingCart = new ShoppingCart(new Customer("test"), new List<Product>
            {
                new Product(100, "DIS_20_ABCD", "T")
            });

            var order = shoppingCart.Checkout();

            Assert.Equal(5, order.LoyaltyPoints);
        }

        [Fact]
        public void should_discount_5_percent_for_price_over_500()
        {
            var shoppingCart = new ShoppingCart(new Customer("test"), new List<Product>
            {
                new Product(6000, "ABCD", "T")
            });

            var order = shoppingCart.Checkout();

            Assert.Equal(5700, order.TotalPrice);
        }

        [Fact]
        public void should_buy_2get1_free_get_1_promotion()
        {
            var products = new List<Product>
            {
                new Product(100, "BULK_BUY_2_GET_1_ABCD", "A"),
                new Product(100, "BULK_BUY_2_GET_1_ABCD", "B"),
                new Product(100, "BULK_BUY_2_GET_1_ABCD", "C"),
                 new Product(100, "BULK_BUY_2_GET_1_BBBB", "D")
            };
            var shoppingCart = new ShoppingCart(new Customer("test"), products);

            var order = shoppingCart.Checkout();

            Assert.Equal(300, order.TotalPrice);
        }

        [Fact]
        public void should_buy_2get1_free_no_promotion()
        {
            var products = new List<Product>
            {
                new Product(100, "BULK_BUY_2_GET_1_ABCD", "A"),
                new Product(100, "BULK_BUY_2_GET_1_ABCD", "B"),
                 new Product(100, "BULK_BUY_2_GET_1_BBBB", "C")
            };
            var shoppingCart = new ShoppingCart(new Customer("test"), products);

            var order = shoppingCart.Checkout();

            Assert.Equal(300, order.TotalPrice);
        }

        [Fact]
        public void should_buy_2get1_free_get_2_promotion()
        {
            var products = new List<Product>
            {
                new Product(100, "BULK_BUY_2_GET_1_ABCD", "A"),
                new Product(100, "BULK_BUY_2_GET_1_ABCD", "B"),
                new Product(100, "BULK_BUY_2_GET_1_ABCD", "C"),
                 new Product(100, "BULK_BUY_2_GET_1_BBBB", "D"),
                 new Product(100, "BULK_BUY_2_GET_1_BBBB", "E"),
                 new Product(100, "BULK_BUY_2_GET_1_BBBB", "F")
            };
            var shoppingCart = new ShoppingCart(new Customer("test"), products);

            var order = shoppingCart.Checkout();

            Assert.Equal(400, order.TotalPrice);
        }
    }
}