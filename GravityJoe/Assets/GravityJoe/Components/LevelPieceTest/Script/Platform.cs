using System.Collections;
using UnityEngine;

namespace GravityJoe
{

    public class Platform : MonoBehaviour
    {

        public float rotateAmount = 90.0f;

        float rotateTime = .4f;

        bool bRotating;

        public Quaternion rotateAngle;

        Player player;

        void Start()
        {
            rotateAngle = transform.rotation;
            player = Utility.GetPlayer();
        }

        public void ResetRotation()
        {
            player.transform.SetParent(null);
            player.transform.rotation = Quaternion.identity;
            player.Movement.rb2d.isKinematic = false;
            StopAllCoroutines();

            transform.rotation = rotateAngle = Quaternion.identity;

            bRotating = false;
        }

        void Update()
        {
            if (!bRotating)
            {
                if (Input.GetButtonDown("RotateLeft"))
                {
                    StopAllCoroutines();

                    rotateAngle = rotateAngle * Quaternion.Euler(-Vector3.forward * 90.0f);
                    StartCoroutine(Rotate());

                }

                if (Input.GetButtonDown("RotateRight"))
                {
                    StopAllCoroutines();

                    rotateAngle = rotateAngle * Quaternion.Euler(Vector3.forward * 90.0f);

                    StartCoroutine(Rotate());
                }
            }
        }

        IEnumerator Rotate()
        {
            bRotating = true;

            var fromAngle = transform.rotation;
            float timeStep = Time.deltaTime / rotateTime;

            if (player != null)
            {
                player.transform.SetParent(transform);
                player.Movement.rb2d.isKinematic = true; //<--commenting this out fixes going through walls
                //player.Movement.rb2d.velocity = Vector2.zero;
            }

            for (float i = 0.0f; i < 1.0f; i += timeStep)
            {
                transform.rotation = Quaternion.Lerp(fromAngle, rotateAngle, i);
                yield return null;
            }
            transform.rotation = rotateAngle;

            if (player != null)
            {
                player.transform.SetParent(null);
                player.transform.rotation = Quaternion.identity;
                player.Movement.rb2d.isKinematic = false; //<--commenting this out fixes going through walls
            }


            bRotating = false;
        }
    }

}
