using System;
using UnityEngine;

public class KnockbackGun : MonoBehaviour
{
    [Header("References")] 
    [SerializeField] private Camera camera;
    [SerializeField] private GunData gunData;

    private void Awake()
    {
        camera = GetComponent<Camera>();
    }

    private void Start()
    {
        KeyboardHelper.shootInput += Knockback;
    }

    public void Knockback()
    {
        camera.transform.Rotate(camera.transform.rotation.x + gunData.knockback, 0, 0);
    }
}