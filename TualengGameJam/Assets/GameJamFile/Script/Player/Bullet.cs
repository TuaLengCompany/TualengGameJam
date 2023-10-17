using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float ActiveTime;
    public float Damage;
    private void OnEnable()
    {
        Invoke(nameof(ShutSelf), ActiveTime);
    }

    private void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, targetPos, 2*Time.deltaTime);
        transform.Translate(Vector3.forward*10f*Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            ShutSelf();
        }
    }
    void ShutSelf()
    {
        gameObject.SetActive(false);
    }
}
