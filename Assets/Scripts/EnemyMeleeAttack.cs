using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRadius;
    [SerializeField] private LayerMask attackLayerMask;
    [SerializeField] private float attackDelay;
    private float attackTimer;

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackDelay)
        {
            Collider2D collider = Physics2D.OverlapCircle(attackPoint.position, attackRadius, attackLayerMask);
            if (collider != null)
            {
                if (collider.gameObject.GetComponent<PlayerLife>() != null)
                {
                    collider.gameObject.GetComponent<PlayerLife>().ChangeLife(-1);
                }
            }
            attackTimer = 0;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
