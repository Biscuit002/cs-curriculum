using System;
using UnityEngine;

public class AxeScript : MonoBehaviour
{
    

    private void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (this.gameObject != null)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void Update()
    {
        
    }
}