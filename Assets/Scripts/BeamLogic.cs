using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BeamLogic : MonoBehaviour
{
    public GameObject hitEffect;

    public void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Minion"))
        {
            EventManagerScript.Instance.TriggerEvent(EventManagerScript.EVENT__SHOOT_MINION,null);
            other.transform.DOScale(0, 1);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Monster"))
        {
            Destroy(gameObject);
        }
    }
}
