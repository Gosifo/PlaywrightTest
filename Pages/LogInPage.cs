using Microsoft.Playwright;

namespace UiPlaywrightTest.Pages
{
    public class LogInPage(IPage page) // This make it a primary constructor. (This is new C# syntax)
	{
        private readonly IPage _page = page; // Saves the Playwright page into a private field and means it cannot be changed later

		public ILocator LogInForm => _page.Locator(".auth0-lock-form");
    }
}
