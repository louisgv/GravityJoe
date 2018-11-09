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
        public static GameManager GetGameManager()
        {
            return GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }
    }
}