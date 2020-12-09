using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    private int _lastDirection;
    public Transform firePoint;
    public string[] idleDirection =
    {
        "Player_Idle_N", "Player_Idle_NW", "Player_Idle_W", "Player_Idle_SW", "Player_Idle_S", "Player_Idle_SW",
        "Player_Idle_E", "Player_Idle_NE"
    };

    public string[] runDirection =
    {
        "Player_Run_N", "Player_Run_NW", "Player_Run_W", "Player_Run_SW", "Player_Run_S", "Player_Run_SE",
        "Player_Run_E", "Player_Run_NE"
    };
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void SetDirection(Vector2 direction)
    {
        string[] directionArray = null;
        if (direction.magnitude < 0.01f)
        {
            directionArray = idleDirection;
        }
        else
        {
            directionArray = runDirection;
            _lastDirection = DirectionToIndex(direction);
            float angle = _lastDirection * 45f;
            firePoint.eulerAngles = new Vector3(0f,0f, angle);
            firePoint.position = firePoint.parent.position + new Vector3(Mathf.Cos((angle + 90f )* Mathf.Deg2Rad), Mathf.Sin((angle + 90f) * Mathf.Deg2Rad), 0f) * 0.5f;
        }
        _anim.Play(directionArray[_lastDirection]);
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
