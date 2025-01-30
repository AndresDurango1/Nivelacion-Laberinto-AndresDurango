using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 20f;
    public float runSpeed = 40f;
    public float jumpPower = 2f;
    public float gravity = 10f;

    public float lookSpeed = 2f;  // Este ya no será necesario para rotación de la cámara.
    public float lookXLimit = 45f;

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;
    public bool canJump = true;
    private bool isMenuOpen = false;

    CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        characterController.stepOffset = 0.3f;
    }

    void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
    }
    void HandleMovement()
    {
        #region Movement
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSPeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSPeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSPeedX) + (right * curSPeedY);

        if (moveDirection.sqrMagnitude > 1)
        {
            moveDirection = moveDirection.normalized * (isRunning ? runSpeed : walkSpeed);
        }

        moveDirection.y = movementDirectionY;
        #endregion

        #region Jumping
        if (!isMenuOpen && canJump && Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);
        #endregion
    }
    void HandleRotation()
    {
        if (!canMove) return;

        float rotationInput = Input.GetAxis("Horizontal");
        transform.Rotate(0, rotationInput * lookSpeed, 0);
    }
}
