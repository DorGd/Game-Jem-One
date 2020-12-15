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
    public int points = 0;
    public int lives = 3;

    private Text scoreTXT;
    private GameObject heart1;
    private GameObject heart2;
    private GameObject heart3;

    public bool win = false;
    private GameObject player;


    private void OnEnable()
    {
        GameObject go = GameObject.Find("scoreValue");
        if(go != null)
            scoreTXT = go.GetComponent<UnityEngine.UI.Text>();
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        heart1 = GameObject.Find("heart1") as GameObject;
        heart2 = GameObject.Find("heart2") as GameObject;
        heart3 = GameObject.Find("heart3") as GameObject;
        EventManagerScript.Instance.StartListening(EventManagerScript.EVENT__SHOOT_MINION, OnShootMinion);
        EventManagerScript.Instance.StartListening(EventManagerScript.EVENT__CRUSHED_MINION, OnCrushMinion);
        EventManagerScript.Instance.StartListening(EventManagerScript.EVENT__MONSTER_HITTED, OnMonsterHitted);
    }
    private void OnApplicationQuit()
    {
        EventManagerScript.Instance.StopListening(EventManagerScript.EVENT__SHOOT_MINION, OnShootMinion);
        EventManagerScript.Instance.StopListening(EventManagerScript.EVENT__CRUSHED_MINION, OnCrushMinion);
        EventManagerScript.Instance.StopListening(EventManagerScript.EVENT__MONSTER_HITTED, OnMonsterHitted);
    }

    private void OnShootMinion(object obj)
    {
        points += SHOOT_MINION_SCORE;
        if(scoreTXT == null)
            scoreTXT = GameObject.Find("scoreValue").GetComponent<UnityEngine.UI.Text>();
        scoreTXT.text = points.ToString();
    }
    private void OnCrushMinion(object obj)
    {
        if (lives <= 0)
        {
            player = GameObject.FindGameObjectsWithTag("Player")[0];
            player.GetComponent<AudioSource>().Stop();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            if (heart3 == null)
            {
                heart1 = GameObject.Find("heart1") as GameObject;
                heart2 = GameObject.Find("heart2") as GameObject;
                heart3 = GameObject.Find("heart3") as GameObject;
            }
            
            lives -= LIFE;
            if (lives == 2)
            {
                heart3.transform.DOScale(0, 1);
                heart3.SetActive(false);
            } else if (lives == 1)
            {
                heart2.transform.DOScale(0, 1);
                heart2.SetActive(false);
            }if (lives == 0)
            {
                heart1.transform.DOScale(0, 1);
                heart1.SetActive(false);
            }
        }
            
    }

    public int getPoints()
    {
        return points;
    }

    public void onExitClicked()
    {
        Debug.Log("shani : exit clicked");
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        player.GetComponent<AudioSource>().Stop();
        SceneManager.LoadScene(0);
    }

    public void onRetryClicked()
    {
        Debug.Log("shani : retry cicked");
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        player.GetComponent<AudioSource>().Stop();
        SceneManager.LoadScene(1);
    }

    public void OnMonsterHitted(object obj)
    {
        float scale = (float) obj;
        points++;
        if(scoreTXT == null)
            scoreTXT = GameObject.Find("scoreValue").GetComponent<UnityEngine.UI.Text>();
        scoreTXT.text = points.ToString();

        if (scale <= 0.05f)
        {
            win = true;
            player = GameObject.FindGameObjectsWithTag("Player")[0];
            player.GetComponent<AudioSource>().Stop();
            SceneManager.LoadScene(3);
        }

    }

	
}
