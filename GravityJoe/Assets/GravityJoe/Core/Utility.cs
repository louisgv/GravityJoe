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
		
		public static Player GetPlayer()
		{
            GameObject test = GameObject.FindGameObjectWithTag("Player");
            if (test)
            {
                return test.GetComponent<Player>();
            }
            else
            {
                return null;
            }
		}

        public static GameManager GetGameManager()
        {
            return GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }
    }
}