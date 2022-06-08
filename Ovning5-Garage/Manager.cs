
namespace Ovning5_Garage
{
	internal class Manager
	{
		internal void StartApplication()
		{
			IUI ui = new ConsoleUI();
			IHandler garageHandler = new GarageHandler(ui);
			garageHandler.Start();
		}
	}
}
