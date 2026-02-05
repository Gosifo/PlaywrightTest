using Reqnroll;
using UiPlaywrightTest.Drivers;

[assembly: Parallelizable(ParallelScope.Fixtures)]  // Multiple scenarios can run at the same time and Each scenario gets its own Driver instance

namespace UiPlaywrightTest.Hooks
{
    [Binding]
    public class Hook(Driver driver) // This is a constructor for the Hook class that takes a Driver instance as a parameter. This allows us to use the same Driver instance across all scenarios, and ensures that each scenario gets its own fresh browser instance.
	{
        private readonly Driver _driver = driver;

        [BeforeScenario]
        public async Task BeforeScenario() // This runs before each scenario and Initializes Playwright, opens the browser, and creates a page
		{
            await _driver.InitializePlaywrightAsync();
        }

        [AfterScenario] // This runs after each scenario and Disposes of the Driver, which closes the browser and cleans up resources
		public void AfterScenario()
        {
            _driver.Dispose();
        }
    }
}