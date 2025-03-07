using System;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 6.0f;
    [SerializeField] private float levelDivision = 1.6f;
    private CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = moveHorizontal * transform.right + moveVertical * transform.forward;
        if (KeyboardHelper.isKeyShiftHolding())
        {
            controller.Move(movement * playerSpeed * Time.deltaTime / levelDivision);
        }
        else
        {
            controller.Move(movement * playerSpeed * Time.deltaTime);
        }
    }
}
