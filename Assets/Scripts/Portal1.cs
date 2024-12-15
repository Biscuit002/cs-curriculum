using UnityEngine;

public class Portal1 : MonoBehaviour
{
    private Vector2 newLocation;
    public GameObject portal2;
    public Portal2 portal2Script;
    private static Portal1 existingPortal;

    void Start()
    {
        if (existingPortal != null)
        {
            Destroy(existingPortal.gameObject);
        }
        existingPortal = this;

        portal2 = GameObject.Find("Portal2Portal");
        portal2Script = FindObjectOfType<Portal2>();
    }

    void Update()
    {
       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            newLocation = portal2.transform.position;
            collision.gameObject.transform.position = newLocation;
            portal2Script.inPortal1 = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            portal2Script.inPortal1 = false;
        }
    }
}
