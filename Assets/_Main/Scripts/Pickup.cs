using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour, ITooltipTrigger
{
    [SerializeField] private string infoText = "Press F for pickup";

    private GameObject objectPickup = null;

    private Rigidbody bodyObjectPickup;

    public void ToolTipHide()
    {
        TooltipSystem.Hide();
    }

    public void ToolTipShow(string content, string header = "")
    {
        TooltipSystem.Show(content, header);
    }

    private void Update()
    {
        if (objectPickup == null)
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out var hit, 30f))
            {
                if (hit.transform.gameObject.CompareTag("Object"))
                {
                    ToolTipShow(infoText, hit.transform.gameObject.name.ToUpper());

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        objectPickup = hit.transform.gameObject;

                        bodyObjectPickup = objectPickup.GetComponent<Rigidbody>();

                        bodyObjectPickup.useGravity = false;
                        bodyObjectPickup.isKinematic = true;

                        objectPickup.transform.position = transform.position;
                        objectPickup.transform.rotation = transform.rotation;
                        objectPickup.transform.SetParent(transform);
                        ToolTipHide();
                    }
                }
                else
                {
                    ToolTipHide();
                }
            }
            //if (Input.GetKeyDown(KeyCode.F)) 
            //{ 
            //    if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out var hit, 30f))
            //    {
                    
            //    }
            //}
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
