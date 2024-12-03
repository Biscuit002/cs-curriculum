using System;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public Vector3 target;
    public PlayerController playerController;
    private int speed;
    private Vector3 current;
    private Vector3 direction;
    private GameManager gm;
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        speed = 5;
        target = new Vector3(playerController.playerX, playerController.playerY, 0);
        direction = (target - transform.position).normalized;
    }
    void Update()
    {
        Vector3 current = transform.position;
        Vector3 newPosition = Vector3.MoveTowards(current, target, speed*Time.deltaTime);
        transform.position += speed * direction * Time.deltaTime;
    }

   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
