
namespace Ovning5_Garage
{
	public class Garage<T> : IEnumerable<T> where T : IVehicle
	{

		private T?[] entries;

		public int Capacity => entries.Length;

		public Garage(int capacity)
		{
			if (capacity <= 0)
			{
				throw new ArgumentException("Fordonskapaciteten måste vara ett värde över 0.");
			}

			entries = new T[capacity];
		}

		public IEnumerator<T> GetEnumerator() // Allows iterating over a garage object
		{
			foreach (T? e in entries)
				if (e != null)
					yield return e;
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator(); // Old un-generic IEnumerable function

		public bool AddVehicle(T newVehicle)
		{
			bool isFull = entries.All(e => e != null); // Check if all elements are assigned to

			if (isFull) return false; // Cannot add vehicle if array is full

			// Guaranteed to find a null element as the function would already have returned if the above isFull-check would have returned true.
			var firstNullElementIndex = entries.ToList().IndexOf(entries.First(e => e is null));

			entries[firstNullElementIndex] = newVehicle; // Place new vehicle in first empty array element

			return true; // Add vehicle success
		}

		public void RemoveVehicle(T vehicle)
		{
			var vehicleToRemoveIndex = entries.ToList().IndexOf(vehicle);

			if (vehicleToRemoveIndex != -1)
			{ 
				entries[vehicleToRemoveIndex] = default(T);
			}
		}
	}
}
