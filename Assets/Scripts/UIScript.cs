using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIScript : MonoBehaviour
{
    public void onExitClicked()
    {
        MyGameManager.Instance.onExitClicked();
    }

    public void onRetryClicked()
    {
        MyGameManager.Instance.onRetryClicked();
    }
}
