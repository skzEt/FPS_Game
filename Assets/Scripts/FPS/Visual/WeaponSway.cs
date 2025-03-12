using System;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    [Header("Sway Settings")]
    private float smooth = 10;
    private float multiplier = 4.5f;

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * multiplier;
        float mouseY = Input.GetAxisRaw("Mouse Y") * multiplier;
        
        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);
        Quaternion rotation = rotationX * rotationY;
        transform.localRotation = Quaternion.Slerp(transform.localRotation, rotation, smooth * Time.deltaTime);
    }
}
