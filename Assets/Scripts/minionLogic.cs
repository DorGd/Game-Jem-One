using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class minionLogic : MonoBehaviour
{

    public Transform monsterTransform;
    public Tilemap map;
    public float movementSpeed;
    public Transform minionTransform;
    
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(minionTransform.position, monsterTransform.position) > 0.1f)
        {
            minionTransform.position = Vector3.MoveTowards(minionTransform.position, monsterTransform.position,
                movementSpeed * Time.deltaTime);
        }
    }
}
