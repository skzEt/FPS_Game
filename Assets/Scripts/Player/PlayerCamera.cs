using System;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float sensitivity = 4f;
    [SerializeField] private float maxAngle = 60f;
    private float rotationX = 0.0f;
    
    private float zoom;
    private float zoomMultiplier;
    private float velocity = 0.0f;
    private float smoothTime = 0.2f;
    
    private Camera playerCamera;
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerCamera = GetComponent<Camera>();
        zoom = playerCamera.fieldOfView;
    }

    void Update()
    {
        RotateCamera();
        ScrollCamera();
    }
    
    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        
        transform.parent.Rotate(Vector3.up * mouseX * sensitivity);
        
        rotationX -= mouseY * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -maxAngle, maxAngle);
        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }

    void ScrollCamera()
    {
        if (KeyboardHelper.isKeyQHolding())
        {
            zoomMultiplier = 0.8f;
            zoom -= zoomMultiplier;
            zoom = Mathf.Clamp(zoom, 20f, 60f);
            playerCamera.fieldOfView = Mathf.SmoothDamp(playerCamera.fieldOfView, zoom, ref velocity, smoothTime);
        }
        else
        {
            zoomMultiplier = 2f;
            zoom += zoomMultiplier;
            zoom = Mathf.Clamp(zoom, 60f, 60f);
            playerCamera.fieldOfView = Mathf.SmoothDamp(playerCamera.fieldOfView, zoom, ref velocity, smoothTime);
        }

    }
}
