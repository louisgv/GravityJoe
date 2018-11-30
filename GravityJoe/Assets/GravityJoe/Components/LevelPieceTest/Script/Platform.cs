using System.Collections;
using UnityEngine;

namespace GravityJoe
{

    public class Platform : MonoBehaviour
    {

        public float rotateAmount = 90.0f;

        public float rotateTime = 1.0f;

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

            StopAllCoroutines();

            transform.rotation = rotateAngle = Quaternion.identity;

            bRotating = false;
        }

        void Update()
        {
            if (!bRotating)
            {
                if (Input.GetButtonDown("RotateRight"))
                {
                    StopAllCoroutines();

                    rotateAngle = rotateAngle * Quaternion.Euler(-Vector3.forward * 90.0f);
                    ///
                    Utility.GetPlayer().Movement.index++;
                    if (Utility.GetPlayer().Movement.index >= 4)
                        Utility.GetPlayer().Movement.index = 0;
                    Utility.GetPlayer().Movement.fallingAlignment = true;
                    ///
                    StartCoroutine(Rotate());
                    
                }

                if (Input.GetButtonDown("RotateLeft"))
                {
                    StopAllCoroutines();

                    rotateAngle = rotateAngle * Quaternion.Euler(Vector3.forward * 90.0f);

                    ///
                    Utility.GetPlayer().Movement.index--;
                    if (Utility.GetPlayer().Movement.index <= -1)
                        Utility.GetPlayer().Movement.index = 3;
                    Utility.GetPlayer().Movement.fallingAlignment = true;
                    ///
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
            }

            for (float i = 0.0f; i < rotateTime; i += timeStep)
            {
                transform.rotation = Quaternion.Lerp(fromAngle, rotateAngle, i);
                yield return null;
            }
            if (player != null)
            {
                player.transform.SetParent(null);
                player.transform.rotation = Quaternion.identity;
            }

            transform.rotation = rotateAngle;

            bRotating = false;
        }
    }

}
