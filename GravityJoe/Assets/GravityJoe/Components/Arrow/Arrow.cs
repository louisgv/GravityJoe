using UnityEngine;

namespace GravityJoe
{

    public class Arrow : MonoBehaviour
    {

        bool isStuck = false;
        new Rigidbody2D rigidbody;
        new Collider2D collider;

        // Use this for initialization
        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            collider = GetComponent<BoxCollider2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!isStuck)
            {
                transform.right = rigidbody.velocity.normalized;
            }
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Wall"))
            {
                rigidbody.isKinematic = true;
                rigidbody.velocity = Vector3.zero;
                collider.isTrigger = false;
                isStuck = true;
            }
        }

    }
}
