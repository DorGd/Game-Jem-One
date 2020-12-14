using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _moveH, _moveV;
    private PlayerAnimation _playerAnimation;

    
    public SpriteRenderer sr;

    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float dashForce = 50f;
    public Transform firePoint;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerAnimation = FindObjectOfType<PlayerAnimation>();
    }

	
    private void FixedUpdate()
    {
        _moveH = Input.GetAxis("Horizontal");
        _moveV = Input.GetAxis("Vertical");
        if (_moveH != 0 && _moveV != 0)
        {
            _moveV /= 2;
        }
        Vector2 direction = new Vector2(_moveH, _moveV);
        direction = Vector2.ClampMagnitude(direction,1);
        
        if (_moveH != 0 || _moveV != 0)
        {
            Vector3 pos = transform.position;
            firePoint.position = pos +  new Vector3(direction.x, direction.y, 0f).normalized * 0.5f;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            firePoint.eulerAngles = new Vector3(0f, 0f,angle );
        }
        
        _rb.velocity = direction * moveSpeed;
        sr.color = Color.Lerp (sr.color,Color.white,Time.deltaTime/1.5f);//slowly linear interpolate. takes about 3 seconds to return to white

        // Dash movement

        if (Input.GetKeyDown(KeyCode.B))
        {
            _rb.AddForce(_rb.velocity.normalized * dashForce,ForceMode2D.Impulse);
        }
        _playerAnimation.SetDirection(direction);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Minion"))
        {
            Debug.Log("crushed with minion");
            EventManagerScript.Instance.TriggerEvent(EventManagerScript.EVENT__CRUSHED_MINION);
         
            //other.transform.DOScale(0, 1);
            Destroy(other.gameObject);
        }
		sr.color = new Color(2,0,0);//set this object's red color to 200 percent

    }
}
