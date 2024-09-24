using System;
using Unity.VisualScripting;
using UnityEngine;

public class Coins : MonoBehaviour
{ 
    GameManager gm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            gm.coins += 1;
        }
    }
}
