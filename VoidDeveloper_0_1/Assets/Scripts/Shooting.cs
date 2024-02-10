using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform spawnPoint;
    public float fireRate = 0.5f;
    public float speed = 10f;
    public List<GameObject> objectsToRemove;

    private float nextFireTime = 0f;

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
        projectileRigidbody.velocity = transform.forward * speed;
        objectsToRemove.Add(projectile);
        Destroy(projectile, 1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (objectsToRemove.Contains(gameObject))
        {
            Destroy(gameObject);
        }
    }
}   