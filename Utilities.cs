namespace LogGenerator
{
	public static class Utilities
	{
		public static int [] GetRandomIndices (int maxIndex, int count)
		{
			if (count > maxIndex)
			{
				return new int [0];
			}

			var uniqueIndices = new HashSet<int> ();
			var random = new Random ();

			while (uniqueIndices.Count < count)
			{
				var randomIndex = random.Next (0, maxIndex);
				uniqueIndices.Add (randomIndex);
			}

			return uniqueIndices.ToArray ();
		}
	}
}