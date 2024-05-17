using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyPushState
{
    Follow,
    Knockback,
    Stunned
}

public class EnemyPush : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb2d;
    private Transform targetTransform;
    private EnemyPushState currentState;

    private float timer;
    private Vector2 knockBackDirection;

    private void Awake()
    {
        currentState=EnemyPushState.Follow;
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        targetTransform = GameObject.Find("Player").transform;
    }

    void Update()
    {
        StateManager();
    }

    void StateManager()
    {
        switch (currentState)
        {
            case EnemyPushState.Follow:
                Move();
                break;
            case EnemyPushState.Knockback:
                KnockBack();
                break;
            case EnemyPushState.Stunned:
                Stunned();
                break;
        }
    }

    void Move()
    {
        if (targetTransform == null)
        {
            rb2d.velocity = Vector3.zero;
            return;
        }
        Vector2 direction = targetTransform.position - transform.position;
        direction = direction.normalized;
        rb2d.velocity = direction * speed;

    }

    void KnockBack()
    {
        
        rb2d.velocity = knockBackDirection* speed;
        timer += Time.deltaTime;
        if (timer >= 0.5f)
        {
            currentState = EnemyPushState.Stunned;
            timer = 0;
        }
    }

    void Stunned()
    {
        rb2d.velocity = Vector2.zero;
        timer += Time.deltaTime;
        if (timer >= 2)
        {
            currentState = EnemyPushState.Follow;
            timer = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            currentState=EnemyPushState.Knockback;
            knockBackDirection = transform.position - collision.gameObject.transform.position;
            knockBackDirection = knockBackDirection.normalized;
            timer = 0;
        }
    }
}
