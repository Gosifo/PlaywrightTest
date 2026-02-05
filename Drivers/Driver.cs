using Microsoft.Playwright;

namespace UiPlaywrightTest.Drivers
{
	// This class is responsible for:
	// - Starting Playwright
	// - Opening a browser
	// - Creating a page
	// - Closing everything when finished

	public class Driver : IDisposable
    {
        private IPlaywright _playwright = null!;   // Playwright engine (controls browsers)
		private IBrowser _browser = null!;         // A browser is an instance of the actual browser application (like Chrome or Firefox).
		private IBrowserContext _context = null!;  // A browser context is like a fresh browser profile.
		public IPage Page { get; private set; } = null!; // This is the actual web page / tab you interact with.

		public async Task InitializePlaywrightAsync()
        {
            _playwright = await Playwright.CreateAsync();  // Initializes the Playwright engine and prepares it to launch browsers

			_browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions // Open the Chromium browser (visible window)
			{
                Headless = false, // Show the browser
			});

            _context = await _browser.NewContextAsync(new BrowserNewContextOptions //This creates a fresh browser session.
			{
                ViewportSize = null // The browser opens maximized and of a fixed resolution like 1280x720

			});

            Page = await _context.NewPageAsync(); // Open a new tab (page)
		}

        public void Dispose()
        {
            if (_browser != null)     // Close the browser if it exists
				_browser.CloseAsync();

            _playwright?.Dispose();  // This disposes of the Playwright instance, cleaning up any resources it was using.
		}
    }
}
