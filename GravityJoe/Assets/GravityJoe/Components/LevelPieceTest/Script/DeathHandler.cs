using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour {

    // player info to find collision for this platform object
    public GameObject player;
    bool collision;
    public LayerMask playerMask;
   
    // Update is called once per frame
    void Update () {
        // checks if overlap box is overlapping with player mask
        collision = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.localScale.x - .1f, transform.localScale.y - .1f), 0f, playerMask);

        // if colliding, destroy objects
        if (collision)
            Destroy(player);
    }
}
