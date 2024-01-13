using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour
{
    public PlayerSO playerData;
    private float walkingSpeed;
    private float runningSpeed;
    private float jumpSpeed;
    private float gravity;
    public Camera playerCamera;
    private float lookSpeed;
    private float lookXLimit;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    public float staminaTimer;
    public float staminaRefillTimer;
    public float staminaRefillTimerTimer;
    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        walkingSpeed = playerData.walkingSpeed;
        runningSpeed = playerData.runningSpeed;
        jumpSpeed = playerData.jumpSpeed;
        gravity = playerData.gravity;
        lookSpeed = playerData.lookSpeed;
        lookXLimit = playerData.lookXLimit;
    }

    void Update()
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift) && playerData.currentStamina > 0;
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        // decreases stamina when running
        if (isRunning)
        {
            //Debug.Log(isRunning);
            staminaTimer += Time.deltaTime;
            if (staminaTimer >= 1)
            {
                playerData.currentStamina = playerData.currentStamina - 10;
                staminaTimer = 0;
            }
            staminaRefillTimer = 0;
        }


        if (!isRunning)
        {
            staminaTimer = 0;
            staminaRefillTimer += Time.deltaTime;
            if (staminaRefillTimer >= 3)
            {
                staminaRefillTimerTimer += Time.deltaTime;
                if (staminaRefillTimerTimer >= 1)
                {
                    playerData.currentStamina += 10;
                    staminaRefillTimerTimer = 0;
                }
            }
        }
        playerData.currentStamina = Mathf.Clamp(playerData.currentStamina, 0, playerData.maxStamina);


        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}