namespace BehaviorDrivenDevelopment.Service
{
    public interface IPricingService
    {
        decimal GetBasketTotalAmount(Basket basket);
    }

    public class PricingService : IPricingService
    {
        public decimal GetBasketTotalAmount(Basket basket)
        {
            if(!basket.Products.Any()) return 0;

            var basketValue = basket.Products.Sum(x=> x.Price);

            if (basket.User.IsLoggedIn)
            {
                return basketValue - (basketValue * 0.05m);
            }

            return basketValue; 
        }
    }

    public class Basket
    {
        public User User { get; set; } = null!;
        public List<Product> Products { get; } = new();
    }

    public class User
    {
        public bool IsLoggedIn { get; set; }
    }

    public class Product
    {
        public string Title { get; init; } = null!;
        public decimal Price { get; init; }
    }


}
