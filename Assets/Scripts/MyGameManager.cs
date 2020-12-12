using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;



public class MyGameManager : Singleton<MyGameManager>
{
    private const int SHOOT_MINION_SCORE = 1;
    private const int LIFE = 1;
    private int points = 0;
    private int lives = 3;

    
    /** UI elements **/
    public Text scoreTXT;
    public GameObject[] hearts;


    private void OnEnable()
    {
        EventManagerScript.Instance.StartListening(EventManagerScript.EVENT__SHOOT_MINION, OnShootMinion);
        EventManagerScript.Instance.StartListening(EventManagerScript.EVENT__CRUSHED_MINION, OnCrushMinion);
    }

    private void OnDisable()
    {
        EventManagerScript.Instance.StopListening(EventManagerScript.EVENT__SHOOT_MINION, OnShootMinion);
        EventManagerScript.Instance.StopListening(EventManagerScript.EVENT__CRUSHED_MINION, OnCrushMinion);
    }

    private void OnShootMinion(object obj)
    {
        points += SHOOT_MINION_SCORE;
        scoreTXT.text = points.ToString();
    }
    private void OnCrushMinion(object obj)
    {
        if (lives <= 0)
        {
            lives = 3;
            points = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            lives -= LIFE;
            hearts[lives].transform.DOScale(0, 1);
            hearts[lives].SetActive(false);
        }
            
    }

    public int getPoints()
    {
        return points;
    }

    public void onExitClicked()
    {
        SceneManager.LoadScene(0);
    }

    public void onRetryClicked()
    {
        SceneManager.LoadScene(1);
    }
}
