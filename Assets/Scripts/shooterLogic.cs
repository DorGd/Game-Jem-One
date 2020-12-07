using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooterLogic : MonoBehaviour
{
    public Animator angieAnim;
    public SpriteRenderer mBullet;
    private Vector3 mOriginalPosition;
    private float mBulletMoveTime = 0;



    // Start is called before the first frame update
    void Start()
    {
        mBullet.enabled = false;
        mOriginalPosition = mBullet.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) & !mBullet.enabled)
        {
            // Flower shoot start
            Debug.Log("space pressed");

            angieAnim.Play("Attack");
            
            mBullet.enabled = true;
            mBulletMoveTime = 1;
            mBullet.transform.SetParent(null, true);
            
            //Vector2 playerDirection = transform.paren
        }

        if (mBulletMoveTime > 0)
        {
            mBulletMoveTime -= Time.deltaTime; 

            mBullet.transform.Translate(transform.right * 0.02f);

            if (mBulletMoveTime <= 0)
            {
                mBullet.enabled = false;

                // Return the flower to the tank top 
                //mBullet.transform.SetParent(mTankTop.transform, true);

                //mFlower.transform.eulerAngles = mTankTop.transform.eulerAngles;

                // Return the flower to the original place
                mBullet.transform.localPosition = mOriginalPosition;
            }
        }
    }
}
