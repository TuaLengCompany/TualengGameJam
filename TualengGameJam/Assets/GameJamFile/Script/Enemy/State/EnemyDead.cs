using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDead : IState
{
    EnemyBase enemy;
    public EnemyDead(EnemyBase _enemy)
    {
        this.enemy = _enemy;
    }

    public void Enter()
    {
        enemy.navMeshAgent.isStopped = true;
        enemy.navMeshAgent.speed = 0;
        Tool.Delayfuntion(enemy.Die,3f);
    }

    public void Exit()
    {
        
    }

    public void FixedTick()
    {
        
    }

    public void Tick()
    {
        
    }
}
