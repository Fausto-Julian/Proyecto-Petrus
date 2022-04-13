using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov1 : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody body;
    private float hInput;
    private float vInput;
    private Vector3 moveDirection;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
        body.freezeRotation = true;
        body.drag = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        SpeedControl();
    }

    private void FixedUpdate()
    {
        Movement();
        
    }
    private void Inputs()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");
    }
    private void Movement()
    {
        //La orientacion del jugador * S o W, y el perpendicular a la orientacion * A o D
        moveDirection = transform.forward * vInput + transform.right * hInput;

        body.AddForce(moveDirection.normalized * speed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 trueVel = new Vector3(body.velocity.x, 0f, body.velocity.z);

        //Si la velocidad del player es mayor a speed, se vuelve a calcular con la misma direccion pero capeada
        if(trueVel.magnitude > speed)
        {
            Vector3 capVel = trueVel.normalized * speed;
            body.velocity = new Vector3(capVel.x, body.velocity.y, capVel.z);
        }
    }
}
