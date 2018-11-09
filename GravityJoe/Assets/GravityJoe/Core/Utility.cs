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

        public static GameObject[] GetWalls()
        {
            return GameObject.FindGameObjectsWithTag("Wall");
        }

        public static bool CheckCollisions(GameObject a, GameObject b)
        {
            SpriteRenderer aSpriteRenderer = a.GetComponent<SpriteRenderer>();
            Vector2 aMin = a.transform.position - aSpriteRenderer.bounds.extents;
            Vector2 aMax = a.transform.position + aSpriteRenderer.bounds.extents;
            SpriteRenderer bSpriteRenderer = b.GetComponent<SpriteRenderer>();
            Vector2 bMin = b.transform.position - bSpriteRenderer.bounds.extents;
            Vector2 bMax = b.transform.position + bSpriteRenderer.bounds.extents;
            return aMin.x < bMax.x && aMin.y < bMax.y && aMax.x > bMin.x && aMax.y > bMin.y;
        }
    }
}