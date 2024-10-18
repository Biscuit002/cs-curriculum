using System;
using System.IO;
using UnityEngine;
using UnityEngine.Timeline;

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
        chaseSpeed = 2f;
    }
    void Update()
    {
       print(state);
       target = new Vector3(playerController.playerX, playerController.playerY, 0);
       
        if (state == states.chase)
        {
            Chase();
        }
        if (state == states.attack)
        {
            Attack();
        }

        if (state == states.patrol)
        {
            Patrol();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    { 
      if (other.CompareTag("Player")) 
      {
          if (player == null)
          {
              state = states.chase;
          }
          else
          {
              state = states.attack;
          }
          player = other.gameObject;
      }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (player == null)
            {
                state = states.patrol;
            }
            else
            {
                state = states.chase;
            }

            player = null;
        }
    }

    void Chase()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, chaseSpeed * Time.deltaTime);
    }

    void Attack()
    {

    }

    void Patrol()
    {
        //TODO:Add code
    }
}
