using System;
using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{
    private Camera playerCamera;

    private void Awake()
    {
        playerCamera = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }
}
