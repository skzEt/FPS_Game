using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class playerMove : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5.2f;
    [SerializeField] private float levelDivision = 1.6f;
    
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 4f;
    Vector3 moveVelocity;
    
    private CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (KeyboardHelper.isKeyShiftHolding()) {ShiftPlayer();} else {MovePlayer();}
        Gravity();
        PlayerJump();
    }

    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = moveHorizontal * transform.right + moveVertical * transform.forward;
        controller.Move(movement * playerSpeed * Time.deltaTime);
    }

    void ShiftPlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = moveHorizontal * transform.right + moveVertical * transform.forward;
        controller.Move(movement * playerSpeed * Time.deltaTime / levelDivision);
    }

    void PlayerJump()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        if (controller.isGrounded && KeyboardHelper.isKeyDownSpace())
        {
            moveVelocity = transform.forward * moveVertical;
            moveVelocity.y = jumpHeight;
        }
    }
    void Gravity()
    {
        moveVelocity.y += gravity * Time.deltaTime;
        controller.Move(moveVelocity * Time.deltaTime);
    }
}
