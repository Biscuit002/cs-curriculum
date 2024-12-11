using UnityEngine;

public class Portal2 : MonoBehaviour
{
    private Vector2 newLocation;
    private float cooldown;
    public GameObject portal1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        portal1 = GameObject.Find("Portal1Portal");
        cooldown = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && cooldown <= 0)
        {
            newLocation = portal1.transform.position;
            collision.gameObject.transform.position = newLocation;
            cooldown = 2;
        }
    }
}
