using UnityEngine;

public class KeyboardHelper : MonoBehaviour
{
    public static bool isKeyShiftHolding()
    {
        if (Input.GetKey(KeyCode.LeftShift)) {return true;}
        return false;
    }

    public static bool isKeyQHolding()
    {
        if (Input.GetKey(KeyCode.Q)) {return true;}
        return false;
    }

    public static bool isKeyDownSpace()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {return true;}
        return false;
    }
}