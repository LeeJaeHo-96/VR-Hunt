using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform muzzlePoint;

    [SerializeField] float bulletSpeed;


    
    public void Shoot()
    {
        
            GameObject bullet = Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation);
            Rigidbody rigid = bullet.GetComponent<Rigidbody>();
            rigid.velocity = bullet.transform.forward * bulletSpeed;
        
    }
}
