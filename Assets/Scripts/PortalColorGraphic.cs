using UnityEngine;
using UnityEngine.UI;

public class PortalColorGraphic : MonoBehaviour
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdatePortalColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method to update the portal color
    public void UpdatePortalColor()
    {
        if (PortalProjectile.isPortal1)
        {
            GetComponent<Image>().color = Color.blue;
        }
        else
        {
            GetComponent<Image>().color = Color.red;
        }
    }
}