
namespace Ovning5_Garage
{
	internal class ConsoleUI : IUI
	{
		public void Print(string text) => Console.WriteLine(text);

		public string ReadString() => Console.ReadLine() ?? String.Empty;

		public ConsoleKey ReadKey() // Read single key
		{
			var key = Console.ReadKey().Key;
			Console.WriteLine("\n");
			return key;
		}

		public int ReadInt() // Read int input safely
		{
			var input = ReadString();

			if (int.TryParse(input, out int result))
				return result;
			else // Input not an int
				throw new ArgumentException("Det angivna värdet var inte ett heltal.");
		}

		public Colors ReadColor() // Select from a set a predefined colors safely
		{
			Print("1) Blå");
			Print("2) Röd");
			Print("3) Grön");
			Print("4) Gul");
			Print("5) Vit");
			Print("6) Svart");
			Print("\n");
			var option = ReadKey();

			switch (option)
			{
				case ConsoleKey.D1:
					return Colors.Blue;
				case ConsoleKey.D2:
					return Colors.Red;
				case ConsoleKey.D3:
					return Colors.Green;
				case ConsoleKey.D4:
					return Colors.Yellow;
				case ConsoleKey.D5:
					return Colors.White;
				case ConsoleKey.D6:
					return Colors.Black;
				default: // Invalid input
					throw new ArgumentException("Felaktigt färgval.");
			}
		}

		public FuelTypes ReadFuelType() // Select from a set a predefined fuel types safely
		{
			Print("1) Bensin");
			Print("2) Diesel");
			Print("\n");
			var option = ReadKey();

			switch (option)
			{
				case ConsoleKey.D1:
					return FuelTypes.Gasoline;
				case ConsoleKey.D2:
					return FuelTypes.Diesel;
				default: // Invalid input
					throw new ArgumentException("Felaktigt färgval.");
			}
		}

		public double ReadDouble() // Read double input safely
		{
			var input = ReadString();

			if (double.TryParse(input, out double result))
				return result;
			else // Input not a double
				throw new ArgumentException("Det angivna värdet var inte ett decimaltal.");
		}
	}
}
