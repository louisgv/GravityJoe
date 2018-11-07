using System;
using UnityEngine;

namespace GravityJoe {
	public static class Utility
	{
		
		public static T RandomEnumValue<T>()
		{
			var values = Enum.GetValues(typeof(T));
			int random = UnityEngine.Random.Range(0, values.Length);
			return (T)values.GetValue(random);
		}
		
		public static GameObject GetPlayer()
		{
			return GameObject.FindGameObjectWithTag("Player");
		}
    }
}