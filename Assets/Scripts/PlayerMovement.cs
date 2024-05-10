using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private float speed;
    private Vector2 direction;
    private Camera cam;

    public Vector2 Direction {  get { return direction; } }
    
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        direction = Vector2.up;
    }

    private void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    void Update()
    {
        Move();
        Rotate();
    }

    void Rotate()
    {
        Vector2 direction = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        direction = direction.normalized;
        transform.up = direction;
        
    }

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if(horizontal != 0f || vertical != 0f)
        {
            direction = new Vector2(horizontal, vertical).normalized;
        }

        rb2d.velocity = new Vector2(horizontal, vertical).normalized * speed;
    }
}
