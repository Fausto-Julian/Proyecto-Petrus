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

    private float _currentSpeed;
    private bool _canJump;
    private Vector3 _moveInput;

    [Header("Gravity")]
    [SerializeField] private float gravityModifier;

    [Header("Camera Controls")]
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private bool invertX;
    [SerializeField] private bool invertY;
    [SerializeField] private Transform cameraPoint;

    private CharacterController _characterController;
    private Animator _anim;
    private LayerMask _InteractLayer;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _anim = GetComponent<Animator>();

        _currentSpeed = walkSpeed;
        
        _InteractLayer = LayerMask.GetMask("Interactable");
    }

    private void Update()
    {
        // Alternate Speed Walk And Run
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _currentSpeed = runSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _currentSpeed = walkSpeed;
        }

        // Movement
        var yStorage = _moveInput.y;

        var horizontalMove = transform.right * Input.GetAxis("Horizontal");
        var verticalMove = transform.forward * Input.GetAxis("Vertical");

        _moveInput = horizontalMove + verticalMove;
        _moveInput.Normalize();
        _moveInput = _moveInput * _currentSpeed;

        _anim.SetFloat("moveSpeed", _moveInput.magnitude);

        _moveInput.y = yStorage;

        // Gravity
        _moveInput.y += Physics.gravity.y * gravityModifier * Time.deltaTime;

        if (_characterController.isGrounded)
        {
            _moveInput.y = Physics.gravity.y * gravityModifier * Time.deltaTime;
        }

        // Jump
        _canJump = Physics.OverlapSphere(groundCheckPoint.position, 2f, whatIsGround).Length > 0;

        if (Input.GetButtonDown("Jump") && _canJump)
        {
            _moveInput.y = jumpForce;
        }

        _characterController.Move(_moveInput * Time.deltaTime);

        // Camera Controller
        var mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

        if (invertX)
        {
            mouseInput.x = -mouseInput.x;
        }

        if (invertY)
        {
            mouseInput.y = -mouseInput.y;
        }

        var rotation = transform.rotation;
        rotation = Quaternion.Euler(rotation.eulerAngles.x, rotation.eulerAngles.y + mouseInput.x, rotation.eulerAngles.z);
        
        transform.rotation = rotation;
        cameraPoint.rotation = Quaternion.Euler(cameraPoint.rotation.eulerAngles + new Vector3(-mouseInput.y, 0f));

        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out var hit, 2f, LayerMask.GetMask("Interactable")))
            {
                var interactable = hit.transform.gameObject.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interact();
                }
            }
        }
    }
}
