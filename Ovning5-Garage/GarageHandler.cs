
namespace Ovning5_Garage
{
	internal class GarageHandler
	{
		private ConsoleUI ui;
		private bool applicationRunning;
		private Garage<Vehicle>? garage = null;

		public GarageHandler(ConsoleUI ui)
		{
			this.ui = ui;
		}

		internal void Start()
		{
			ui.Print("Garage 1.0\n" +
					 "==========");

			applicationRunning = true;

			while (applicationRunning)
			{
				drawMainMenu();
				getCommand();
			}
		}

		private void drawMainMenu()
		{
			ui.Print("\nHuvudmeny\n" +
					 "---------");
			ui.Print($"{((char)MenuHelper.CreateNewGarage)}) Skapa nytt garage");
			ui.Print($"{(char)MenuHelper.Quit}) Avsluta program");
			ui.Print($"{(char)MenuHelper.ListAllVehicles}) Lista alla fordon");
			ui.Print($"{(char)MenuHelper.AddVehicle}) Parkera fordon");
			ui.Print($"{(char)MenuHelper.DeleteVehicle}) Avsluta parkering för fordon");
			ui.Print($"{(char)MenuHelper.GetVehicleByRegNr}) Hämta fordon för reg.nummer");
			ui.Print($"{(char)MenuHelper.GetVehiclesByProps}) Sök fordon efter egenskaper");
		}

		private void getCommand()
		{
			var action = ui.ReadKey();

			switch (action)
			{
				case MenuHelper.CreateNewGarage:
					createNewGarage();
					break;
				case MenuHelper.Quit:
					quit();
					break;
				case MenuHelper.ListAllVehicles:
					listAllVehicles();
					break;
				case MenuHelper.AddVehicle:
					addVehicle();
					break;
				case MenuHelper.DeleteVehicle:
					deleteVehicle();
					break;
				case MenuHelper.GetVehicleByRegNr:
					getVehicleByRegNr();
					break;
				case MenuHelper.GetVehiclesByProps:
					getVehicleByProps();
					break;
				default:
					ui.Print("Ogiltigt menyval.");
					break;
			}
		}

		private void listAllVehicles()
		{
			ui.Print("\nLista fordon\n" +
					   "------------\n");

			try
			{ 
				if (garage is null)
					throw new InvalidOperationException("Garage-objekt är ej skapat");

				foreach (Vehicle v in garage)
					ui.Print(v.ToString());
			}
			catch (InvalidOperationException ioex)
			{
				ui.Print(ioex.Message);
			}
		}

		private void addVehicle()
		{
			ui.Print("\nParkera fordon\n" +
					   "--------------");

			try
			{

				if (garage is null)
					throw new InvalidOperationException("Garage-objektet är ej skapat.");

				ui.Print("\nAnge fordonstyp:");
				ui.Print($"{((char)MenuHelper.VehicleAirplane)}) Flygplan");
				ui.Print($"{(char)MenuHelper.VehicleBoat}) Båt");
				ui.Print($"{(char)MenuHelper.VehicleBus}) Buss");
				ui.Print($"{(char)MenuHelper.VehicleCar}) Bil");
				ui.Print($"{(char)MenuHelper.VehicleMotorcycle}) Motorcykel");

				var vehicleType = ui.ReadKey();

				Vehicle? vehicle = null;

				switch (vehicleType)
				{
					case MenuHelper.VehicleAirplane:
					{ 
						ui.Print("Ange färg:");
						var color = ui.ReadColor();
						ui.Print("Ange antal hjul:");
						var numberOfWheels = ui.ReadInt();
						ui.Print("Ange reg.nr:");
						var regNumber = ui.ReadString();
						ui.Print("Ange antal motorer:");
						var numberOfEngines = ui.ReadInt();
						vehicle = new Airplane(color, numberOfWheels, regNumber, numberOfEngines);
						break;
					}
					case MenuHelper.VehicleBoat:
					{ 
						ui.Print("Ange färg:");
						var color = ui.ReadColor();
						ui.Print("Ange antal hjul:");
						var numberOfWheels = ui.ReadInt();
						ui.Print("Ange reg.nr:");
						var regNumber = ui.ReadString();
						ui.Print("Ange längd:");
						var length = ui.ReadInt();
						vehicle = new Boat(color, numberOfWheels, regNumber, length);
						break;
					}
					case MenuHelper.VehicleBus:
						{
							ui.Print("Ange färg:");
							var color = ui.ReadColor();
							ui.Print("Ange antal hjul:");
							var numberOfWheels = ui.ReadInt();
							ui.Print("Ange reg.nr:");
							var regNumber = ui.ReadString();
							ui.Print("Ange antal sitsar:");
							var nrOfSeats = ui.ReadInt();
							vehicle = new Bus(color, numberOfWheels, regNumber, nrOfSeats);
							break;
						}
					case MenuHelper.VehicleCar:
						{
							ui.Print("Ange färg:");
							var color = ui.ReadColor();
							ui.Print("Ange antal hjul:");
							var numberOfWheels = ui.ReadInt();
							ui.Print("Ange reg.nr:");
							var regNumber = ui.ReadString();
							ui.Print("Ange bränsletyp:");
							var fuelType = ui.ReadFuelType();
							vehicle = new Car(color, numberOfWheels, regNumber, fuelType);
							break;
						}
					case MenuHelper.VehicleMotorcycle:
						{
							ui.Print("Ange färg:");
							var color = ui.ReadColor();
							ui.Print("Ange antal hjul:");
							var numberOfWheels = ui.ReadInt();
							ui.Print("Ange reg.nr:");
							var regNumber = ui.ReadString();
							ui.Print("Ange cylindervolym:");
							var cylinderVolume = ui.ReadDouble();
							vehicle = new Motorcycle(color, numberOfWheels, regNumber, cylinderVolume);
							break;
						}
					default:
						ui.Print("Ogiltigt menyval.");
						return;
				}

				if (!garage.AddVehicle(vehicle))
					ui.Print("Garaget är full, kan inte parkera fordon");
			}
			catch (ArgumentException aex)
			{
				ui.Print(aex.Message);
			}
			catch (InvalidOperationException ioex)
			{
				ui.Print(ioex.Message);
			}
		}

		private void deleteVehicle()
		{

		}

		private void getVehicleByRegNr()
		{

		}

		private void getVehicleByProps()
		{

		}

		private void createNewGarage()
		{
			ui.Print("Skapa nytt garage\n" +
					 "-----------------\n" +
					 "Ange garagets kapacitet: ");

			try
			{
				var capacity = ui.ReadInt();
				garage = new Garage<Vehicle>(capacity);
				ui.Print($"Garage skapat med kapaciteten {capacity}.");
				ui.Print("Ange antal fordon att populera garaget med från start (0 för inga):");
				var populateAmount = ui.ReadInt();

				var populationData = new List<Vehicle>()
				{

				};

				populationData.Take(populateAmount).ToList().ForEach(v => garage.AddVehicle(v));

				if (populateAmount > 0)
					ui.Print("Garaget har populerats med startdata.");
			}
			catch (ArgumentException ex)
			{
				ui.Print(ex.Message);
			}
		}

		private void quit()
		{
			Environment.Exit(0);
		}
	}
}
