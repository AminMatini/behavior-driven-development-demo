using BehaviorDrivenDevelopment.Service;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace BehaviorDrivenDevelopment.Tests.Behavior.Steps
{
    [Binding]
    public class LoggedInDiscountSteps
    {
        private User _user = null!;
        private Basket _basket = null!; 
        private readonly IPricingService _pricingService = new PricingService();

        [Given(@"a user that is not logged in")]
        public void GivenAUserThatIsNotLoggedIn()
        {
            _user = new User
            {
                IsLoggedIn = false
            };
        }

        [Given(@"an empty basket")]
        public void GivenAnEmptyBasket()
        {
            _basket = new Basket
            {
                User = _user,
            };
        }

        [When(@"a (.*) that costs (.*) GBP is added to the basket")]
        public void WhenAT_ShirtThatCostsGBPIsAddedToTheBasket(string itemName, decimal price)
        {
            _basket.Products.Add(new Product
            {
                Title = itemName , 
                Price = price   
            });
        }

        [Given(@"a user that is logged in")]
        public void GivenAUserThatIsLoggedIn()
        {
            _user = new User
            {
                IsLoggedIn = true
            };
        }

        [Then(@"the basket value is (.*) GBP")]
        public void ThenTheBasketValueIsGBP(decimal expectedBasketValue)
        {
            var basketValue = _pricingService.GetBasketTotalAmount(_basket);

            basketValue.Should().Be(expectedBasketValue);
        }

    }
}
