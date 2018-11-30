using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GravityJoe
{

    public class ZoneGravity : MonoBehaviour
    {
        Vector3 outMove;
        private void OnTriggerEnter2D(Collider2D other)
        {
            
            Physics2D.gravity = Vector3.zero;
            Utility.GetPlayer().Movement.zeroGravity = true;
        }


        private void OnTriggerExit2D(Collider2D other)
        {
            Physics2D.gravity = new Vector3(0, -9.81f, 0);
            Utility.GetPlayer().Movement.zeroGravity = false;
            //Debug.Log(Utility.GetPlayer().Movement.rb2d.velocity);
            //Utility.GetPlayer().Movement.rb2d.AddForce(Utility.GetPlayer().Movement.rb2d.velocity.normalized * 2, ForceMode2D.Impulse);
        }
    }
}
