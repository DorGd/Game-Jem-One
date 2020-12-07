using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _moveH, _moveV;

    [SerializeField] private float moveSpeed = 1f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        _moveH = Input.GetAxis("Horizontal") * moveSpeed;
        _moveV = Input.GetAxis("Vertical") * moveSpeed;
        _rb.velocity = new Vector2(_moveH, _moveV);
        
        Vector2 direction = new Vector2(_moveH, _moveV);
        FindObjectOfType<PlayerAnimation>().SetDirection(direction);
    }
}
