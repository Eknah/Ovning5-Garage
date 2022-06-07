
namespace Ovning5_Garage.Vehicles
{
	internal abstract class Vehicle
	{
		public Colors Color { get; }
		public int NumberOfWheels { get; } = 0;
		public abstract string Name { get; }

		private string regNumber = string.Empty;

		public string RegNumber
		{
			get
			{
				return regNumber;
			}
			set
			{
				var valueUpper = value.ToUpper();
				if (RegisteredRegNumbers.Contains(valueUpper))
				{
					throw new ArgumentException("Reg.numret är redan registrerat för ett befintligt fordon.");
				}

				RegisteredRegNumbers.Add(valueUpper);
				regNumber = valueUpper;
			}
		}

		private static HashSet<string> RegisteredRegNumbers = new();

		public Vehicle(Colors color, int numberOfWheels, string regNumber)
		{
			Color = color;
			NumberOfWheels = numberOfWheels;
			RegNumber = regNumber;
		}

		// Base string output shared for all vehicles
		public override string ToString() => $"Typ: {Name},       \tFärg: {Color}, \tAntal hjul: {NumberOfWheels}, \tReg.Nr: {regNumber}";
	}
}
