using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Weapon/Gun")]
public class GunData : ScriptableObject
{
    [Header("Info")]
    public string name;
    [Header("Shooting")]
    public float maxDistance;
    public int damage;
    [Header("Reloading")]
    public int currentAmmo;
    public int magazineSize;
    public int bonusAmmo;
    public float ammoRate;
    public float reloadTime;
    public float knockback;
    [HideInInspector]
    public bool reloading = false;
    public bool musicPlaying = false;
}
