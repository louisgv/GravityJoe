using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GravityJoe
{

    public class Arrow: MonoBehaviour
    {

        bool isStuck = false;
        Rigidbody2D rb;

        // Use this for initialization
        void Start()
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!isStuck)
            {
                gameObject.transform.right = ((Vector2)(rb.velocity)).normalized;
                GameObject[] walls = GravityJoe.Utility.GetWalls();
                for (int i = 0; i < walls.Length; i++)
                {
                    if (GravityJoe.Utility.CheckCollisions(gameObject, walls[i]))
                    {
                        rb.isKinematic = true;
                        rb.velocity = Vector3.zero;
                        gameObject.AddComponent<BoxCollider2D>();
                        isStuck = true;
                    }
                }
            }
        }
    }
}
