using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MinionLogic : MonoBehaviour
{
    public string tagToFollow;
    public float movementSpeed;
    public string[] idleDirection =
    {
        "Minion_Idle_N", "Minion_Idle_NW", "Minion_Idle_W", "Minion_Idle_SW", "Minion_Idle_S", "Minion_Idle_SW",
        "Minion_Idle_E", "Minion_Idle_NE"
    };
    private Animator _anim;
    private int _lastDirection;
    private Transform _followTransform;
    
    private void Start()
    {
        _anim = GetComponent<Animator>();
        _followTransform = GameObject.FindWithTag(tagToFollow).transform;
        if (_followTransform == null)
        {
            Debug.Log("No transform to follow found, check tag!");
        }
        transform.DOShakePosition(1f, 0.25f, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, _followTransform.position) > 0.1f)
        {
            Vector3 minionPos = transform.position;
            Vector3 followPos = _followTransform.position;
            Vector3 directionXYZ = followPos - minionPos;
            Vector2 directionXY = new Vector2(directionXYZ.x, directionXYZ.y);
            transform.position = Vector3.MoveTowards(minionPos, followPos,
                movementSpeed * Time.deltaTime);
            SetDirection(directionXY);
        }
    }
    
    private void SetDirection(Vector2 direction)
    {
        int currDirection = DirectionToIndex(direction);
        if (_lastDirection != currDirection)
        {
            _lastDirection = currDirection;
            _anim.Play(idleDirection[_lastDirection]);
        }
    }

    private int DirectionToIndex(Vector2 direction)
    {
        Vector2 normDir = direction.normalized;
        float step = 360f / 8f;
        float offset = step / 2;
        float angle = Vector2.SignedAngle(Vector2.up, normDir);

        angle += offset;
        if (angle < 0)
        {
            angle += 360f;
        }
        float stepCount = angle / step;
        return Mathf.FloorToInt(stepCount);
    }
}
