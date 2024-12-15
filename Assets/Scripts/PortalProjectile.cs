using System.ComponentModel;
using UnityEngine;

public class PortalProjectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed;
    private bool isFiring;
    public bool isPortal1;
    private Vector3 targetPosition; 
    public GameObject portal1Projectile;
    public GameObject portal1Portal;
    public GameObject portalProjectileClone;
    public GameObject portal2Portal;
    
    public PlayerController playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerController = FindObjectOfType<PlayerController>();
        speed = 2f;
        isFiring = false;
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = 0;
        print(isPortal1);

        if (!isFiring)
        {
            transform.position = new Vector3(playerController.playerX, playerController.playerY, 0);
        }

        if (Input.GetMouseButtonDown(1))
        {
            rb.linearVelocity = Vector2.zero;
            isFiring = false;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isPortal1 == false)
            {
                isPortal1 = true;
            } 
            else if (isPortal1  != false)
            {
                isPortal1 = false;
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            isFiring = true;
            Vector2 direction = (targetPosition - transform.position);
            Instantiate(portal1Projectile, transform.position, Quaternion.identity);
            rb.AddForce(direction * speed, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CaveWalls") && isFiring == true)
        {
            Destroy(gameObject);
            if (isPortal1 == true)
            {
                Instantiate(portal1Portal, transform.position, Quaternion.identity);
            }
            else if (isPortal1 == false)
            {
                Instantiate(portal2Portal, transform.position, Quaternion.identity);
            }
        }
    }
}
