using UnityEngine;

public class CaveEnemy : MonoBehaviour
{
    private bool isRight;

    private Collider2D collider2d;
    private float length;
    private float moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isRight = true;
        length = 0.5f;
        moveSpeed = 1;

        collider2d = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D rightRay = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.right, length);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), Vector2.right * length);
        RaycastHit2D leftRay = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.left, length);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), Vector2.left * length);

        if (rightRay.collider != null)
        {
            isRight = false;
        }
        if (leftRay.collider != null)
        {
            isRight = true;
        }
        if (isRight)
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }
        if (!isRight)
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetMouseButton(0))
         {
            Destroy(gameObject);
         }
    }
}
