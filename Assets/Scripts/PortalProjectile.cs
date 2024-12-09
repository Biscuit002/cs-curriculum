using System.ComponentModel;
using UnityEngine;

public class PortalProjectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed;
    private bool isFiring;
    private Vector3 targetPosition; 
    public GameObject portal1Projectile;
    public GameObject portal1Portal;
    public GameObject portalProjectileClone;
    
    public PlayerController playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerController = FindObjectOfType<PlayerController>();
        speed = 50f;
        isFiring = false;
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = 0;

        if (!isFiring)
        {
            transform.position = new Vector3(playerController.playerX, playerController.playerY, 0);
        }

        if (Input.GetMouseButtonDown(1))
        {
            rb.linearVelocity = Vector2.zero;
            isFiring = false;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isFiring = true;
            Vector2 direction = (targetPosition - transform.position);
            portalProjectileClone = Instantiate(portal1Projectile, transform.position, Quaternion.identity);
            portalProjectileClone.GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") && !other.CompareTag("Portal"))
        {
            Destroy(portalProjectileClone);
            //Instantiate(portal1Portal, transform.position, Quaternion.identity);
        }
    }
}
