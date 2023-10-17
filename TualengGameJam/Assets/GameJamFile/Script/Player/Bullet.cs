using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float ActiveTime;
    public int Damage;
    private void OnEnable()
    {
        Invoke(nameof(ShutSelf), ActiveTime);
    }

    private void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, targetPos, 2*Time.deltaTime);
        transform.Translate(Vector3.forward*20f*Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            ShutSelf();
            other.GetComponent<EnemyBase>().ReceiveDamage(Damage);
        }
    }
    void ShutSelf()
    {
        gameObject.SetActive(false);
    }
}
