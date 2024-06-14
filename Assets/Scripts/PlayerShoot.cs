using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private PlayerMovement playerMovement;
    private float shootTimer;
    private Camera cam;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        cam=GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= PlayerStats.shootDelay)
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 direction = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                direction = direction.normalized;
                GameObject obj = Instantiate(bulletPrefab);
                obj.transform.position = transform.position;
                obj.GetComponent<BulletMovement>().SetDirection(direction);
                shootTimer = 0;
            }
        }
    }
}
