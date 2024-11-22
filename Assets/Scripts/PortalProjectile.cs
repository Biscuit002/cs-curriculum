using UnityEngine;

public class PortalProjectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed;
    private bool isFiring;
    private float distanceToPlayer;
    
    public PlayerController playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerController = FindObjectOfType<PlayerController>();
        speed = 0.01f;
        isFiring = false;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance((new Vector3(playerController.playerX, playerController.playerY, 0)), Input.mousePosition);

        if (!isFiring)
        {
            transform.position = new Vector3(playerController.playerX + 5, playerController.playerY, 0);
        }
        if (Input.GetMouseButtonDown(1))
        {
            isFiring = true;
            rb.AddForce(Input.mousePosition * speed, ForceMode2D.Impulse);
        }
    }
}
