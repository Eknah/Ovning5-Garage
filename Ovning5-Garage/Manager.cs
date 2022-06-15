
namespace Ovning5_Garage
{
	internal class Manager
	{
		internal void StartApplication()
		{
			// Use abtraction for UI-object, instead of calling Console-methods
			// directly in the GarageHandler, which facilitates unit testing
			// with mocks and future development with other type of UIs.
			IUI ui = new ConsoleUI();
			IHandler garageHandler = new GarageHandler(ui);
			garageHandler.Start();
		}
	}
}
