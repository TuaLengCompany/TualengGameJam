using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] int poolAmount;
    [SerializeField] GameObject bulletPrefab;
    public List<GameObject> bulletPool;
    public static BulletPool instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        bulletPool = new List<GameObject>();
        instanceBullet();
    }

    void instanceBullet()
    {
        for(int i = 0; i < poolAmount; i++)
        {
            GameObject bulletTemp =  Instantiate(bulletPrefab,transform);
            bulletTemp.SetActive(false);
            bulletPool.Add(bulletTemp);
        }
    }

    public GameObject GetBulletFromPool()
    {
        for (int i = 0; i < poolAmount; i++)
        {
            if (!bulletPool[i].activeSelf)
            {
                return bulletPool[i];
            }
        }
        return null;
    }
}
