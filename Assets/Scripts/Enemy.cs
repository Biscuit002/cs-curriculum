using System;
using Unity.Mathematics;
using UnityEngine;
using Random = System.Random;

public class Enemy : MonoBehaviour
{
    private Vector3 target;
    private Vector3 current;
    private GameObject player;
    public states state = states.patrol;
    private float chaseSpeed;
    private Vector3 waypoint;
    private float cooldownEnemy;
    
    public GameObject axeClone;
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
        cooldownEnemy = 1f;
        waypoint = new Vector3(UnityEngine.Random.Range(-100, 100), UnityEngine.Random.Range(-100,100), 0);
    }
    void Update()
    {
       target = new Vector3(playerController.playerX, playerController.playerY, 0);
       current = new Vector3(transform.position.x, transform.position.y, 0);
       
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
          waypoint = new Vector3(UnityEngine.Random.Range(-100, 100), UnityEngine.Random.Range(-100,100), 0);
      }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (state == states.attack && Input.GetMouseButton(0))
        {
            Destroy(this.gameObject);
            AxeScript axeScript = axeClone.GetComponent<AxeScript>();
            Instantiate(axeClone, current, UnityEngine.Quaternion.identity);
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
