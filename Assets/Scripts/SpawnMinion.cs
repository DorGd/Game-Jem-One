using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMinion : MonoBehaviour
{
    [SerializeField] private GameObject minionToSpawn;
    public void Spawn()
    {
        Instantiate(minionToSpawn, transform.position, transform.rotation);
        Debug.Log(transform.position.ToString());
    }
    
    void OnDrawGizmos()
    {
        // Draws the Light bulb icon at position of the object.
        Gizmos.DrawIcon(transform.position, "SpawnGizmo", true);
    }
}
