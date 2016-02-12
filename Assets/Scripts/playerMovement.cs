using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerMovement : MonoBehaviour {

    public float speed;
    public float maxSpeed = 50f;
    public float gravity = 20.0F;
    public float jumpSpeed;
    public HealthBar playerHealthBar;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController charController;
    //for player health management
    private float originalTime = 0;
    private float currentTime = 0;

    bool dKey = false;
    bool sKey = true;
    bool aKey = false;

    bool faceRight = true;
    bool facingRight = true;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        
    }
    
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
     
	void Start () {
	}

    void Update() {

        

        //THIS WORKS AND THE CHARACTER SLOWS DOWN
        /*
         CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded) {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
            
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
         */
        
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            //Debug.Log("Made it inside isGrounded statement");
            if (dKey == false && Input.GetKey(KeyCode.D))
            {
                Debug.Log("Made it inside D loop");
                dKey = true;
                sKey = false;
                aKey = false;
                faceRight = true;
                moveDirection = new Vector3(5f, 0, 0);
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection.x *= speed;
                //Flip();
                Debug.Log("moveDirection inside D statement: " + moveDirection);
                //transform.position += new Vector3(5f, 0, 0) * speed * Time.deltaTime;
            }
            else if (sKey == false && Input.GetKey(KeyCode.S))
            {
                if (faceRight)
                {
                    sKey = true;
                    dKey = false;
                    moveDirection = new Vector3(5f, 0, 0);
                    moveDirection = transform.TransformDirection(moveDirection);
                    moveDirection.x *= speed;
                    Debug.Log("moveDirection inside D statement: " + moveDirection);
                }
                else if (faceRight == false)
                {
                    sKey = true;
                    dKey = false;
                    moveDirection = new Vector3(-5f, 0, 0);
                    moveDirection = transform.TransformDirection(moveDirection);
                    moveDirection.x *= speed;
                    Debug.Log("moveDirection inside D statement: " + moveDirection);
                }
            }
            else if (aKey == false && Input.GetKey(KeyCode.A))
            {
                aKey = true;
                sKey = false;
                dKey = false;
                faceRight = false;
                moveDirection = new Vector3(-5f, 0, 0);
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection.x *= speed;
                //Flip();
                Debug.Log("moveDirection inside D statement: " + moveDirection);
                
            }
                //this checks which direction the player if facing and then slows them down in the opposite direction
            else
            {
                if (faceRight)
                {
                    if (moveDirection.x > 0)
                    {
                        moveDirection -= new Vector3(1f, 0, 0);
                    }
                }
                else if (faceRight == false)
                {
                    if (moveDirection.x < 0)
                    {
                        moveDirection -= new Vector3(-1f, 0, 0);

                    }
                }

            }

            //if (Input.GetButton("Jump"))
            //    moveDirection.y = jumpSpeed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(Physics.gravity);
        controller.Move(moveDirection * Time.deltaTime);

        //detects if the player is being hit by particles and regens health if not
        if (charController.velocity.x == 0f)
        {

            //Debug.Log("inside else statement to regen health, currentTime: " + currentTime + ", originalTime: " + originalTime);
            //for player health management
            currentTime += Time.deltaTime;
            if (currentTime - originalTime > 1)
            {
                originalTime = currentTime;
                playerHealthBar.damage(-1f);
            }
        }
    }//end of Update

    public void OnParticleCollision()
    {
        //Debug.Log("inside the onparticlecollision method");

        if (charController.detectCollisions)
        {
            playerHealthBar.damage(2f);
            //hb.damage(1f);
            //Debug.Log("Hit!");
        }

    }
    
    void Flip()
    {
        if (faceRight == false && facingRight == true)
        {
            Vector3 theScale = charController.transform.localScale;
            theScale.x *= -1;
            charController.transform.localScale = theScale;
            facingRight = false;
        }
        else if (faceRight == true && facingRight == false)
        {
            Vector3 theScale = charController.transform.localScale;
            theScale.x *= -1;
            charController.transform.localScale = theScale;
            facingRight = true;
        }

    }

    /*
   void movePlayer()
   {

       //hitting the D key, facing right
       if (dKey == false && Input.GetKey(KeyCode.D))
       {
           dKey = true;
           sKey = false;
           aKey = false;
           faceRight = true;
           move += speed;
           if (move > maxSpeed) move = maxSpeed;
           //backgroundTrees();
           //backgroundTrees.setScrollSpeed(0.3f);
           rigi.AddForce(new Vector2(move * Time.deltaTime, 0));
           rigi.velocity = new Vector2(move * Time.deltaTime, 0);
           //transform.TransformDirection(new Vector3(speed * Time.deltaTime, 0, 0));
       }

       //hitting the S key, depending on which way you are facing, depends on which way you move
       if (sKey == false && Input.GetKey(KeyCode.S))
       {
           if (faceRight)
           {
               sKey = true;
               dKey = false;
               move += speed;
               if (move > maxSpeed) move = maxSpeed;
           }
           else if (faceRight == false)
           {
               sKey = true;
               aKey = false;
               move -= speed;
               if (move < maxSpeed * -1) move = maxSpeed * -1;
           }

           rigi.AddForce(new Vector2(move * Time.deltaTime, 0));
           rigi.velocity = new Vector2(move * Time.deltaTime, 0);

           //transform.TransformDirection(new Vector3(speed * Time.deltaTime, 0, 0));
       }

       //hit the A Key
       if (aKey == false && Input.GetKey(KeyCode.A))
       {
           aKey = true;
           sKey = false;
           dKey = false;
           faceRight = false;
           move -= speed;
           if (move < maxSpeed * -1) move = maxSpeed * -1;
           rigi.AddForce(new Vector2(move * Time.deltaTime, 0));
           rigi.velocity = new Vector2(move * Time.deltaTime, 0);
           //transform.TransformDirection(new Vector3(speed * Time.deltaTime, 0, 0));
       }

       //Not hitting any keys so you slow down
       //not very smooth, need to work on
       if (Input.GetKey(KeyCode.D) == false && Input.GetKey(KeyCode.S) == false && Input.GetKey(KeyCode.A) == false)
       {
           move -= 3;
           if (move < 0) move = 0;

           rigi.AddForce(new Vector2(move * Time.deltaTime, 0));
           rigi.velocity = new Vector2(move * Time.deltaTime, 0);
       }

       float x = transform.position.x;
       float y = transform.position.y;
       //Debug.Log(x + ", " + y);
       //Debug.Log("faceRight variable: " + faceRight);

       //flip left and right
       /*
       if (move > 0 && faceRight)
       {
           Flip();
       }
       else if (move < 0 && !faceRight)
       {
           Flip();
       }
      
       if (controller.isGrounded)
       {
           moveDirection = new Vector2(Input.GetAxis("Horizontal"), 0);
           moveDirection = transform.TransformDirection(moveDirection);

           moveDirection *= speed;

           if (Input.GetButton("Jump"))
           {
               moveDirection.y = jumpSpeed;
           }

           /*
           if (Input.GetButtonDown("Run"))
           {
               speed = speed + 10;
               jumpSpeed = jumpSpeed + 5;
           }
             
       }
        
       if (Input.GetButtonUp("Run"))
       {
           speed = 20.0f;
           jumpSpeed = 13.0f;
       }
        
       moveDirection.y -= gravity * Time.deltaTime;

       controller.Move(moveDirection * Time.deltaTime);
       Debug.Log(controller.isGrounded ? "Grounded" : "Ungrounded");
    
   }*/


}
