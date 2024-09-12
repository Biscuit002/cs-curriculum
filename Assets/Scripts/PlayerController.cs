using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int coinCount = 0;

    public bool overworld;
    public float xSpeed = 5f;
    private float xVector = 0f;
    private float xDirection = 0f;

    public float ySpeed = 5f;
    private float yVector = 0f;
    private float yDirection = 0f;

    private Rigidbody2D rb;

    private void Start()
    {
        GetComponentInChildren<TopDown_AnimatorController>().enabled = overworld;
        GetComponentInChildren<Platformer_AnimatorController>().enabled = !overworld; //what do you think ! means?

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
        // Handle input
        float xDirection = Input.GetAxis("Horizontal");

        // Calculate xVector based on input
        xVector = xSpeed * xDirection * Time.deltaTime;


        // Apply movement
        transform.Translate(xVector, 0, 0);

        if (overworld)
        {
            float yDirection = Input.GetAxis("Vertical");
            yVector = ySpeed * yDirection * Time.deltaTime;
            transform.Translate(0, yVector, 0);
        }

        Debug.Log(coinCount);
    }

    //for organization, put other built-in Unity functions here

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinCount = coinCount + 1;

            print(coinCount);
        }
    }

    //after all Unity functions, your own functions can go here
}