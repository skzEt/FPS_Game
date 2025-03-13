using System;
using UnityEngine;

public class KeyboardHelper : MonoBehaviour
{
    public static Action qInput;
    public static Action shootInput;
    public static Action reloadInput;
    public static Action spaceInput;
    
    [SerializeField] private KeyCode qKey;
    [SerializeField] private KeyCode reloadKey;
    [SerializeField] private KeyCode spaceKey;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) { shootInput?.Invoke(); }
        if (Input.GetKeyDown(reloadKey)) { reloadInput?.Invoke(); }
        if (Input.GetKeyDown(qKey)) { qInput?.Invoke(); }
        if (Input.GetKeyDown(spaceKey)) { spaceInput?.Invoke(); }
    }
}