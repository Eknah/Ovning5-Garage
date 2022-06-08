namespace Ovning5_Garage.Vehicles
{
	public interface IVehicle
	{
		Colors Color { get; }
		string Name { get; }
		int NumberOfWheels { get; }
		string RegNumber { get; set; }

		string ToString();
	}
}