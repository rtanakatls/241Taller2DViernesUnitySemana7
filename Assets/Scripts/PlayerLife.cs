using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private int life;
    private int maxLife;

    private void Start()
    {
        life = PlayerStats.life;
        maxLife = PlayerStats.life;
        UIController.Instance.UpdateLife(life);
        UIController.Instance.UpdateLifeBar(life,maxLife);
    }

    public void ChangeLife(int value)
    {
        life += value;
        if (life < 0)
        {
            life = 0;
        }
        else if (life > maxLife)
        {
            life = maxLife;
        }
        UIController.Instance.UpdateLife(life);
        UIController.Instance.UpdateLifeBar(life,maxLife);
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            ChangeLife(-1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            ChangeLife(-1);
        }
    }
}
