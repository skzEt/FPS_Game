using System;
using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GunData gunData;
    [SerializeField] private Transform muzzle;
    
    float timeSinceLastShot;
    
    private bool CanShoot() => !gunData.reloading && timeSinceLastShot > 1f / (gunData.ammoRate / 60f);
    private void Start()
    {
        PlayerShoot.shootInput += Shoot;
        PlayerShoot.reloadInput += StartReloading;
    }

    public void StartReloading()
    {
        if (!gunData.reloading)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        gunData.reloading = true;
        yield return new WaitForSeconds(gunData.reloadTime);

        gunData.currentAmmo = gunData.magazineSize;
        gunData.reloading = false;
    }

    public void Shoot()
    {
        if (gunData.currentAmmo > 0)
        {
            if (CanShoot())
            {
                if (Physics.Raycast(muzzle.position, transform.forward, out RaycastHit hitInfo, gunData.maxDistance))
                {
                    IDamageble damageble = hitInfo.transform.GetComponent<IDamageble>();
                    damageble?.Damage(gunData.damage);
                }

                gunData.currentAmmo--;
                timeSinceLastShot = 0;
                OnGunShot();
            }
        }
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        
        Debug.DrawRay(muzzle.position, transform.forward);
    }


    private void OnGunShot()
    {
    }
}
