using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GravityJoe
{

    public class Missile : MonoBehaviour
    {

        public float missileSpd;
        public bool isDead = false;
        Rigidbody2D rb;
        public float explosionRadius;
        public float explosionMagnitude;

        // Use this for initialization
        void Start()
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(gameObject.transform.right * missileSpd * 2, ForceMode2D.Impulse);
        }

        // Update is called once per frame
        void Update()
        {
            if (!isDead)
            {
                rb.AddForce(gameObject.transform.right * missileSpd);
                gameObject.transform.right = ((Vector2)(rb.velocity)).normalized;
                GameObject[] walls = Utility.GetWalls();
                for (int i = 0; i < walls.Length; i++)
                {
                    if (GravityJoe.Utility.CheckCollisions(gameObject, walls[i]))
                    {
                        rb.isKinematic = true;
                        rb.velocity = Vector3.zero;
                        isDead = true;
                        Player playerRef = Utility.GetPlayer();
                        float sqrDist = (playerRef.transform.position - gameObject.transform.position).sqrMagnitude;

                        float explosionRadiusSqr = explosionRadius * explosionRadius;

                        if (sqrDist <= explosionRadiusSqr)
                        {
                            float ratio = 1.0f - (sqrDist / (explosionRadiusSqr));


                            Vector2 playerToMissileDir = (Vector2)(playerRef.transform.position - gameObject.transform.position).normalized;
                            playerRef.GetComponent<Rigidbody2D>().AddForce(playerToMissileDir * explosionMagnitude * ratio, ForceMode2D.Impulse);
                        }
                    }
                }
            }
        }
    }
}
