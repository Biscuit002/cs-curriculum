using UnityEngine;

public class Portal2 : MonoBehaviour
{
    private Vector2 newLocation;
    public GameObject portal1;
    public float cooldown;
    public float cooldownAmount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        portal1 = GameObject.Find("Portal1Portal");
        cooldownAmount = 0.5f;
        cooldown = cooldownAmount;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && cooldown <= 0)
        {
            newLocation = portal1.transform.position;
            collision.gameObject.transform.position = newLocation;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cooldown = cooldownAmount;
        }
    }
}
