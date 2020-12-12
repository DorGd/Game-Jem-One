using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMinion : MonoBehaviour
{
    [SerializeField] private GameObject minionToSpawn;
    public void Spawn()
    {
        Instantiate(minionToSpawn, transform.position, transform.rotation);
    }
}
