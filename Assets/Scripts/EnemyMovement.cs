using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb2d;
    private Transform targetTransform;
    [SerializeField] private float followRange;
    [SerializeField] private float stopRange;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        targetTransform = GameObject.Find("Player").transform;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (targetTransform==null)
        {
            rb2d.velocity= Vector3.zero;
            return;
        }
        float distance=Vector2.Distance(transform.position,targetTransform.position);
        if (distance <= followRange && distance>=stopRange)
        {

            Vector2 direction = targetTransform.position - transform.position;
            direction = direction.normalized;
            rb2d.velocity = direction * speed;
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }
            
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, followRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, stopRange);
    }
}
