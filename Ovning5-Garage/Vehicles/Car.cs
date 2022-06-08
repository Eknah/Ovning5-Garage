
namespace Ovning5_Garage.Vehicles
{
	public class Car : Vehicle 
	{

		public FuelTypes FuelType { get; }
		public override string Name { get; } = "Bil";

		public Car(Colors color, int numberOfWheels, string regNumber, FuelTypes fuelType) : base(color, numberOfWheels, regNumber)
		{
			FuelType = fuelType;
		}

		public override string ToString()
		{
			return base.ToString() + $",      Bränsletype: {FuelType}"; // Add fuel type to string output
		}
	}
}
