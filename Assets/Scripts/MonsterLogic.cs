using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DitzeGames.Effects;
using DG.Tweening;


public class MonsterLogic : MonoBehaviour
{
    private int power = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "minion")
        {
            power += 1;
            CameraEffects.ShakeOnce();
            other.transform.DOScale(0, 1);
            Destroy(other.gameObject,2f);
            //transform.DOScale(0.5f, 1); // can be a nice tranformation of merging with minions

        }
    }
}
