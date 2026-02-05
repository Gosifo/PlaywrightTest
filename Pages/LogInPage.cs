using Microsoft.Playwright;
using UiPlaywrightTest.Drivers;

namespace UiPlaywrightTest.Pages
{
    public class LogInPage(IPage page) // This make it a primary constructor. (This is new C# syntax)
	{
        private readonly IPage _page = page; // Saves the Playwright page into a private field and means it cannot be changed later

		public ILocator LogInForm => _page.Locator(".auth0-lock-form");
		public ILocator EmailField => _page.Locator("[name='email']");
		public ILocator PasswordField => _page.Locator("[name='password']");
		public ILocator SubmitBtn => _page.Locator("button[name='submit']");

		public async Task SubmitEmailAndPassword(string email, string pwd)
		{
			await EmailField.FillAsync(email);
			await PasswordField.FillAsync(pwd);
			await SubmitBtn.ClickAsync();
		}
	}
}
