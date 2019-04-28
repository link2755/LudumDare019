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
    public AudioManager audioManager;
    public Animator animator;

    public GameObject shout;
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
        // RUN ==========================================

        acceleration += superAcceleration * Time.deltaTime;
        if (acceleration > 10)
        {
            acceleration = 10;
        }

        moveSpeed += acceleration * Time.deltaTime;
        if (moveSpeed > 25)
        {
            moveSpeed = 25;
        }

        // Animator
        if (jumping <= 0 || jumping > 0.25)
        {
            animator.speed = moveSpeed / 10;
            if (moveSpeed > 0.1 && moveSpeed <= 2)
            {
                animator.speed = 0.2f;
            }
            if (moveSpeed <= 0)
            {
                animator.Play("Running", -1, 0);
                animator.speed = 0;
            }
        }

        movement.x = moveSpeed;

        // JUMP ===========================================

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
                            gameScript.stress += 40;
                        }
                        jumpCount++;
                    jumping += Time.deltaTime;
                    animator.speed = 1;
        }

            // Continue Jump
            if (Input.GetKey(KeyCode.Space))
            {
                jumping += Time.deltaTime;
                animator.speed = 1;
                if (jumping > 0 && jumping <= 0.25)
                {
                    movement.y += 2.5f*jumpSpeed * Time.deltaTime;
                }

            }

            if (Input.GetKeyUp(KeyCode.Space)) { 
                jumping = 0;
            }

        // SCREAM =====================
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetBool("Shouting", true);
            shout.GetComponent<ScreamScript>().active = true;
            gameScript.stress += 25;
            animator.speed = 1;
        } else
        {
            animator.SetBool("Shouting", false);
            //shout.GetComponent<ScreamScript>().active = false;
        }


        // MOVEMENT ================================

        animator.SetFloat("Jumping", jumping);
        myRigidBody.velocity = movement;

        // RESET =======================

        if (Input.GetKeyDown(KeyCode.R))
        {
            gameScript.stress = 0;
            gameScript.pills = 10;
            audioManager.Stop("Game Song");
            audioManager.Play("Game Song");
            moveSpeed = 0;
            acceleration = 0;
            animator.Play("Running", -1, 0);
            animator.speed = 0;
            transform.position = new Vector3(2.40f, -0.58f);
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            moveSpeed = -2;
            acceleration = 2;
            movement.y = 4;
            audioManager.Play("Crash");

        }

        if (other.gameObject.tag == "Chão")
        {
            isGrounded = true;
            //Debug.Log("no Chao");
            jumpCount = 0;

        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Chão")
        {
            isGrounded = false;
            //Debug.Log("sem Chao");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bandido")
        {
            if (other.gameObject.GetComponent<SpriteRenderer>().sprite != ladraoAssustado)
            {   
                gameScript.pills -= 1;
                other.gameObject.GetComponent<SpriteRenderer>().sprite = ladraoRoubando;
            }
        }
    }
}
