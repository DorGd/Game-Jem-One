using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UILogic : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject winIMG;
    public GameObject looseIMG;
    public TextMeshProUGUI scoreTXT;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (MyGameManager.Instance.win)
        {
            //winTXT.text = "winner";
			winIMG.active = true;
			looseIMG.active = false;
        }

        scoreTXT.text = MyGameManager.Instance.points.ToString();
    }
}
