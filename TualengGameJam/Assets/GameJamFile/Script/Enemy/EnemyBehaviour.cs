using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName ="Enemy/New Enemy",fileName ="Enemy")]
[Serializable]
public class EnemyBehaviour : ScriptableObject
{
    public EnemyBehaviourClass behav;
}

[Serializable]
public class EnemyBehaviourClass
{
    public EnemyType enemyType;
    public EnemyAttackType enemyAttackType;
    public int EnemyHealth;
    public float EnemyAttackRang;
    public float EnemyDetectRang;
    public float EnemyAttackSpeed;
    public EnemySkill enemySkill;
    public bool isUnDaed;
}
public enum EnemyType { Scout, Gagoy,NormalMelee,NormalRang, }
public enum EnemyAttackType { melee,Rang }
public enum EnemySkillType { }
