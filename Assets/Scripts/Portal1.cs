using UnityEngine;

public class Portal1 : MonoBehaviour
{
    private Vector2 newLocation;
    public GameObject portal2;
    public Portal2 portal2Script;

    void Start()
    {

        portal2 = GameObject.Find("Portal2Portal");
        portal2Script = FindObjectOfType<Portal2>();
    }

    void Update()
    {
      
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && portal2Script.cooldown <= 0)
        {
            newLocation = portal2.transform.position;
            collision.gameObject.transform.position = newLocation;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            portal2Script.cooldown = portal2Script.cooldownAmount;
        }
    }
}
