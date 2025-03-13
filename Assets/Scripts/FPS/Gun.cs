using System;
using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GunData gunData;
    [SerializeField] private AudioSource audioSource; 

    float timeSinceLastShot;
    private bool CanShoot() => !gunData.reloading && timeSinceLastShot > 1f / (gunData.ammoRate / 60f);
    private bool shoot;
    private void Start()
    {
        KeyboardHelper.shootInput += Shoot;
        KeyboardHelper.reloadInput += StartReloading;
        audioSource = GetComponent<AudioSource>();
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
                Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hitInfo, gunData.maxDistance))
                {
                    gunData.musicPlaying = true;
                    if (gunData.musicPlaying)
                    {
                        audioSource.Play();
                        gunData.musicPlaying = false;
                    }
                    shoot = true;
                    audioSource.Stop();
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
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawRay(ray.origin, ray.direction);
    }


    private void OnGunShot()
    {
        
    }
}
