using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkill : IState
{
    EnemyBase enemy;
    public EnemySkill(EnemyBase _enemy)
    {
        enemy= _enemy;
    }

    public void Enter()
    {
        
    }

    public void Exit()
    {
       
    }

    public void FixedTick()
    {
        
    }

    public void Tick()
    {
        enemy.CheckPlayerRang();
    }
}