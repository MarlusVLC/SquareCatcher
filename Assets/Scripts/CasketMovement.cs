using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasketMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float _moveLimit;

    
    private Rigidbody2D _rb;
    private GameObject[] _catchedSquares;
    private float _moveRate;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
        _moveLimit = 6.5f;
        _moveRate = 1;
    }

    void FixedUpdate()
    {
        if (transform.position.x < _moveLimit)
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                _rb.velocity = new Vector2(speed, 0);
            }
        }
        if (transform.position.x > -_moveLimit)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _rb.velocity = new Vector2(-speed, 0);
            }
        }
        
        // _moveRate = speed * Input.GetAxisRaw("Horizontal");
        // _rb.velocity = new Vector2(_moveRate, 0);

        // if (!(transform.position.x < _moveLimit || transform.position.x > -_moveLimit))
        // {
        //     _rb.velocity = Vector2.zero;
        // }
        
        if (transform.position.x > 11)
        {
            transform.position = new Vector3(-10.5f, 0, 0);
        }
        
        if (transform.position.x < -11)
        {
            transform.position = new Vector3(10.5f, 0, 0);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.ToLower().Contains("square"))
        {
            GameManager.GetInstance._catchedObjects.Add(other.gameObject);
        }
    }
}
