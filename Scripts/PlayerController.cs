using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float acceleration;
    public float superAcceleration;
    public float jumpSpeed;
    public float jumping = 0;
    private float gravity = -10f;
    public Rigidbody2D myRigidBody;
    private bool isGrounded = true;
    public int jumpCount = 0;
    public GameScript gameScript;
    public Animator animator;

    public Sprite ladraoRoubando;
    public Sprite ladraoAssustado;

    private Vector2 movement = new Vector2(0f, 0f);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Run

        acceleration += superAcceleration * Time.deltaTime;
        if (acceleration > 7)
        {
            acceleration = 7;
        }

        moveSpeed += acceleration * Time.deltaTime;
        if (moveSpeed > 30)
        {
            moveSpeed = 30;
        }

        // Animator
        if (jumping <= 0 || jumping > 0.25)
        {
            animator.speed = moveSpeed / 10;
            if (moveSpeed > 0)
            {
                animator.speed = 1;
            }
            if (moveSpeed <= 0)
            {
                animator.Play("Running", -1, 0);
                animator.speed = 0;
            }
        }

        movement.x = moveSpeed;

        // Jump

            // Gravity
            if ((jumping <= 0 || jumping > 0.25) && isGrounded == false)
            {
                movement.y += gravity*Time.deltaTime;
            }

            // Begin Jump
            if (Input.GetKeyDown(KeyCode.Space))
                {
                    animator.Play("Jumping", -1, 1);

                    movement.y = jumpSpeed/2;
                        if (jumpCount >= 2)
                        {
                            gameScript.stress += 50;
                        }
                        jumpCount++;
                    jumping += Time.deltaTime;
            }

            // Continue Jump
            if (Input.GetKey(KeyCode.Space))
            {
                jumping += Time.deltaTime;
                if (jumping > 0 && jumping <= 0.25)
                {
                    movement.y += 2f*jumpSpeed * Time.deltaTime;
                }

            }

            if (Input.GetKeyUp(KeyCode.Space)) { 
                jumping = 0;
            }

        // Scream
        if (Input.GetKeyDown(KeyCode.Z))
        {
            gameScript.stress += 25;
        }

        // Slide

        animator.SetFloat("Jumping", jumping);
        myRigidBody.velocity = movement;
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            moveSpeed = -4;
            acceleration = 2;
            movement.y = 8;

        }

        if (other.gameObject.tag == "Chão")
        {
            isGrounded = true;
            Debug.Log("no Chao");
            jumpCount = 0;

        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Chão")
        {
            isGrounded = false;
            Debug.Log("sem Chao");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bandido" )
        {
            gameScript.pills -= 1;
            other.gameObject.GetComponent<SpriteRenderer>().sprite = ladraoRoubando;
        }
    }
}
