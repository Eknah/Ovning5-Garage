
namespace Ovning5_Garage.Vehicles
{
	internal class Airplane : Vehicle
	{

		public int NumberOfEngines { get; }
		public override string Name { get; } = "Flygplan";

		public Airplane(Colors color, int numberOfWheels, string regNumber, int numberOfEngines) : base(color, numberOfWheels, regNumber)
		{
			NumberOfEngines = numberOfWheels;
		}

		public override string ToString()
		{
			return base.ToString() + $",      Antal motorer: {NumberOfEngines}"; // Add nr of engines to string output
		}
	}
}
