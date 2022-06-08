
namespace Ovning5_Garage
{
	internal class GarageHandler : IHandler
	// Functions as a layer between the Garage and the UI
	{
		private IUI ui; // Provides abstract functionality for in and outdata handling
		private bool appRunning;
		private Garage<IVehicle>? garage = null; // Is null until user manually creates a new garage

		public GarageHandler(IUI ui)
		{
			this.ui = ui;
		}

		public void Start()
		{
			ui.Print("Garage 1.0\n" +
					 "==========");

			appRunning = true;

			while (appRunning)
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
			ui.Print($"{(char)MenuHelper.ListAllVehicles}) Lista alla fordon");
			ui.Print($"{(char)MenuHelper.ListVehicleTypes}) Lista fordonstyper");
			ui.Print($"{(char)MenuHelper.AddVehicle}) Parkera fordon");
			ui.Print($"{(char)MenuHelper.DeleteVehicle}) Avsluta parkering för fordon");
			ui.Print($"{(char)MenuHelper.GetVehicleByRegNr}) Hämta fordon för reg.nummer");
			ui.Print($"{(char)MenuHelper.GetVehiclesByProps}) Sök fordon efter egenskaper");
			ui.Print($"{(char)MenuHelper.Quit}) Avsluta program");
		}

		private void getCommand() // Reads input from ui and executes corresponding menu action
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
				case MenuHelper.ListVehicleTypes:
					listVehicleTypes();
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

		private void listVehicleTypes()
		{
			ui.Print("\nLista fordonstyper\n" +
					   "------------------\n");

			try
			{
				if (garage is null)
					throw new InvalidOperationException("Garage-objekt är ej skapat");

				ui.Print($"Flygplan:   \t{garage.Count(v => v is Airplane)} st");
				ui.Print($"Båtar:   \t{garage.Count(v => v is Boat)} st");
				ui.Print($"Bussar:   \t{garage.Count(v => v is Bus)} st");
				ui.Print($"Bilar:   \t{garage.Count(v => v is Car)} st");
				ui.Print($"Motorcyklar:   \t{garage.Count(v => v is Motorcycle)} st");
			}
			catch (InvalidOperationException ioex)
			{
				ui.Print(ioex.Message);
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

				ui.Print($"Antal fordon: {garage.Count()} st\n");

				foreach (IVehicle v in garage)
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
					throw new InvalidOperationException("Kan ej parkera fordon, Garage-objektet är ej skapat.");

				ui.Print("\nAnge fordonstyp:");
				ui.Print($"{((char)MenuHelper.VehicleAirplane)}) Flygplan");
				ui.Print($"{(char)MenuHelper.VehicleBoat}) Båt");
				ui.Print($"{(char)MenuHelper.VehicleBus}) Buss");
				ui.Print($"{(char)MenuHelper.VehicleCar}) Bil");
				ui.Print($"{(char)MenuHelper.VehicleMotorcycle}) Motorcykel");

				var vehicleType = ui.ReadKey();

				IVehicle? vehicle = null;

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
							var length = ui.ReadDouble();
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
					ui.Print("Garaget är fullt, kan inte parkera fordon");
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
			try
			{
				if (garage is null)
					throw new InvalidOperationException("Garage-objektet är ej skapat.");

				ui.Print("\nAvsluta parkering för fordon med reg.nummer\n" +
						   "-------------------------------------------");
				var vehicle = searchVehicleWithRegNr();

				if (vehicle != null)
				{
					garage.RemoveVehicle(vehicle);
					ui.Print($"Parkering avslutad för fordon med reg.nummer: {vehicle.RegNumber}");
				}
				else
				{
					ui.Print("\nInget fordon med det angivna reg.numret existerar.");
				}
			}
			catch (InvalidOperationException ioex)
			{
				ui.Print(ioex.Message);
			}
		}

		private IVehicle? searchVehicleWithRegNr()
		{
			ui.Print("Ange reg.nummer:");
			var regNumber = ui.ReadString();

			var vehicle = garage?.FirstOrDefault(v => v.RegNumber.ToUpper().Equals(regNumber.ToUpper()));

			return vehicle;
		}

		private void getVehicleByRegNr()
		{
			try
			{
				if (garage is null)
					throw new InvalidOperationException("Garage-objektet är ej skapat.");

				ui.Print("\nSök fordon med reg.nummer\n" +
						   "-------------------------");
				var vehicle = searchVehicleWithRegNr();

				if (vehicle != null)
				{
					ui.Print("\nFordon funnet med angivet reg.nummer:");
					ui.Print(vehicle.ToString());
				}
				else
				{
					ui.Print("\nInget fordon med det angivna reg.numret existerar.");
				}
			}
			catch (InvalidOperationException ioex)
			{
				ui.Print(ioex.Message);
			}
		}

		private void getVehicleByProps()
		{
			ui.Print("Sök fordon efter egenskaper\n" +
					 "---------------------------\n");

			try
			{
				if (garage is null)
					throw new InvalidOperationException("Garage-objektet är ej skapat.");

				Colors? color = null;
				int? numberOfWheels = null;
				string? vehicleType = null;

				ConsoleKey inputKey;
				do
				{
					ui.Print("Tillagda egenskaper för sökning:");
					ui.Print($"Färg:     \t{(color != null ? color.ToString() : new string("Ospecificerat"))}");
					ui.Print($"Antal hjul: \t{(numberOfWheels != null ? numberOfWheels : new string("Ospecificerat"))}");
					ui.Print($"Fordonstyp: \t{(vehicleType != null ? vehicleType : new string("Ospecificerat"))}");
					ui.Print("");

					ui.Print("Specificera egenskap i sökning:");
					ui.Print("1) Färg");
					ui.Print("2) Antal hjul");
					ui.Print("3) Fordonstyp");
					ui.Print("4) Genomför sökning");
					ui.Print("5) Backa");

					inputKey = ui.ReadKey();

					switch (inputKey)
					{
						case ConsoleKey.D1:
							{
								ui.Print("Ange färg:");
								color = ui.ReadColor();
								break;
							}
						case ConsoleKey.D2:
							{
								ui.Print("Ange antal hjul:");
								numberOfWheels = ui.ReadInt();
								break;
							}
						case ConsoleKey.D3:
							{
								ui.Print("Ange fordonstyp:");
								vehicleType = ui.ReadString();
								break;
							}
						case ConsoleKey.D4:
							{
								//Func<Vehicle, bool> searchCondition = new(v => true);
								Func<IVehicle, bool> searchCondition = new(v => true);

								if (color != null)
									searchCondition = searchCondition.AndAlso<IVehicle>(v => v.Color == color);

								if (numberOfWheels != null)
									searchCondition = searchCondition.AndAlso<IVehicle>(v => v.NumberOfWheels == numberOfWheels);

								if (vehicleType != null)
									searchCondition = searchCondition.AndAlso<IVehicle>(v => v.Name == vehicleType);

								var results = garage.Where(v => searchCondition.Invoke(v));

								ui.Print("Sökresultat:");
								foreach (IVehicle v in results)
									ui.Print(v.ToString());

								break;
							}
						case ConsoleKey.D5:
							{
								return;
							}
						default:
							{
								ui.Print("Ogiltigt menyval.");
								return;
							}
					}

				} while (inputKey != ConsoleKey.D4);

			}
			catch (InvalidOperationException ioex)
			{
				ui.Print(ioex.Message);
			}





		}

		private void createNewGarage()
		{
			ui.Print("Skapa nytt garage\n" +
					 "-----------------\n" +
					 "Ange garagets kapacitet: ");

			try
			{
				var capacity = ui.ReadInt();
				garage = new Garage<IVehicle>(capacity);
				ui.Print($"Garage skapat med kapaciteten {capacity}.");
				ui.Print("Ange antal fordon att populera garaget med från start (0 för inga):");
				var populateAmount = ui.ReadInt();

				var populationData = new List<IVehicle>()
				{
					new Airplane(Colors.Green, 3, "HJK654", 2),
					new Boat(Colors.Red, 0, "IFJ533", 3),
					new Bus(Colors.Yellow, 4, "ISL934", 56),
					new Car(Colors.Blue, 4, "YSU495", FuelTypes.Diesel),
					new Motorcycle(Colors.Black, 2, "JDU395", 2.4),
					new Airplane(Colors.White, 4, "OOD383", 4),
					new Boat(Colors.White, 0, "JDI939", 2.5),
					new Bus(Colors.Blue, 4, "IIO384", 44),
					new Car(Colors.Red, 4, "MNX934", FuelTypes.Gasoline),
					new Motorcycle(Colors.Green, 2, "AAU837", 1.9),
					new Car(Colors.Green, 4, "IUE845", FuelTypes.Gasoline),
					new Motorcycle(Colors.Red, 2, "OOI847", 3.0),
					new Airplane(Colors.Blue, 5, "UDO858", 6),
					new Boat(Colors.Black, 0, "ICO395", 2.2)
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
			ui.Print("Avslutar program.");
			appRunning = false;
		}
	}
}
