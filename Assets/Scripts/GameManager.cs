using System;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager gm;
    public int coins;
    public int health;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI gameOver;
    
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
        gameOver.enabled = false;
    }

    private void Update()
    {
        coinsText.text = "Coins: " + coins;
        healthText.text = "Health: " + health;
        
        if (gm.health == 0)
        {
            Time.timeScale = 0;
            gameOver.enabled = true;

        }
    }
}
