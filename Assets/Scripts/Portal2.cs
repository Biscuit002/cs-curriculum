using UnityEngine;

public class Portal2 : MonoBehaviour
{
    private Vector2 newLocation;
    public GameObject portal1;
    public bool inPortal1;
    private static Portal2 existingPortal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (existingPortal != null)
        {
            Destroy(existingPortal.gameObject);
        }
        existingPortal = this;
        portal1 = GameObject.Find("Portal1Portal");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject!=null)
            {
                if (collision.gameObject.CompareTag("Player") && inPortal1 == false && portal1 != null)
                {
                    newLocation = portal1.transform.position;
                    collision.gameObject.transform.position = newLocation;
                    inPortal1 = true;
                }
            }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inPortal1 = false;
        }
    }
}
