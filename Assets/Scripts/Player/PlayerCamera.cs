using System;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerData playerData;
    private Camera playerCamera;
    private Action Q_Pressed;
    
    private float zoom;
    private float zoomMultiplier;
    
    private float velocity = 0.0f;
    private float rotationX = 0.0f;
    
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerCamera = GetComponent<Camera>();
        zoom = playerCamera.fieldOfView;
    }

    private void Start()
    {
        KeyboardHelper.qInput += Q_Pressed;
    }

    void Update()
    {
        Q_Pressed = Input.GetKeyDown(KeyCode.Q) ? ScrollCamera : returnScrollCamera;
        RotateCamera();
    }
    
    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        
        transform.parent.Rotate(Vector3.up * mouseX * playerData.sensitivity);
        
        rotationX -= mouseY * playerData.sensitivity;
        rotationX = Mathf.Clamp(rotationX, -playerData.maxAngle, playerData.maxAngle);
        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }

    void ScrollCamera()
    {
            zoomMultiplier = 0.8f;
            zoom -= zoomMultiplier;
            zoom = Mathf.Clamp(zoom, 20f, 60f);
            playerCamera.fieldOfView = Mathf.SmoothDamp(playerCamera.fieldOfView, zoom, ref velocity, playerData.smoothing);
    }
    void returnScrollCamera()
    {
        zoomMultiplier = 2f;
        zoom += zoomMultiplier;
        zoom = Mathf.Clamp(zoom, 60f, 60f);
        playerCamera.fieldOfView = Mathf.SmoothDamp(playerCamera.fieldOfView, zoom, ref velocity, playerData.smoothing);
    }
}
