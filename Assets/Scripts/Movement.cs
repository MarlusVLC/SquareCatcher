using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private float speed;

    private Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
    }

    void Update()
    {
        _rb.velocity = new Vector3(0, -speed,0);
    }
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.ToLower().Contains("canceler"))
        {
            speed = 0;
            // _rb.gravityScale = 1;
            transform.SetParent(other.transform);
            gameObject.tag = "canceler";
        }    }
}
