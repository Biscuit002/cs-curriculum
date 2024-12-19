using System;
using Unity.VisualScripting;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public CavePlatform cavePlatformScript;
    private bool playerInTrigger = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.Q))
        {
            cavePlatformScript.SwitchPlatform();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInTrigger = false;
        }
    }
}
