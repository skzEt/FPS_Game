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
    private bool shoot;
    private void Start()
    {
        PlayerShoot.shootInput += Shoot;
        PlayerShoot.reloadInput += StartReloading;
    }

    public void StartReloading()
    {
        if (!gunData.reloading && gunData.currentAmmo != gunData.magazineSize && gunData.bonusAmmo > 0 && shoot == false)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        gunData.reloading = true;
        yield return new WaitForSeconds(gunData.reloadTime);
        
        if (gunData.currentAmmo == 0 && gunData.bonusAmmo >= gunData.magazineSize)
        {
            gunData.bonusAmmo -= gunData.magazineSize;
            gunData.currentAmmo = gunData.magazineSize;
        }
        else if (gunData.bonusAmmo >= gunData.magazineSize && gunData.currentAmmo > 0)
        {
            int result = gunData.magazineSize - gunData.currentAmmo;
            gunData.bonusAmmo -= result;
            gunData.currentAmmo = gunData.magazineSize;
        }
        else if (gunData.bonusAmmo < gunData.magazineSize && gunData.currentAmmo > 0)
        {
            int neededAmmo = gunData.magazineSize - gunData.currentAmmo;
            if (gunData.bonusAmmo >= neededAmmo)
            {
                gunData.bonusAmmo -= neededAmmo;
                gunData.currentAmmo = gunData.magazineSize;
            }
            else
            {
                gunData.currentAmmo += gunData.bonusAmmo;
                gunData.bonusAmmo = 0;
            }
        }
        else if (gunData.bonusAmmo < gunData.magazineSize && gunData.currentAmmo == 0)
        {
            gunData.currentAmmo = gunData.bonusAmmo;
            gunData.bonusAmmo = 0;
        }
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
                    shoot = true;
                    IDamageble damageble = hitInfo.transform.GetComponent<IDamageble>();
                    damageble?.Damage(gunData.damage);
                }

                shoot = false;
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
