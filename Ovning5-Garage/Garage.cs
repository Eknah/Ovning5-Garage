
namespace Ovning5_Garage
{
	internal class Garage<T> : IEnumerable<T> where T : Vehicle
	{

		private T[] entries;

		public Garage(int capacity)
		{
			entries = new T[capacity];
		}

		public IEnumerator<T> GetEnumerator()
		{
			foreach (T e in entries)
				if (e != null)
					yield return e;
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		internal bool AddVehicle(T newVehicle)
		{
			bool isFull = entries.All(e => e != null);

			if (isFull) return false;

			entries[entries.ToList().IndexOf(entries.First(e => e is null))] = newVehicle;

			return true;
		}
	}
}
