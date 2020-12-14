using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UILogic : MonoBehaviour
{
    // Start is called before the first frame update
    
    public TextMeshProUGUI winTXT;
    public TextMeshProUGUI scoreTXT;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (MyGameManager.Instance.win)
        {
            winTXT.text = "winner";
        }

        scoreTXT.text = MyGameManager.Instance.points.ToString();
    }
}
