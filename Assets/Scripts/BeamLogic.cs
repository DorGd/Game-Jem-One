using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BeamLogic : MonoBehaviour
{
    public GameObject hitEffect;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "minion")
        {
            EventManagerScript.Instance.TriggerEvent(EventManagerScript.EVENT__SHOOT_MINION);
        
            other.transform.DOScale(0, 1);
        }
        Destroy(gameObject);

    }
}
