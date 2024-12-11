using Unity.VisualScripting;
using UnityEngine;

public class Portal1 : MonoBehaviour
{
    private Vector2 newLocation;
    private float cooldown;
    public GameObject portal2;

    void Start()
    {
        portal2 = GameObject.Find("Portal2Portal");
        cooldown = 0;
    }

    void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime; // Use Time.deltaTime for frame-rate independent decrement
        }
        print(cooldown);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && cooldown <= 0)
        {
            newLocation = portal2.transform.position;
            collision.gameObject.transform.position = newLocation;
            cooldown = 2; // Reset cooldown immediately after teleportation
        }
    }
}
