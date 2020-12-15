using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    public event Action onBattleTrigger;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<AudioSource>().Play();
            onBattleTrigger?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
