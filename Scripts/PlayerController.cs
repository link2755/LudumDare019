using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float acceleration;
    public float superAcceleration;
    public float jumpSpeed;
    public Rigidbody2D myRigidBody;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Run

        acceleration += superAcceleration * Time.deltaTime;
        if (acceleration > 5)
        {
            acceleration = 5;
        }

        moveSpeed += acceleration * Time.deltaTime;
        if (moveSpeed > 18)
        {
            moveSpeed = 18;
        }


        myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);

        // Jump
        if (Input.GetKey(KeyCode.Space))
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpSpeed);
        }

        // Double Jump

        // Scream

        // Slide
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            moveSpeed = -4;
            acceleration = 2;
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, 8);

        }
    }

}
