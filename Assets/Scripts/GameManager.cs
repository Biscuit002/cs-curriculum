using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager gm;
    public int coins;
    public int health;

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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
