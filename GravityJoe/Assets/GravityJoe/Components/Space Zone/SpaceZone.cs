using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GravityJoe
{
    public class SpaceZone : MonoBehaviour
    {

        Platform platform;

        
        void Start()
        {
            platform = Utility.GetPlatform();
        }

        void Update()
        {
            if(Utility.CheckCollisions(Utility.GetPlayer().gameObject, gameObject))
            {
                Physics2D.gravity = Vector2.zero;
                Utility.GetPlayer().Movement.inSpaceZone = true;
                Vector2 rotatedV = (Utility.GetPlayer().GetComponent<Rigidbody2D>().velocity.magnitude) * new Vector2(Mathf.Cos(platform.rotateAngle.eulerAngles.z), Mathf.Sin(platform.rotateAngle.eulerAngles.z));
                Utility.GetPlayer().GetComponent<Rigidbody2D>().velocity = rotatedV;

            }
            else
            {
                Physics2D.gravity = new Vector2(0f, -9.81f);
                Utility.GetPlayer().Movement.inSpaceZone = false;
            }
        }
    }
}
