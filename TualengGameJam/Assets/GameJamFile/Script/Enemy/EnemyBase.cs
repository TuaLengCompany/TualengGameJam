using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : StateMachine
{
    public enum EnemyBaseState 
    {
        Hunt,
        Attack,
        Skill,
        Dead
    }
    public EnemyBaseState stateBase;

    public EnemyHunt enemyHunt { get; private set; }
    public EnemyAttack enemyAttack { get; private set; }
    public EnemySkill enemySkill { get; private set; }
    public EnemyDead enemyDead { get; private set; }


    [SerializeField] public EnemyBehaviour enemyBehaviour;
    public EnemyBehaviourClass myEnemyBehav;

    public NavMeshAgent navMeshAgent;
    public GameObject player;

    private void Awake()
    {
        copyEnemyBehaviour();

        player = GameObject.FindGameObjectWithTag("Player");

        enemyHunt = new EnemyHunt(this);
        enemyAttack = new EnemyAttack(this);
        enemySkill = new EnemySkill(this);
        enemyDead = new EnemyDead(this);

        stateBase = EnemyBaseState.Hunt;
        ChageStateEnum(stateBase);
    }

    void copyEnemyBehaviour()
    {
        myEnemyBehav = new EnemyBehaviourClass();
        myEnemyBehav.EnemyHealth = enemyBehaviour.behav.EnemyHealth;
        myEnemyBehav.EnemyAttackRang = enemyBehaviour.behav.EnemyAttackRang;
        myEnemyBehav.EnemyDetectRang = enemyBehaviour.behav.EnemyDetectRang;
        myEnemyBehav.EnemyAttackSpeed = enemyBehaviour.behav.EnemyAttackSpeed;
        myEnemyBehav.enemyType = enemyBehaviour.behav.enemyType;
        myEnemyBehav.enemyAttackType = enemyBehaviour.behav.enemyAttackType;
        myEnemyBehav.enemySkill = enemyBehaviour.behav.enemySkill;
        myEnemyBehav.isUnDaed = enemyBehaviour.behav.isUnDaed;
    }

    public void ChageStateEnum(EnemyBaseState _state)
    {
        stateBase = _state;
        switch (_state)
        {
            case EnemyBaseState.Hunt: ChangeState(enemyHunt);break;
            case EnemyBaseState.Attack: ChangeState(enemyAttack);break;
            case EnemyBaseState.Skill:  ChangeState(enemySkill);break;
            case EnemyBaseState.Dead:   ChangeState(enemyDead);break;
        }
    }
    public LayerMask isPlayer;
    public bool inAttackRang;
    public bool inDetectRang;
    public void CheckPlayerRang()
    {
        inAttackRang = Physics.CheckSphere(gameObject.transform.position, myEnemyBehav.EnemyAttackRang, isPlayer);
        inDetectRang = Physics.CheckSphere(gameObject.transform.position, myEnemyBehav.EnemyDetectRang, isPlayer);
        ChangeStateOnPlayerRang();
    }

    public void ChangeStateOnPlayerRang()
    {
        if (inDetectRang)
        {

            switch (myEnemyBehav.enemyType)
            {
                case EnemyType.Scout: transform.Translate(Vector3.back * 5 * Time.deltaTime);
                    break;
                case EnemyType.Gagoy: transform.Translate(Vector3.forward * 10 * Time.deltaTime);
                    break;
                default: break;
            }
        }
        if (inAttackRang)
        {
            ChageStateEnum(EnemyBaseState.Attack);
            return;
        }
        else
        {
            ChageStateEnum(EnemyBaseState.Hunt);
            return;
        }
    }

    private void Update()///Test
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            ReceiveDamage(50);
        }
    }

    public void Die()
    {
        EnemySpawner.Instance.EnemyDead(this.gameObject);
        Destroy(gameObject);
    }

    public void ReceiveDamage(int _Damage)
    {
        myEnemyBehav.EnemyHealth -= _Damage;

        if (myEnemyBehav.EnemyHealth <= 0)
            ChageStateEnum(EnemyBaseState.Dead);
    }

    private void OnDrawGizmos()
     {
        try
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(gameObject.transform.position, myEnemyBehav.EnemyAttackRang);
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(gameObject.transform.position, myEnemyBehav.EnemyDetectRang);
        }
        catch { }
    }
}
