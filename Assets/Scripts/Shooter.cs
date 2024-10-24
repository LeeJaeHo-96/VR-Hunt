using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform muzzlePoint;

    [SerializeField] GameObject laserPointer;
    [SerializeField] LineRenderer laser;

    [SerializeField] float bulletSpeed;
    [SerializeField] bool isReload;
    [SerializeField] float reloadingTime = 2;

    [SerializeField] AudioSource bangSound;
    [SerializeField] AudioSource noBangSound;

    public void Start()
    {
        isReload = true;
        laserPointer.SetActive(false);
    }

    public void Update()
    {
        LaserCheck();
    }
    public void Shoot()
    {
        if (isReload == true)
        {
            GameObject bullet = Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation);
            Rigidbody rigid = bullet.GetComponent<Rigidbody>();
            rigid.velocity = bullet.transform.forward * bulletSpeed;

            isReload = false;
        }
        if (isReload == false)
        {
            Coroutine reloadCo = StartCoroutine(ReloadCo());
        }
    }

    public void Bang()
    {
        if (isReload)
        ShootSound(bangSound);
    }

    public void NoBang()
    {
        if (!isReload)
            ShootSound(noBangSound);
    }

    public void LaserCheck()
    {
        if (isReload)
            LaserOn();

        if (!isReload)
            LaserOff();
        
        
    }
    
    public void LaserOn()
    {
        laser.enabled = true;
    }

    public void LaserOff()
    {
        laser.enabled = false;
    }

    public void LaserPointerOn()
    {
        laserPointer.SetActive(true);
    }

    public void LaserPointerOff()
    {
        laserPointer.SetActive(false);
    }
    

    IEnumerator ReloadCo()
    {
        yield return new WaitForSeconds(reloadingTime);
        isReload = true;
        StopAllCoroutines();
    }

    public void ShootSound(AudioSource sound)
    {
        sound.Play();
    }
}
