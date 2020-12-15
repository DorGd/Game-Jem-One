using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Laser : MonoBehaviour
{
    [SerializeField] private float defDistRay = 15f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private int fov_left = 25;
    [SerializeField] private int fov_right = 155;
    private LineRenderer _lineRenderer;
    private Transform _transform;
    public Transform player;
    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _transform = GetComponent<Transform>();
    }
    
    public IEnumerator LaserScan()
    {
        _lineRenderer.positionCount = 2;
        float distance = 0f;
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        int rightOffset = 0;
        Debug.Log("ANGLE = " + angle);
        if (angle < 0)
        {
            angle += 360f;
        }
        if (fov_left > fov_right)
        {
            if (angle < fov_right)
            {
                angle += 360;
            }
            rightOffset = 360;
        }
        if (angle > fov_left && angle  < fov_right + rightOffset)
        {    
            while (distance < defDistRay)
            {
                gameObject.GetComponent<AudioSource>().Play();
                ShootLaser(direction, distance);
                distance += Time.deltaTime * speed;
                yield return null;
            }
            gameObject.GetComponent<AudioSource>().Stop();
            _lineRenderer.positionCount = 0;
        }
    }
    
    void ShootLaser(Vector3 direction, float distance)
    {
        direction = direction.normalized;
        Debug.DrawRay(_transform.position, direction * distance, Color.blue);
        LayerMask mask = LayerMask.GetMask("Player");
        RaycastHit2D _hit = Physics2D.Raycast(_transform.position, direction, distance , mask);
        if (_hit)
        { 
            DrawRay2D(_transform.position, _hit.point);
        }
        else
        {
            DrawRay2D(_transform.position,_transform.position + (direction * distance));
        }
    }

    void DrawRay2D(Vector2 startPos, Vector2 endPos)
    {
        _lineRenderer.SetPosition(0, startPos);
        _lineRenderer.SetPosition(1, endPos);
    }
}
