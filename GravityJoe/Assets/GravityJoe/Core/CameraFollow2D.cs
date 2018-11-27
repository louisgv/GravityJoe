using UnityEngine;

namespace GravityJoe
{
    public class CameraFollow2D : MonoBehaviour
    {



        public float minFoV = 5f;
        public float maxFoV = 25f;
        public float sensitivity = 10f;

        float originalZ;
        Player target;
        Vector3 targetPos;
        Camera selfCamera;

        // Use this for initialization
        void Start()
        {
            target = Utility.GetPlayer();
            targetPos = transform.position;

            originalZ = transform.position.z;

            selfCamera = GetComponent<Camera>();
        }

        // Update is called once per frame
        void Update()
        {
            targetPos = target.transform.position;
            targetPos.z = originalZ;

            transform.position = targetPos;

            float fov = selfCamera.orthographicSize;
            fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
            fov = Mathf.Clamp(fov, minFoV, maxFoV);
            selfCamera.orthographicSize = fov;

        }

    }
}
