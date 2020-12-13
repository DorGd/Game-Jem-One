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
                if (wave.Update()) // return true only if last wave 
                {
                    _state = BattleState.BossFight;
                } 
            }    
        } 
        else if (_state == BattleState.BossFight)
        {
            //waking up the monster and make her jump
            
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

        public bool lastWave;
        
        public bool Update()
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    SpawnMinions();
                    if (lastWave)
                    {
                        return true;
                    }
                }
            }
            return false;
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
