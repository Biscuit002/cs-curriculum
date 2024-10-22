using System;
using System.Numerics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
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
        if (target != null)
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                Instantiate(projectileClone, spawnPosition, quaternion.identity);
                ProjectileScript cloneScript = projectileClone.GetComponent<ProjectileScript>();
                cooldown = fireRate;
            } 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        target = other.gameObject;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        target = null;
    }
}
