using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public EnemyScript enemyScript;
    public Transform firePoint;
    public float fireRate = 1f;
    public float projectileSpeed;
    public float fireCooldown;


    public void Shoot()
    {
        GameObject bulletInstance = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        Vector3 direction = (enemyScript.target.transform.position - firePoint.transform.position).normalized;

        Rigidbody rb = bulletInstance.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = direction * projectileSpeed;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        fireCooldown = 0f;
        enemyScript = GetComponent<EnemyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        fireCooldown -= Time.deltaTime;

        if (enemyScript.canSeePlayer == true && fireCooldown <= 0f)
        {
            Shoot();

            fireCooldown = fireRate;
        }
    }
}
