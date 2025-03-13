using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("References")] 
    [SerializeField] private PlayerData playerData;
    private CharacterController controller;
    
    private Vector3 startPosition;
    private float levelDivision = 1.6f;
    private float gravity = -9.81f;
    private Vector3 moveVelocity;

    private void Awake() { controller = GetComponent<CharacterController>(); }

    private void Start()
    {
        startPosition = transform.position;
        KeyboardHelper.spaceInput += Jump;
    }
    private void Update()
    {
        Move();
        Gravity();
        RespawnCharacter();
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 direction = (horizontal * transform.right) + (vertical * transform.forward);
        direction = Vector3.ClampMagnitude(direction, 1);
        
        float currentSpeed = Input.GetKeyDown(KeyCode.LeftShift) ? playerData.speedPlayer / levelDivision : playerData.speedPlayer;
        Vector3 moveDirection = direction * currentSpeed * Time.deltaTime;
        controller.Move(moveDirection);
    }
    void Jump()
    {
        if (controller.isGrounded)
        {
            moveVelocity.y = Mathf.Sqrt(playerData.jumpHeight * 2f * Mathf.Abs(gravity));
        }
    }

    void Gravity()
    {
        if (controller.isGrounded)
        {
            moveVelocity.y = -1;
        }
        else
        {
            moveVelocity.y += gravity * Time.deltaTime;
        }
        controller.Move(moveVelocity * Time.deltaTime);
        if (moveVelocity.y < -20)
        {
            moveVelocity.y = -20;
        }
    }

    void RespawnCharacter()
    {
        if (playerData.currentHealth <= 0)
        {
            playerData.currentHealth = playerData.maxHealth;
            transform.position = startPosition;
        }
    }
}