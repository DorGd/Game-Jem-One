using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;
public class MinionLogic : MonoBehaviour
{

    public Transform monsterTransform;
    public float movementSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, monsterTransform.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, monsterTransform.position,
                movementSpeed * Time.deltaTime);
        }
    }
}
