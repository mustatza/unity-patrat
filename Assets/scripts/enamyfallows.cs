using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enamyfallows : MonoBehaviour
{
    public float speed;

    private Transform target;
    public Rigidbody2D rb2D;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed *Time.deltaTime);  
        //rb2D.MovePosition(rb2D.position + Vector2.left * (Time.fixedDeltaTime * speed));
    }
}
