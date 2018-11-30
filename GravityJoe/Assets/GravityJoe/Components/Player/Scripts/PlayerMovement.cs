using UnityEngine;

namespace GravityJoe
{

    public class PlayerMovement : MonoBehaviour
    {
        // holds rigid body for this object
        public Rigidbody2D rb2d;
        public float move;
        public bool zeroGravity;

        public bool impulseOnExit;

        public float impulse;

        public bool fallingAlignment;

        Vector2 originVelocity;

        public int index;

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
            impulse = 0f;
        }

        // Update is called once per frame
        void Update()
        {
            

            if (!zeroGravity)
            {
                index = 0;


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



                if (!impulseOnExit)
                {
                    // gets movement based on input for the horizontal axis ('A' & 'D' or 'leftArrow' & 'rightArrow')
                    move = Input.GetAxis("Horizontal");

                    // change velocity based on input
                    //if(Utility.GetPlatform().rota)

                    

                    rb2d.velocity = new Vector2(((move * inAir)  * 10f) + impulse, rb2d.velocity.y);

                    
                    //rb2d.velocity += impulse;
                    //if (Mathf.Abs(impulse) > 0.1f)
                    //    impulse -= 0.1f;
                    //else
                    //{
                    //    impulse = 0f;
                    //    Debug.Log("IN");
                    //}

                    if (impulse < 0f)
                    {
                        impulse += .1f;
                        if (impulse > 0)
                            impulse = 0;
                    }
                    else if(impulse > 0f)
                    {
                        impulse -= .1f;
                        if (impulse < 0)
                            impulse = 0;
                    }

                   

                }
                else
                {
                    //rb2d.AddForce(rb2d.velocity * 2, ForceMode2D.Impulse);
                  

                    impulse = rb2d.velocity.x * rb2d.velocity.SqrMagnitude() / 100;
    
                    impulseOnExit = false;
                }

                originVelocity = rb2d.velocity;




            }
            else
            {
                impulseOnExit = true;

                //if(fallingAlignment == true)
                {
                    if(index == 0)
                    {
                        rb2d.velocity = new Vector2(originVelocity.x, originVelocity.y);
                    }
                    else if (index == 1)
                    {
                        Debug.Log(rb2d.velocity);
                        rb2d.velocity = new Vector2(originVelocity.y, -originVelocity.x);
                        Debug.Log(rb2d.velocity);
                        fallingAlignment = false;
                    }
                    else if (index == 2)
                    {
                        rb2d.velocity = new Vector2(-originVelocity.x, -originVelocity.y);
                    }
                    else if (index == 3)
                    {
                        rb2d.velocity = new Vector2(-originVelocity.y, originVelocity.x);
                    }

                    
                    //else if (index == 2)
                        //rb2d.velocity = new Vector2()
                        
                    //if(index == 2)
                        //rb2d.velocity = new Vector2()
                }
                    
                //Debug.Log(rb2d.velocity);
                //else if (index == 2)
                //    rb2d.velocity = new Vector2(((move * inAir) * 10f) - impulse, rb2d.velocity.y);
                //else if (index == 3)
                //    rb2d.velocity = new Vector2(rb2d.velocity.x, ((move * inAir) * 10f) - impulse);
            }
            

        }

    }
}
