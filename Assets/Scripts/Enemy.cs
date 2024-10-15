using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 target;
    private GameObject player;
    private states state = states.patrol;
    private float chaseSpeed;
    
    public PlayerController playerController;
    enum states
    {
        patrol,
        chase,
        attack,
        die
    }
    void Start()
    {
        chaseSpeed = 1f;
    }
    void Update()
    {
       print(state);
       target = new Vector3(playerController.playerX, playerController.playerY, 0);
        if (state == states.chase)
        {
            Chase();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.CompareTag("Player")) 
      {
          player = other.gameObject;
          if (player == null)
          {
              state = states.chase;
          }
          else
          {
              state = states.chase;
          }
      }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        state = states.patrol;
    }

    void Chase()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, chaseSpeed * Time.deltaTime);
    }
}
