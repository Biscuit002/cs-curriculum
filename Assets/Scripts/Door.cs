using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    private PlayerController playerController;
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && playerController.hasAxe && Input.GetMouseButtonDown(0))
        {
            Destroy(this.gameObject);
        }
    }
}