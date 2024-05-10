using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private float shootTimer;
    [SerializeField] private float shootDelay;
    private Transform targetTransform;

    private void Start()
    {
        targetTransform = GameObject.Find("Player").transform;
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
            Vector2 direction = targetTransform.position - transform.position;
            direction = direction.normalized;
            Shoot(direction);
            shootTimer = 0;
        }
    }

    void Shoot4DirectionsRelativeToPlayer(Vector2 direction)
    {
        Shoot(direction);
        Shoot(Vector2.Perpendicular(direction));
        Shoot(Vector2.Perpendicular(Vector2.Perpendicular(direction)));
        Shoot(Vector2.Perpendicular(Vector2.Perpendicular(Vector2.Perpendicular(direction))));

    }

    void Shoot8Directions()
    {
        Shoot(new Vector2(0, 1));
        Shoot(new Vector2(1, 1));
        Shoot(new Vector2(1, 0));
        Shoot(new Vector2(1, -1));
        Shoot(new Vector2(0, -1));
        Shoot(new Vector2(-1, -1));
        Shoot(new Vector2(-1, 0));
        Shoot(new Vector2(-1, 1));
    }

    void Shoot(Vector2 direction)
    {
        direction = direction.normalized;
        GameObject obj = Instantiate(bulletPrefab);
        obj.transform.position = transform.position;
        obj.GetComponent<BulletMovement>().SetDirection(direction);

    }
}
