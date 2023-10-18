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
        enemy.GetComponent<Collider>().enabled = false;
        enemy.navMeshAgent.isStopped = true;
        enemy.navMeshAgent.speed = 0;
        enemy.isDead = true;
        if(enemy.animator != null)
            enemy.animator.SetBool("Dead", true);
        Tool.Delayfuntion(enemy.Die,5f);
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
