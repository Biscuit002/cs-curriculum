using System;
using UnityEngine;
using Input = UnityEngine.Windows.Input;

public class Door : MonoBehaviour
{
    private PlayerController playerController;
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && playerController.hasAxe == true)
        {
            Destroy(this.gameObject);
        }
    }
}