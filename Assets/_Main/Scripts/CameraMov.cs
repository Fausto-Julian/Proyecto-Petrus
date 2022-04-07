using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour
{
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;

    [SerializeField] private Transform playerOrientation;

    private float xRotation;
    private float yRotation;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        //Inputs
        float mouseX = Input.GetAxisRaw("Mouse X") * sensX * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensY * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;

        //Limitamos el rango de vision
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotacion de camara y player
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        playerOrientation.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}
