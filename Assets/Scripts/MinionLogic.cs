using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;
public class MinionLogic : MonoBehaviour
{
    public string tagToFollow;
    public float movementSpeed;
    private Transform _followTransform;
    private void Start()
    {
        _followTransform = GameObject.FindWithTag(tagToFollow).transform;
        if (_followTransform == null)
        {
            Debug.Log("No transform to follow found, check tag!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, _followTransform.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _followTransform.position,
                movementSpeed * Time.deltaTime);
        }
    }
}
