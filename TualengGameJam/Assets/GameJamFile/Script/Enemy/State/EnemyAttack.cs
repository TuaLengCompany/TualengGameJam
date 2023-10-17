using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : IState
{
    EnemyBase enemy;
    public EnemyAttack(EnemyBase _enemy)
    {
        this.enemy = _enemy;
    }

    bool attackable = true;
    public void Enter()
    {
        enemy.navMeshAgent.isStopped = true;
    }

    public void Exit()
    {
        enemy.navMeshAgent.isStopped = false;
    }

    public async void FixedTick()
    {
        enemy.CheckPlayerRang();
        if (attackable)
        {
            attackable = false;
            Attack();
            attackable = await Tool.Delaybool(false, enemy.myEnemyBehav.EnemyAttackSpeed);
        }
        enemy.transform.LookAt(enemy.player.transform);
    }

    public void Tick()
    {
        
    }

    private void Attack()
    {
        switch (enemy.myEnemyBehav.enemyAttackType)
        {
            case EnemyAttackType.Rang: RangAttack(); break;
            case EnemyAttackType.melee: MeleeAttack(); break;
        }
    }

    private void RangAttack()
    {
        GameObject bullet = Objectpooler.instance.SpawnFrompool("EnemyBullet", enemy.transform.position, enemy.transform.rotation);
        EnemyBullet enemyBullet = bullet.GetComponent<EnemyBullet>();
        Tool.SetActive(bullet, false, 5f);

        switch (enemy.myEnemyBehav.enemyType)
        {
            case EnemyType.Scout: enemyBullet.setbulletSpaeed(50); break;
            default: enemyBullet.setbulletSpaeed(10); break;
        }
    }

    private void MeleeAttack()
    {
        Collider[] player = Physics.OverlapSphere(enemy.transform.position,enemy.myEnemyBehav.EnemyAttackRang,enemy.isPlayer);
        foreach(var _player in player)
        {
            Debug.Log("PlayerTakeDamage");
            if(enemy.myEnemyBehav.enemyType == EnemyType.Gagoy)
            {
                enemy.myEnemyBehav.EnemyDetectRang = 0;
                enemy.navMeshAgent.speed = 0;

                Tool.Delayfuntion(() => { enemy.myEnemyBehav.EnemyDetectRang = enemy.enemyBehaviour.behav.EnemyDetectRang;
                    enemy.navMeshAgent.speed = 3.5f;
                },3f);
            }
        }
    }
}