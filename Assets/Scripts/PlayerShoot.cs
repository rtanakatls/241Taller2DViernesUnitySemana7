using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private PlayerMovement playerMovement;
    private float shootTimer;
    [SerializeField] private float shootDelay;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootDelay)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                GameObject obj = Instantiate(bulletPrefab);
                obj.transform.position = transform.position;
                obj.GetComponent<BulletMovement>().SetDirection(playerMovement.Direction);
                shootTimer = 0;
            }
        }
    }
}
