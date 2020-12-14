using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DitzeGames.Effects;
using DG.Tweening;


public class MonsterLogic : MonoBehaviour
{
    private int power = 0;

    [SerializeField] private Transform player;
    [SerializeField] private Transform monsterShadowTransform;
    [SerializeField] private float moveInterval = 3f;
    [SerializeField] private BattleManager battleManager;


    private float scaleBy = 0f;
    public float scaleFactor;
    public bool bossFight;
	private Vector3 moveTo;

	private void Awake()
    {
        battleManager.onBossFightTrigger += StartMove;
    }

    void Update()
    {
		
		
    }
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Minion"))
        {
            power += 1;
            CameraEffects.ShakeOnce();
            other.transform.DOScale(0, 1);
            Destroy(other.gameObject,2f);
            transform.DOScale(transform.localScale.y + scaleFactor, 1f); 
        }
		else
		{
			if (gameObject.CompareTag("Boss"))
			{
        		transform.DOScale(transform.localScale.y - scaleFactor, 1f); 
            	EventManagerScript.Instance.TriggerEvent(EventManagerScript.EVENT__MONSTER_HITTED,transform.localScale.y);
				if( !other.gameObject.CompareTag("Player"))// shooted
				{
					Destroy(other.gameObject);
				}
			}
		}
    }

	void StartMove()
	{
		StartCoroutine(MonsterMove());
	}

	IEnumerator MonsterMove()
	{
		gameObject.tag = "Boss";
		while(true)
		{
			yield return new WaitForSeconds(moveInterval);
			moveTo = player.position;

			while(Vector3.Distance(monsterShadowTransform.position, moveTo) > 0.1f)
        	{
				monsterShadowTransform.position = Vector3.MoveTowards(monsterShadowTransform.position, moveTo,
            		    10 * Time.deltaTime);
        		yield return null;
			}
		
			transform.DOJump(moveTo, 3,1,1,false);
		}
	}
}
