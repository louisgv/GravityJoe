using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GravityJoe
{

    public class Missile : MonoBehaviour
    {

        public float speed;
        public bool isDead = false;

        new Rigidbody2D rigidbody;
        new Collider2D collider;

        public float explosionRadius;
        public float explosionMagnitude;

        // Use this for initialization
        void Start()
        {
            rigidbody = gameObject.GetComponent<Rigidbody2D>();
            collider = GetComponent<BoxCollider2D>();

            rigidbody.AddForce(transform.right * speed * 2, ForceMode2D.Impulse);
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Wall"))
            {
                rigidbody.isKinematic = true;
                rigidbody.velocity = Vector3.zero;
                isDead = true;

                Player playerRef = Utility.GetPlayer();
                float sqrDist = (playerRef.transform.position - gameObject.transform.position).sqrMagnitude;

                float explosionRadiusSqr = explosionRadius * explosionRadius;

                if (sqrDist <= explosionRadiusSqr)
                {
                    float ratio = 1.0f - (sqrDist / (explosionRadiusSqr));

                    Vector2 playerToMissileDir = (playerRef.transform.position - transform.position).normalized;
                    playerRef.GetComponent<Rigidbody2D>().AddForce(playerToMissileDir * explosionMagnitude * ratio, ForceMode2D.Impulse);
                }

                // TODO: Spawn some FX and blow this up
                // Destroy(gameObject);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (!isDead)
            {
                rigidbody.AddForce(transform.right * speed);
                transform.right = rigidbody.velocity.normalized;
            }
        }
    }
}
