using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Controls")]
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private LayerMask whatIsGround;

    private float currentSpeed;
    private bool canJump;
    private Vector3 moveInput;

    [Header("Gravity")]
    [SerializeField] private float gravityModifier;

    [Header("Camera Controls")]
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private bool invertX;
    [SerializeField] private bool invertY;
    [SerializeField] private Transform cameraPoint;

    private CharacterController characterController;
    private Animator anim;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

        currentSpeed = walkSpeed;
    }

    private void Update()
    {
        // Alternate Speed Walk And Run

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            currentSpeed = runSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            currentSpeed = walkSpeed;
        }

        // Movement
        var yStorage = moveInput.y;

        Vector3 horizontalMove = transform.right * Input.GetAxis("Horizontal");
        Vector3 verticalMove = transform.forward * Input.GetAxis("Vertical");

        moveInput = horizontalMove + verticalMove;
        moveInput.Normalize();
        moveInput = moveInput * currentSpeed;

        anim.SetFloat("moveSpeed", moveInput.magnitude);

        moveInput.y = yStorage;

        // Gravedad
        moveInput.y += Physics.gravity.y * gravityModifier * Time.deltaTime;

        if (characterController.isGrounded)
        {
            moveInput.y = Physics.gravity.y * gravityModifier * Time.deltaTime;
        }

        // Jump
        canJump = Physics.OverlapSphere(groundCheckPoint.position, 2f, whatIsGround).Length > 0;

        if (Input.GetButtonDown("Jump") && canJump)
        {
            moveInput.y = jumpForce;
        }

        characterController.Move(moveInput * Time.deltaTime);

        // Camera Controller
        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

        if (invertX)
        {
            mouseInput.x = -mouseInput.x;
        }

        if (invertY)
        {
            mouseInput.y = -mouseInput.y;
        }

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);
        cameraPoint.rotation = Quaternion.Euler(cameraPoint.rotation.eulerAngles + new Vector3(-mouseInput.y, 0f));
    }
}
