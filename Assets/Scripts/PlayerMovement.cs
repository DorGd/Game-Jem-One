using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


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
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Minion"))
        {
            Debug.Log("crushed with minion");
            EventManagerScript.Instance.TriggerEvent(EventManagerScript.EVENT__CRUSHED_MINION);
            
            other.transform.DOScale(0, 1);
            Destroy(other.gameObject,2f);
        }
    }
}
