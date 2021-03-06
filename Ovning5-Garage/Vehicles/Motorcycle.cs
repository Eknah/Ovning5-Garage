
namespace Ovning5_Garage.Vehicles
{
	public class Motorcycle : Vehicle
	{

		public double CylinderVolume { get; }
		public override string Name { get; } = "Motorcykel";

		public Motorcycle(Colors color, int numberOfWheels, string regNumber, double cylinderVolume) : base(color, numberOfWheels, regNumber)
		{
			CylinderVolume = cylinderVolume;
		}


		public override string ToString()
		{
			return base.ToString() + $",      Cylindervolym: {CylinderVolume}"; // Add cylinder volume to string output
		}
	}
}
