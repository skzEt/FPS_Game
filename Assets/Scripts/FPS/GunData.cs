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
    public float ammoRate;
    public float reloadTime;
    [HideInInspector]
    public bool reloading;
}
