using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace JoiGradShoppingcart.Model
{
    public class ShoppingCart
    {
        private Customer _customer;
        private List<Product> _products;
        private Dictionary<string, int> count_buy_2get1;
        public ShoppingCart(Customer customer, List<Product> products)
        {
            _customer = customer;
            _products = products;
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            _products.Remove(product);
        }

        public Order Checkout()
        {
            var totalPrice = CalculateTotalPrice();
            var loyaltyPointsEarned = CalculateLoyaltyPoint();
   
            totalPrice = totalPrice>=500 ? totalPrice*0.95 : totalPrice;
            return new Order(totalPrice, loyaltyPointsEarned);
        }
        private double CalculateTotalPrice()
        {
           return _products.Sum(product => product.Price - CalculateDiscount(product) );
        }
        private double CalculateDiscount(Product product)
        {
            double discount = 0.0;
            if (product.ProductCode.StartsWith("DIS_10"))
            {
                discount = product.Price * 0.1;
     
            }
            else if (product.ProductCode.StartsWith("DIS_15"))
            {
                discount = product.Price * 0.15;
            }
            else if (product.ProductCode.StartsWith("DIS_20"))
            {
                discount = product.Price * 0.20;
            }
            else if (product.ProductCode.StartsWith("BULK_BUY_2_GET_1"))
            {
                if (count_buy_2get1.ContainsKey(product.ProductCode))
                {
                    count_buy_2get1[product.ProductCode] += 1;
                }
                else
                {
                    count_buy_2get1.Add(product.ProductCode, 1);
                }
                if (count_buy_2get1[product.ProductCode] % 3 == 0)
                {
                    discount += product.Price;
                }
                
            }
            return discount;
        }
    }
        public override string ToString()
        {
            var productList = _products.Select(product => $"- {product.Name}, {product.Price}");
            return $"Customer: {_customer.Name}\n" + 
                $"Bought:  \n{String.Join("\n", productList)}";
        }    
    }
}