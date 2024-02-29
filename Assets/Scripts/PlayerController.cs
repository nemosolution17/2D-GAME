using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //All Player Variables

    public bool pausePlayer; //master kill switch

    //ladder variables

    private bool isClimbing;
    private float gravScale;
    private float verticalInput;
    public float ladderCheckDistance;
    public LayerMask whatIsLadder;

    //player Movement Variables
    private float moveInput; // the variable used to determine which direction the player wishes to move in.
    public float moveSpeed; // the speed at which the player will move with.

    private float dashDuration; //the current timer for dashing/sliding
    public float dashMaxDuration; //the amount of time the player can dash/slide for
    public float dashSpeed; //the speed at which the player dashes/slides
    private bool isDashing; //bool to check if player is dashing
    private bool isSliding; //bool to check if player is sliding

    //Player Jump Variables
    private int jumpNumber; //the number of jumps currently avaible to the player
    public int maxJumps; //the maxium number of jumps
    public float jumpSpeed; // the speed at which the player will jump with.

    //Player Wall Jump Variables
    public float wallSlideSpeed; //the speed at which the player will slide down the wall at
    private bool isWallSliding; //determines if the player is wallsliding or not.

    //Shooting
    public Transform firePoint; //the transform used to emit the projectile from
    public LayerMask whatToHit; //the layer used to detect where enemies are


    //Player Physics and Animation Variables
    private Rigidbody2D playerBody; // the rigidbody used for interacting with the environment around the gameobject.
    private bool facingRight = true; // the variable used to determine which direction the player sprite should be facing.

    private bool isGrounded; // the variable used to state if the player is touching the ground or not.
    public Transform groundCheck; // the transform used to check if a ground layer mask is colliding.
    public float checkRadiusDown; // the radius of the circle used for collision checking.
    public LayerMask whatIsGround; // the layer mask used for ground layer.

    private bool touchingWall; // the variable used to state if the player is touching a wall.
    public Transform wallCheck; // the transform used to detect if a player is touching a wall
    public float wallCheckDistance; //the distance the player can detect if he is on a wall or not.

    private Animator animator; //the animator script that connects the animations to this script.

    //NEW
    public int curHealth = 5; // Stores the current health of the player
    public int maxHealth = 5; // Stores the max health of the player
    public Death death; // References the Death Script
    public Score score; // References Score script
    bool collected = false; // So coins don't double
    bool lostHeart = false;
    //END

    void Start()
    {
        //intializing variables
        pausePlayer = false;
        jumpNumber = maxJumps;
        animator = GetComponent<Animator>();
        playerBody = GetComponent<Rigidbody2D>();

        gravScale = playerBody.gravityScale;

        //NEW
        curHealth = maxHealth; // Ensures that currentHealth does not exceed maxHealth
        death = FindObjectOfType<Death>(); // Gets the Death script
        score = FindObjectOfType<Score>(); // Gets Score script
        //END
    }

    // Update is called a fixed amount of times per frame
    void FixedUpdate()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, ladderCheckDistance, whatIsLadder);

        if (hitInfo.collider != null)
        {
            if (Input.GetAxisRaw("Vertical") < 0 || Input.GetButton("Jump"))
            {
                isClimbing = true;
                isWallSliding = false;
            }
        }
        else
        {
            if (moveInput < 0 || moveInput > 0)
            {
                isClimbing = false;
            }
        }

        if (isClimbing && hitInfo.collider != null)
        {
            verticalInput = Input.GetAxisRaw("Vertical");
            playerBody.velocity = new Vector2(playerBody.velocity.x, verticalInput * moveSpeed);
            playerBody.gravityScale = 0;
            isWallSliding = false;
        }
        else
        {
            playerBody.gravityScale = gravScale;
        }
        //Calculating Collisions for the ground and walls
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadiusDown, whatIsGround); // Checks for collision of the ground and the player.
        touchingWall = Physics2D.Raycast(wallCheck.position,  wallCheck.right ,wallCheckDistance,whatIsGround);

        if (((!touchingWall && isGrounded) || (!touchingWall && !isGrounded) || (touchingWall && isGrounded)) && !isWallSliding && !isDashing && !isSliding && !pausePlayer)
        {
            Vector2 velocity = playerBody.velocity;
            velocity.x = moveInput * moveSpeed;
            playerBody.velocity = velocity;
            if ((!facingRight && moveInput > 0) || (facingRight && moveInput < 0))
            {
                Flip();
            }

        }


        if (touchingWall && !isGrounded && playerBody.velocity.y < 0 && !pausePlayer && !isClimbing && hitInfo.collider==null)
        {
            isWallSliding = true;
            animator.SetBool("isWallSliding", true);
        }

        if (!touchingWall && (!isGrounded || isGrounded))
        {
            
            isWallSliding = false;
            animator.SetBool("isWallSliding", false);
        }
    }

    // Update is called once per frame
    void Update()

    {

        if (pausePlayer)
        {
            animator.SetFloat("moveSpeed", 0f);
            animator.SetFloat("jumpSpeed", 0f);
        }

        if (!pausePlayer)
        {
            moveInput = Input.GetAxisRaw("Horizontal"); //Checking if player pressed the Movement Keys
            animator.SetFloat("moveSpeed", Mathf.Abs(moveInput));
            animator.SetFloat("jumpSpeed", playerBody.velocity.y);
            animator.SetBool("isGrounded", isGrounded);
        }
        //Determining if dashing or sliding
        if (Input.GetButtonDown("Dash") && !pausePlayer)
        {
            if (isGrounded)
            {
                isSliding = true;
                animator.SetBool("isSliding", true);
            }
            else
            {
                isDashing = true;
                animator.SetBool("isDashing", true);
            }
        }

        //Dashing code
        if (isDashing && dashDuration > 0 && !touchingWall && !pausePlayer)
        {
            if (facingRight)
            {
                transform.position = new Vector2(transform.position.x + dashSpeed * Time.deltaTime, transform.position.y);

            }
            else
            {
                transform.position = new Vector2(transform.position.x - dashSpeed * Time.deltaTime, transform.position.y);
               
            }
            dashDuration -= Time.deltaTime;
        }
        else if (touchingWall)
        {
            dashDuration = 0;
            isDashing = false;
            animator.SetBool("isDashing", false);
        }
        else
        {
            isDashing = false;
            animator.SetBool("isDashing", false);
        }

        //Sliding code
        if (isSliding && dashDuration > 0 && !pausePlayer)
        {
            transform.GetComponent<CapsuleCollider2D>().enabled = false;
            if (facingRight)
            {
                transform.position = new Vector2(transform.position.x + dashSpeed * Time.deltaTime, transform.position.y);
          
            }
            else
            {
                transform.position = new Vector2(transform.position.x - dashSpeed * Time.deltaTime, transform.position.y);
                
            }
            dashDuration -= Time.deltaTime;
        }
        else if (touchingWall)
        {
            dashDuration = 0;
            isSliding = false;
            animator.SetBool("isSliding", false);
        }
        else
        {
            isSliding = false;
            animator.SetBool("isSliding", false);
            transform.GetComponent<CapsuleCollider2D>().enabled = true;
        }

        //reseting variables for jumping and wallsliding
        if (isGrounded && !isDashing && !isSliding)
        {
            jumpNumber = maxJumps;
            dashDuration = dashMaxDuration;
            isWallSliding = false;
            animator.SetBool("isWallSliding", false);
            animator.SetBool("isSliding", false);
            animator.SetBool("isDashing", false);
        }

        //Jumping code
        if (isGrounded && !isWallSliding && !isDashing && !isSliding && Input.GetButtonDown("Jump") && !pausePlayer)
        {
            jumpNumber = jumpNumber - 1;
            Vector2 velocity = playerBody.velocity;
            velocity.y = jumpSpeed;
            playerBody.velocity = velocity;
        }
        if (!isGrounded && jumpNumber > 1 && !isWallSliding && !isDashing && !isSliding && Input.GetButtonDown("Jump") && !pausePlayer)
        {
            jumpNumber = jumpNumber - 1;
            Vector2 velocity = playerBody.velocity;
            velocity.y = jumpSpeed;
            playerBody.velocity = velocity;
        }
            
        //adding wall sliding if he touched a wall
        if (isWallSliding && !pausePlayer)
        {
            playerBody.velocity = new Vector2(0, -wallSlideSpeed);
            if (Input.GetButtonDown("Jump"))
            {
                if (!facingRight)
                {
                    if (moveInput == 1)
                    {
                        transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y + jumpSpeed / 2 * Time.deltaTime);
                        Vector2 velocity = playerBody.velocity;
                        velocity.x = -moveSpeed;
                        velocity.y = jumpSpeed;
                        playerBody.velocity = velocity;
                        isWallSliding = false;
                        
                        animator.SetBool("isWallSliding", false);
                    }
                    if (moveInput == 0)
                    {
                        transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y + (jumpSpeed)/2 * Time.deltaTime);
                        isWallSliding = false;
                        animator.SetBool("isWallSliding", false);
                    }
                }
                else
                {

                    if (moveInput == -1)
                    {
                        transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y + jumpSpeed / 2 * Time.deltaTime);
                        Vector2 velocity = playerBody.velocity;
                        velocity.x = moveSpeed;
                        velocity.y = jumpSpeed;
                        playerBody.velocity = velocity;
                       
                        isWallSliding = false;
                        
                        animator.SetBool("isWallSliding", false);
                    }
                    if (moveInput == 0)
                    {
                        transform.position = new Vector2(transform.position.x - moveSpeed* Time.deltaTime, transform.position.y + jumpSpeed/2 * Time.deltaTime);
                        isWallSliding = false;
                        animator.SetBool("isWallSliding", false);
                    }
                }
            }
        }

        //NEW
        // Sets the players current health
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        // Calls the Die() function if players health reaches 0 (Die() is in PlayerController)
        if (curHealth <= 0)
        {
            Die();
        }
        collected = false; // so coins do not double
        lostHeart = false;
        //END

    }

    // Method used to make the character animations flip nicely
    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f,180f,0f);
    }

    //NEW

    // Called by PlayerController script when player health reaches 0
    // Die() calls the PlayerDeath script to handle death mechanics
    void Die()
    {
        death.PlayerDeath();
    }

    // Lowers the players health by one. Called by KillPlayer script
    public void setHealth()
    {
        if (lostHeart) return;
        curHealth = curHealth - 1;
        lostHeart = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            if (collected) return;
            collected = true;
            score.score += 100;
        }
    }
    //END

}