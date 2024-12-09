using Unity.VisualScripting;
using UnityEngine;

public class Portal1 : MonoBehaviour
{
    private Vector2 newLocation;
    private bool inPortal;
    public GameObject portal2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        portal2 = GameObject.Find("Portal2Portal");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !inPortal)
        {
            newLocation = portal2.transform.position;
            collision.gameObject.transform.position = newLocation;
            inPortal = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inPortal = false;
        }
    }
}
