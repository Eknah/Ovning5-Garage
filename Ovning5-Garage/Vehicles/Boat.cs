
namespace Ovning5_Garage.Vehicles
{
	internal class Boat : Vehicle 
	{

		public int Length { get; }
		public override string Name { get; } = "Båt";

		public Boat(Colors color, int numberOfWheels, string regNumber, int length) : base(color, numberOfWheels, regNumber)
		{
			Length = length;
		}

		public override string ToString()
		{
			return base.ToString() + $", Längd: {Length}";
		}
	}
}
