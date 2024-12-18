using UnityEngine;
using UnityEngine.UI;

public class PortalColorGraphic : MonoBehaviour
{
    public PortalProjectile portalProjectileScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        portalProjectileScript = FindObjectOfType<PortalProjectile>();
    }

    // Update is called once per frame
    void Update()
    {
        //UpdatePortalColor();
    }

    // Method to update the portal color
    public void UpdatePortalColor()
    {
        Debug.Log("UpdatePortalColor() called.");
        if (portalProjectileScript.isPortal1)
        {
            GetComponent<Image>().color = Color.blue;
        }
        else
        {
            GetComponent<Image>().color = Color.red;
        }
    }
}