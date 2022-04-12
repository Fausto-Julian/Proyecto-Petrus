using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private bool isCursorLook;
    [SerializeField] private Transform targetFollow;

    private void Awake()
    {
        if (isCursorLook)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void LateUpdate()
    {
        transform.position = targetFollow.position;
        transform.rotation = targetFollow.rotation;
    }
}
