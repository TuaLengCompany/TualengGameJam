using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int bulletDamage;
    private float bulletspeed;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * bulletspeed * Time.deltaTime);
    }

    public void setbulletSpaeed(float _speed)
    {
        bulletspeed = _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().ReceiveDamage(bulletDamage);
            Debug.Log("EnemyBulletHit");
            gameObject.SetActive(false);
        }
    }
}
