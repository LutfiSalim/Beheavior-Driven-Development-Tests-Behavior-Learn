using BehaviorDrivenDevelopment.Service;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace BeheaviorDrivenDevelopment.Tests.Behavior.Steps
{
    [Binding]
    public class LoggedInDiscountSteps  
    {
        private User _user;
        private Basket _basket;
        private readonly IPricingService _pricingService = new PricingService();
        //private List<Product> _products;

        [Given(@"a user that is not logged in")]
        public void GivenAUserThatIsNotLoggedIn()
        {
            _user = new User
            {
                IsLoggedIn = false
            };
        }

        [Given(@"a user that is logged in")]
        public void GivenAUserThatIsLoggedIn()
        {
            _user = new User
            {
                IsLoggedIn = true
            };
        }

        [Given(@"an empty basket")]
        public void GivenAnEmptyBasket()
        {
            _basket = new Basket
            {
                User = _user
            };
        }
        [When(@"a (.*) that costs (.*) GBP is added to the basket")]
        public void WhenAT_ShirtThatCostsGBPIsAddedToTheBasket(string itemName, decimal price)
        {
            _basket.Products.Add(new Product
            { Name = itemName,
            Price = price });
        }

        [Then(@"the basket value is (.*) GBP")]
        public void ThenTheBasketValueIsGBP(decimal expectebasketValue)
        {
            var basketValue = _pricingService.GetBasketTotalAmount(_basket);
            basketValue.Should().Be(expectebasketValue);
        }
        
    }
}
