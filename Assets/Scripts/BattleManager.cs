using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private BattleTrigger battleTrigger;
    [SerializeField] private Wave[] waveArray;
    private BattleState _state;
    
    private enum BattleState
    {
        Idle, MinionFight, BossFight
    }
    private void Awake()
    {
        battleTrigger.onBattleTrigger += StartBattle;
    }
    
    private void Update()
    {
        if (_state == BattleState.MinionFight)
        {
            foreach (var wave in waveArray)
            {
                wave.Update();
            }    
        }
    }

    void StartBattle()
    {
        battleTrigger.onBattleTrigger -= StartBattle;
        _state = BattleState.MinionFight;
        Debug.Log("Start Battle!");
    }
    [System.Serializable]
    private class Wave
    {
        [SerializeField] private float timer;
        [SerializeField] private SpawnMinion[] spawnerArray;
        
        public void Update()
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    SpawnMinions();
                }
            }
        }
        
        private void SpawnMinions()
        {
            foreach (var minion in spawnerArray)
            {
                minion.Spawn();
            }
        }
    }
}
