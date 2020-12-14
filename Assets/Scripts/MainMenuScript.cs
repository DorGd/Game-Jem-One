using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene(1);
        MyGameManager.Instance.points = 0;
        MyGameManager.Instance.lives = 3;
    }

    public void quitGame()
    {
        Debug.Log("quit pressed");
        Application.Quit();
    }
}
