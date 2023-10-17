using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHunt : IState
{
    EnemyBase enemy;

    public EnemyHunt(EnemyBase _enemy)
    {
        this.enemy = _enemy;
    }

    public void Enter()
    {
        Debug.Log(enemy.stateBase);
    }

    public void Exit()
    {

    }

    public void FixedTick()
    {
        enemy.CheckPlayerRang();
        enemy.navMeshAgent.destination = enemy.player.transform.position;
    }

    public void Tick()
    {
    }
}