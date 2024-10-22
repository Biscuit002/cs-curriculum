using System;
using System.IO;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.Timeline;

public class Enemy : MonoBehaviour
{
    private Vector3 target;
    private GameObject player;
    public states state = states.patrol;
    private float chaseSpeed;
    private Vector3 waypoint;
    private float cooldownEnemy;
    
    public PlayerController playerController;
    public Health health;
    
    public enum states
    {
        patrol,
        chase,
        attack,
        die
    }
    void Start()
    {
        chaseSpeed = 2f;
        waypoint = new Vector3(1, 2, 0);
        cooldownEnemy = 1f;
    }
    void Update()
    {
       print(cooldownEnemy);
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
        cooldownEnemy = cooldownEnemy - Time.deltaTime;
        if (cooldownEnemy <= 0)
        {
            health.gm.health -= 10;
            cooldownEnemy = 1;
        }
    }

    void Patrol()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoint, chaseSpeed * Time.deltaTime);
    }
}
