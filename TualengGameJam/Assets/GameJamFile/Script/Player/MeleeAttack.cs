using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public int Damage;

    private void Awake()
    {
        Damage = transform.parent.GetComponent<CharacterProperties>().player.AttackDamage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Move Enemy BackWard
            Debug.Log("Player Melee");
            other.GetComponent<EnemyBase>().ReceiveDamage(Damage);
        }
    }

}
