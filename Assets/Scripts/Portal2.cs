using UnityEngine;

public class Portal2 : MonoBehaviour
{
    private Vector2 newLocation;
    public GameObject portal1;
    private bool inPortal1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        portal1 = GameObject.Find("Portal1Portal");
        inPortal1 = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && inPortal1 == false)
        {
            newLocation = portal1.transform.position;
            collision.gameObject.transform.position = newLocation;
            inPortal1 = true;
        }
    }
    void OnTiggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inPortal1 = false;
        }
    }
}
