using UnityEngine;
public class PlayerController : MonoBehaviour
{
    // Movement variables
    public float xSpeed = 100f;
    private float xVector = 0f;
    private float xDirection = 0f;

    public float ySpeed = 100f;
    private float yVector = 0f;
    private float yDirection = 0f;

    private Rigidbody2D rb;
    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // Handle input
        float xDirection = Input.GetAxis("Horizontal");

        float yDirection = Input.GetAxis("Vertical");
        // Calculate xVector based on input
        xVector = xSpeed*xDirection*Time.deltaTime;
        yVector = ySpeed * yDirection * Time.deltaTime;
    }
    void FixedUpdate()
    {
        // Apply movement
        Vector2 movement = new Vector2(xVector, yVector);
        transform.Translate(movement);
    }
}