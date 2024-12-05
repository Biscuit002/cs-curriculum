using UnityEngine;

public class PortalProjectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed;
    private bool isFiring;
    private Vector3 targetPosition; 
    public GameObject portal1;
    GameObject portalClone;
    
    public PlayerController playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerController = FindObjectOfType<PlayerController>();
        speed = 3f;
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
            portalClone = Instantiate(portal1, transform.position, Quaternion.identity);
            portalClone.GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") || !collision.gameObject.CompareTag("Portal1"))
        {
            Destroy(portalClone);
        }
    }
}
