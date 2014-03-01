using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UE=UnityEngine;

namespace FastPolygonalRunner.Framework.Extensions
{
	public static class IEnumerableExtensions
	{
		public static T GetRandomElem<T>(this T[] enumerable)
		{
			var idx = UE.Random.Range(0, enumerable.Count());

			return enumerable[idx];
		}
	}
}
