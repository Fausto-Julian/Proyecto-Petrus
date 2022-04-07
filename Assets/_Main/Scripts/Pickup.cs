using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private GameObject objectPickup = null;

    private Rigidbody bodyObjectPickup;

    private void Update()
    {
        if (objectPickup == null)
        {
            if (Input.GetKeyDown(KeyCode.F)) 
            { 
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out var hit, 25f))
                {
                    Debug.Log(hit.transform.gameObject.name);
                    objectPickup = hit.transform.gameObject;

                    bodyObjectPickup = objectPickup.GetComponent<Rigidbody>();

                    bodyObjectPickup.useGravity = false;
                    bodyObjectPickup.isKinematic = true;

                    objectPickup.transform.position = transform.position;
                    objectPickup.transform.SetParent(transform);
                }
            }
        }

        if (objectPickup != null)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                objectPickup.transform.SetParent(null);
                bodyObjectPickup.useGravity = true;
                bodyObjectPickup.isKinematic = false;

                objectPickup = null;
                bodyObjectPickup = null;
            }
        }
    }
}
