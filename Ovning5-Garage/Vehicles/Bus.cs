
namespace Ovning5_Garage.Vehicles
{
	internal class Bus : Vehicle 
	{

		public int NumberOfSeats { get; }
		public override string Name { get; } = "Buss";

		public Bus(Colors color, int numberOfWheels, string regNumber, int numberOfSeats) : base(color, numberOfWheels, regNumber)
		{
			NumberOfSeats = numberOfSeats;
		}

		public override string ToString()
		{
			return base.ToString() + $", Antal sitsar: {NumberOfSeats}";
		}

	}
}
