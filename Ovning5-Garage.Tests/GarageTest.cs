
namespace Ovning5_Garage.Tests
{
	public class GarageTest
	{
		[Fact]
		public void GarageCtor_ValidCapacity_ExpectedBehaviour()
		{
			// Arrange
			var expected = 10;
			var garage = new Garage<IVehicle>(expected);

			// Act
			var actual = garage.Capacity;

			// Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void GarageCtor_InvalidCapacity_ExceptionThrown()
		{
			// Arrange
			var invalidCapacity = -1;
			Action testCode = () => new Garage<IVehicle>(invalidCapacity);

			// Act
			Assert.Throws<ArgumentException>(testCode);
		}

		[Fact]
		public void AddVehicle_ValidVehicleData_ExpectedBehaviour()
		{
			// Arrange
			var vehicle = new Airplane(Enums.Colors.Yellow, 4, "AAA000", 4);
			var expected = vehicle;
			var garage = new Garage<IVehicle>(1);
			garage.AddVehicle(vehicle);

			// Act
			var actual = garage.FirstOrDefault();

			// Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void RemoveVehicle_GarageCount_ExpectedBehaviour()
		{
			// Arrange
			var vehicle = new Airplane(Enums.Colors.Yellow, 4, "BBB111", 4);
			var expected = 0;
			var garage = new Garage<IVehicle>(1);
			garage.AddVehicle(vehicle);

			// Act
			garage.RemoveVehicle(vehicle);
			var actual = garage.Count();

			// Assert
			Assert.Equal(expected, actual);
		}
	}
}