using UnityEngine;

public class CavePlatform : MonoBehaviour
{
    private float moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveSpeed = 0.001f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Enemy(Cave)"))
        {
            moveSpeed = -moveSpeed;
        }
    }
}
