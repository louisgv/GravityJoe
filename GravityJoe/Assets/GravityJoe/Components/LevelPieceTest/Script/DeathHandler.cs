using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour {

    public GameObject player;
    public bool collision;
    public LayerMask playerMask;
   
    // Update is called once per frame
    void Update () {
        collision = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.localScale.x - .1f, transform.localScale.y - .1f), 0f, playerMask);

        if (collision)
            Destroy(player);
    }
}
