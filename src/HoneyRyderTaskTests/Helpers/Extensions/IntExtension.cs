using System;
using System.Linq;

namespace HoneyRyderTaskTests.Helpers.Extensions
{
	public static class IntExtension
	{
		public static void Times(this int count, Action<int> action)
        {
			Enumerable.Range(1, count).ToList().ForEach(action);
        }
	}
}

