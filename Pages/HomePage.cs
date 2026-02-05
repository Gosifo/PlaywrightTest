using Microsoft.Playwright;

namespace UiPlaywrightTest.Pages
{
    public class HomePage(IPage page) // This make it a primary constructor. (This is new C# syntax)
	{
        private readonly IPage _page = page; // Saves the Playwright page into a private field and means it cannot be changed later

		//private ILocator CookieAcceptAllButton => _page.Locator("#onetrust-accept-btn-handler");
		private ILocator CookieAcceptAllButton => _page.Locator(":text-is('Accept all')");
        private ILocator LogInButton => _page.Locator("//button[@type='button'][normalize-space()='Log in']");
		public ILocator FromPostcodeField => _page.Locator("[name='From postcode']");
		public ILocator ToPostcodeField => _page.Locator("[name='To postcode']");
		public ILocator WeightField => _page.Locator("[data-test-id='weight-choice-select-control']");
		public ILocator SendAParcelBtn => _page.Locator("button[data-test-id='send-entry-submit']");

		public async Task NavigateAsync()
        {
            await _page.GotoAsync("https://www.evri.com/");
            await CookieAcceptAllButton.ClickAsync();
        }

        public async Task NavigateToLoginPageAsync()
        {
            await LogInButton.ClickAsync();
            await Task.Delay(2000);
        }

		public async Task FillInParcelAsync(string fromPostcode, string toPostcode, string weight)
		{
            await FromPostcodeField.FillAsync(fromPostcode);
            await ToPostcodeField.FillAsync(toPostcode);
            await WeightField.SelectOptionAsync(weight);
		}

		public async Task SelectSendParcel()
		{
			await SendAParcelBtn.ClickAsync();
		}
	}
}
