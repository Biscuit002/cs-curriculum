using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public Vector3 target;
    private int speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        target = new Vector3(PlayerController.playerX, PlayerController.playerY, 0);
    }
}
