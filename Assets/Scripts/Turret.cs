using System;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Turret : MonoBehaviour
{
    public GameObject projectileClone;
    public Vector3 spawnPosition;
    private int maxProjectiles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPosition = new Vector3(transform.position.x, transform.position.y + 0.5f, 0);
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            if (maxProjectiles < 5)
            {
                Instantiate(projectileClone, spawnPosition, quaternion.identity);
                ProjectileScript cloneScript = projectileClone.GetComponent<ProjectileScript>();
                maxProjectiles += 1;
            }
            else
            {
                maxProjectiles = 0;
            }
            
        }
    }
}
