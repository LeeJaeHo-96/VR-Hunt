using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform muzzlePoint;

    [SerializeField] GameObject laser;

    [SerializeField] float bulletSpeed;
    [SerializeField] bool isReload;
    [SerializeField] float reloadingTime = 2;

    [SerializeField] AudioSource bangSound;
    [SerializeField] AudioSource noBangSound;

    public void Start()
    {
        isReload = true;
        laser.SetActive(false);
    }

    private void Update()
    {
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

    public void LaserOn()
    {
        while (true)
        {
            if (isReload)
                laser.SetActive(true);

            if (!isReload)
                laser.SetActive(false);
        }
    }

    public void LaserOff()
    {
        laser.SetActive(false);
    }
    

   // public void Reload()
   // {
   //     if (!isReload)
   //     {
   //         Coroutine reloadCo = StartCoroutine(ReloadCo());
   //     }
   // }

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
