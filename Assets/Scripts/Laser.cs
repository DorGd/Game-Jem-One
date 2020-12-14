using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float defDistRay = 100f;
    private LineRenderer _lineRenderer;
    private Transform _transform;
    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        ShootLaser();
    }

    void ShootLaser()
    {
        if (Physics2D.Raycast(_transform.position, _transform.right))
        {
            RaycastHit2D _hit = Physics2D.Raycast(_transform.position, transform.right);
            DrawRay2D(_transform.position, _hit.point);
        }
        else
        {
            DrawRay2D(_transform.position, _transform.right * defDistRay);
        }
    }

    void DrawRay2D(Vector2 startPos, Vector2 endPos)
    {
        _lineRenderer.SetPosition(0, startPos);
        _lineRenderer.SetPosition(1, endPos);
    }
}
