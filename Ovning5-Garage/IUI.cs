namespace Ovning5_Garage
{
	internal interface IUI
	{
		void Print(string text);
		Colors ReadColor();
		double ReadDouble();
		FuelTypes ReadFuelType();
		int ReadInt();
		ConsoleKey ReadKey();
		string ReadString();
	}
}