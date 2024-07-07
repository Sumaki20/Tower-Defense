using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTurret : BaseTurret
{
    public GameObject buttletPrefab;
    public Transform[] muzzles;

    public float damage = 10f;
    public float fireRate = 2f;

    private int muzzleIndex = 0;
    private float fireTimer;

    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (fireTimer <= 0f)
        {
            if (target == null) return;
            
            Fire();
            fireTimer = 1f / fireRate;
        }
        else
        {
            fireTimer -= Time.deltaTime;
        }
    }

    public void Fire()
    {
        Debug.Log("Fire");
        GameObject bulletGo = Instantiate(buttletPrefab, muzzles[muzzleIndex].position, muzzles[muzzleIndex].rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();
        if(bullet != null)
        {
            bullet.SetUpBullet(target.transform, damage);
        }
        muzzleIndex++;
        if(muzzleIndex >= muzzles.Length)
        {
            muzzleIndex = 0;
        }
    }
}
