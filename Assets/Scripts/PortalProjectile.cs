using UnityEngine;

public class PortalProjectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed;
    private bool isFiring;
    private Vector3 targetPosition; 
    
    public PlayerController playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerController = FindObjectOfType<PlayerController>();
        speed = 40f;
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
            Vector3 direction = (targetPosition - transform.position);
            rb.AddForce(direction * speed, ForceMode2D.Impulse);
        }
    }
}
