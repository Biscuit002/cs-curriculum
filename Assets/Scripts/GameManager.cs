using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager gm;
    public int coins;
    public int health;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI healthText;
    
    private void Awake()
    {
        if (gm != null && gm != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            gm = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        coinsText.text = "Coins: " + coins;
        healthText.text = "Health: " + health;
    }

    private void Update()
    {
        coinsText.text = "Coins: " + coins;
        healthText.text = "Health: " + health;
        
            Die();
    }

    private void Die()
    {
        if (health == 0)
        {
            SceneManager.LoadScene("Start");
            coins = 0;
            health = 100;
        }
    }
}
