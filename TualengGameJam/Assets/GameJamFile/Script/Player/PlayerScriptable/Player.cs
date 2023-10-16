using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerScriptableObject")]
public class Player : ScriptableObject
{
    public int MaxHealth;
    public int MaxStamina;
    public int RequireMana;
    public float AttackSpeedDelay;
    public int AttackDamage;
    public PlayerType playerType;
}

public enum PlayerType
{
    Tank,
    Mage,
    Archer,
    Healer,
}
