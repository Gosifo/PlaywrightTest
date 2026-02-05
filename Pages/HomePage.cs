using Microsoft.Playwright;

namespace UiPlaywrightTest.Pages
{
    public class HomePage(IPage page) // This make it a primary constructor. (This is new C# syntax)
	{
        private readonly IPage _page = page; // Saves the Playwright page into a private field and means it cannot be changed later

		//private ILocator CookieAcceptAllButton => _page.Locator("#onetrust-accept-btn-handler");
		private ILocator CookieAcceptAllButton => _page.Locator(":text-is('Accept all')");
        private ILocator LogInButton => _page.Locator("//button[@type='button'][normalize-space()='Log in']");



        public async Task NavigateAsync()
        {
            await _page.GotoAsync("https://www.evri.com/");
            //await _cookieAcceptAllButton.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await CookieAcceptAllButton.ClickAsync();
        }

        public async Task NavigateToLoginPageAsync()
        {
            await LogInButton.ClickAsync();

            await Task.Delay(2000);
        }
    }
}
