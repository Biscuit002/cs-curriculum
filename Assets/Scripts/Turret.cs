using System;
using System.Numerics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Turret : MonoBehaviour
{
    public GameObject projectileClone;
    public Vector3 spawnPosition;
    private GameObject target;
    private float cooldown;
    private float fireRate = 1;
    void Start()
    {
        spawnPosition = new Vector3(transform.position.x, transform.position.y + 0.5f, 0);
        target = null;
        cooldown = fireRate;
    }

    private void Update()
    {
        cooldown -= Time.deltaTime;
        print(target);
        if (target != null)
        {
            if (cooldown <= 0)
            {
                Fire();
                cooldown = fireRate;
            } 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            target = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            target = null;  
        }
    }

    void Fire()
    {
        Instantiate(projectileClone, spawnPosition, UnityEngine.Quaternion.identity);
        ProjectileScript cloneScript = projectileClone.GetComponent<ProjectileScript>();
    }
}
