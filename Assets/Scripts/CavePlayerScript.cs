using UnityEngine;

public class CavePlayerScript : MonoBehaviour
{
    Collider2D collider2d;
    public float length;
    private float jumpForce;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        collider2d = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        length = 0.9f;
        jumpForce = 5;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D leftRay = Physics2D.Raycast(new Vector2(transform.position.x - collider2d.bounds.extents.x, transform.position.y), Vector2.down, length);
        RaycastHit2D rightRay = Physics2D.Raycast(new Vector2(transform.position.x + collider2d.bounds.extents.x, transform.position.y), Vector2.down, length);
        Debug.DrawRay(new Vector2(transform.position.x - collider2d.bounds.extents.x, transform.position.y), Vector2.down * length, Color.red);
        Debug.DrawRay(new Vector2(transform.position.x + collider2d.bounds.extents.x, transform.position.y), Vector2.down * length, Color.red);

        if ((leftRay.collider != null || rightRay.collider != null) && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
