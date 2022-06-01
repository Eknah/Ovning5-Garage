
namespace Ovning5_Garage
{
	internal class Manager
	{
		internal void StartApplication()
		{
			ConsoleUI ui = new();
			GarageHandler garageHandler = new(ui);
			garageHandler.Start();
		}
	}
}
