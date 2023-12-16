namespace LogGenerator.Extensions
{
	public static class ListExtensions
	{
		// Checks if value is one of the possible ones
		public static bool IsOneOf<TComparable> (this TComparable value, params TComparable [] values)
			where TComparable : IComparable
		{
			return values.Contains (value);
		}

		// Selects a random element from the list
		public static TComparable Random<TComparable> (this IEnumerable<TComparable> values)
			where TComparable : IComparable
		{
			return
				values.ToArray () [new Random ().Next (0, values.Count () - 1)];
		}
	}
}