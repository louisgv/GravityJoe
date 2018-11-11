using UnityEngine;

namespace GravityJoe
{

    public class PlayerMovement : MonoBehaviour
    {
        // holds rigid body for this object
        Rigidbody2D rb2d;
        public float move;

        // jump booleans to determine if on the ground and when you can double jump
        public bool grounded;
        public bool doubleJump;

        // grabs transform of child object and checks gets layer type to check against
        public Transform groundCheck;
        public LayerMask currentGround;


        // radius of checking if on the ground
        float groundRadius;

        // variable used to change speed of movement while in the air
        float inAir;

        // Use this for initialization
        void Start()
        {

            // sets defaults
            rb2d = GetComponent<Rigidbody2D>();
            grounded = false;
            doubleJump = false;
            groundRadius = .1f;
            inAir = 1f;
        }

        // Update is called once per frame
        void Update()
        {

            // checks if player is grounded
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, currentGround);

            // checks if space is pressed and player is on the ground
            if (Input.GetButtonDown("Jump") && grounded)
            {
                // jumps once and makes double jump true
                rb2d.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
                doubleJump = true;
            }
            // if double jump is true and player is in the air, press space to double jump
            else if (Input.GetButtonDown("Jump") && doubleJump)
            {
                rb2d.AddForce(new Vector2(0, 2), ForceMode2D.Impulse);
                doubleJump = false;
            }

            // if player is on the ground, move normally
            if (grounded)
                inAir = 1f;
            // if player is in the air, move slower
            else
                inAir = .75f;

            // gets movement based on input for the horizontal axis ('A' & 'D' or 'leftArrow' & 'rightArrow')
            move = Input.GetAxis("Horizontal");

            // change velocity based on input
            rb2d.velocity = new Vector2((move * inAir) * 10f, rb2d.velocity.y);
        }
    }
}
