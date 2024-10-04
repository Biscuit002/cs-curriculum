using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public Vector3 target;
    public PlayerController playerController;
    private int speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 current = transform.position;
        target = new Vector3(playerController.playerX, playerController.playerY, 0);
        print(target);
        Vector3 newPosition = Vector3.MoveTowards(current, target, speed*Time.deltaTime);
    }
}
