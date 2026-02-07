using static Microsoft.Playwright.Assertions;
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

		[Given("I navigate to evri site")]
		public async Task GivenINavigateToEvriSiteAsync()
		{
			await _homePage.NavigateAsync();
		}

		[When("I click on the login button")]
		[When("I select the login button")]
		public async Task WhenISelectTheLoginButtonAsync()
		{
			await _homePage.NavigateToLoginPageAsync();
		}

		[When("I enter invalid username and password credential for {string}")]
		public async Task WhenIEnterInvalidUsernameAndPasswordCredentialForAsync(string email)
		{
			await _logInPage.SubmitEmailAndPassword(email, "invalidPassword");
		}

		[When("I enter the from post code {string} to post code {string} and weight {string}")]
		public async Task WhenIEnterTheFromPostCodeToPostCodeAndWeightAsync(string fromPostCode, string toPostCode, string weight)
		{
			await _homePage.FillInParcelAsync(fromPostCode, toPostCode, weight);
		}

		[When("select send a parcel button")]
		public async Task WhenSelectSendAParcelButtonAsync()
		{
			await _homePage.SelectSendParcel();
		}

		[Then("I should see the {string} page")]
		public async Task ThenIShouldSeeThePageAsync(string expectedPageTitle)
		{
			await Expect(_driver.Page).ToHaveTitleAsync(expectedPageTitle);
		}

		[Then("I should see the login form")]
		public async Task ThenIShouldSeeTheLoginFormAsync()
		{
			await Expect(_logInPage.LogInForm).ToBeVisibleAsync();
		}
	}
}