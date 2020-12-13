using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DitzeGames.Effects;
using DG.Tweening;


public class MonsterLogic : MonoBehaviour
{
    private int power = 0;

    [SerializeField] private Transform player;

    private float scaleBy = 0f;
    public float scaleFactor;
    public bool bossFight;

    public void update()
    {
        //make jump and shadow (place of landing)
    }
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Minion"))
        {
            power += 1;
            CameraEffects.ShakeOnce();
            other.transform.DOScale(0, 1);
            Destroy(other.gameObject,2f);
            transform.DOScale(transform.localScale.y + scaleFactor, 1f); // can be a nice tranformation of merging with minions
        }
    }
}
