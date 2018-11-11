using System.Collections;
using UnityEngine;

namespace GravityJoe
{

    public class Platform : MonoBehaviour
    {

        public float rotateAmount = 90.0f;

        public float rotateTime = 1.0f;

        bool bRotating;

        Quaternion rotateAngle;

        void Start()
        {
            rotateAngle = transform.rotation;
        }

        void Update()
        {
            if (!bRotating)
            {
                if (Input.GetButtonDown("RotateRight"))
                {
                    StopAllCoroutines();

                    rotateAngle = rotateAngle * Quaternion.Euler(-Vector3.forward * 90.0f);
                    StartCoroutine(Rotate());

                }

                if (Input.GetButtonDown("RotateLeft"))
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

            for (float i = 0.0f; i < rotateTime; i += timeStep)
            {
                transform.rotation = Quaternion.Lerp(fromAngle, rotateAngle, i);
                yield return null;
            }
            transform.rotation = rotateAngle;

            bRotating = false;
        }
    }

}
