using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int coinCount;
    
    public bool overworld;
    public float xSpeed;
    private float xVector;
    private float xDirection;

    public float ySpeed;
    private float yVector;
    private float yDirection;

    public float playerX;
    public float playerY;

    private Rigidbody2D rb;
    private void Start()
    {
        GetComponentInChildren<TopDown_AnimatorController>().enabled = overworld;
        GetComponentInChildren<Platformer_AnimatorController>().enabled = !overworld; //what do you think ! means?
        
        xSpeed = 5f;
        ySpeed = 5f;
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();

        if (overworld)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0f;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
        } 

    } 

    private void Update()
    {
        playerX = transform.position.x;
        playerY = transform.position.y;
        
        // Handle input
        xDirection = Input.GetAxis("Horizontal");

        // Calculate xVector based on input
        xVector = xSpeed * xDirection * Time.deltaTime;


        // Apply movement
        transform.Translate(xVector, 0, 0);

        if (overworld)
        {
            yDirection = Input.GetAxis("Vertical");
            yVector = ySpeed * yDirection * Time.deltaTime;
            transform.Translate(0, yVector, 0);
        }
    }



    //for organization, put other built-in Unity functions here

    
    //after all Unity functions, your own functions can go here
}