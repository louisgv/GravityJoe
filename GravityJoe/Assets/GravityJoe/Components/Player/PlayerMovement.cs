using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // holds rigid body for this object
    Rigidbody2D rb2d;
    public float move;

    public float multiplier;

    // jump booleans to determine if on the ground and when you can double jump
    public bool b_grounded;
    public bool b_doubleJump;

    // grabs transform of child object and checks gets layer type to check against
    public Transform groundCheck;
    public LayerMask currentGround;

    // radius of checking if on the ground
    float groundRadius;

    // variable used to change speed of movement while in the air
    float i_inAir;
    
	// Use this for initialization
	void Start () {

        // sets defaults
        rb2d = GetComponent<Rigidbody2D>();
        b_grounded = false;
        b_doubleJump = false;
        groundRadius = .1f;
        i_inAir = 1f;
        multiplier = 1f;
	}
	
	// Update is called once per frame
	void Update () {

        // checks if player is grounded
        b_grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, currentGround);

        // checks if space is pressed and player is on the ground
        if (Input.GetKeyDown(KeyCode.Space) && b_grounded)
        {
            // jumps once and makes double jump true
            rb2d.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
            b_doubleJump = true;
        }
        // if double jump is true and player is in the air, press space to double jump
        else if (Input.GetKeyDown(KeyCode.Space) && b_doubleJump)  
        {
            rb2d.AddForce(new Vector2(0, 2), ForceMode2D.Impulse);
            b_doubleJump = false;
        }

        // if player is on the ground, move normally
        if (b_grounded)
            i_inAir = 1f;
        // if player is in the air, move slower
        else
            i_inAir = .75f;

        // gets movement based on input for the horizontal axis ('A' & 'D' or 'leftArrow' & 'rightArrow')
        move = Input.GetAxis("Horizontal");

        // change velocity based on input
        rb2d.velocity = new Vector2((move * i_inAir * multiplier) * 10f, rb2d.velocity.y);
	}
    

}


