using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    [SerializeField] private Transform minion;
    [SerializeField] private Transform monster;
    [SerializeField] private BattleTrigger battleTrigger;

    private void Awake()
    {
        current = this;
        battleTrigger.onBattleTrigger += StartBattle;
    }
    
    void StartBattle()
    {
        battleTrigger.onBattleTrigger -= StartBattle;
        Debug.Log("Start Battle!");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
