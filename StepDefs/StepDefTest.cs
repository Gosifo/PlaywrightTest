using Microsoft.Playwright;
using Reqnroll;
using UiPlaywrightTest.Drivers;
using UiPlaywrightTest.Pages;

namespace UiPlaywrightTest.StepDefs
{
    [Binding]
    public sealed class StepDefTest
    {
        private readonly Driver _driver;
        private HomePage _homePage;
        private LogInPage _logInPage;

        public StepDefTest(Driver driver)
        {
            _driver = driver;
            _homePage = new HomePage(_driver.Page);
            _logInPage = new LogInPage(_driver.Page);
        }

        [Given("I navigate to the Evri page")]
        public async Task GivenINavigateToTheEvriPageAsync()
        {
            await _homePage.NavigateAsync();
        }

        [When("I click on the login button")]
        public async Task WhenIClickOnTheLoginButtonAsync()
        {
            await _homePage.NavigateToLoginPageAsync();
        }

        [Then("I should see the login form")]
        public async Task ThenIShouldSeeTheLoginFormAsync()
        {
            await Assertions.Expect(_logInPage.LogInForm).ToBeVisibleAsync();
        }
    }
}