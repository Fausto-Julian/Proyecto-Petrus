using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour, ITooltipTrigger
{
    //[SerializeField] private string infoText = "Press F for pickup";
    [SerializeField] private LayerMask pickLayerMask;
    
    private GameObject _objectPickup = null;

    private Rigidbody _bodyObjectPickup;

    public void ToolTipHide()
    {
        TooltipSystem.Instance.Hide();
    }

    public void ToolTipShow(string content, string header = "")
    {
        TooltipSystem.Instance.Show(content, header);
    }

    private void Update()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out var hit2, 2f,
                pickLayerMask))
        {
            var food = hit2.transform.gameObject.GetComponent<ObjectFood>();
            if (food != null)
            {
                ToolTipShow(food.Description, food.Name);
            }

            var plate = hit2.transform.gameObject.GetComponent<PlateController>();
            if (plate != null)
            {
                plate.ActivateViewTask();
            }
        }
        else
        {
            ToolTipHide();
            TestHudOrderTask.Instance.DeactivateImageTask();
        }
        
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out var hit, 2f,
                pickLayerMask))
        {
            if (_objectPickup == null)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    _objectPickup = hit.transform.gameObject;

                    _bodyObjectPickup = _objectPickup.GetComponent<Rigidbody>();

                    _bodyObjectPickup.useGravity = false;
                    _bodyObjectPickup.isKinematic = true;

                    var transform1 = transform;
                    _objectPickup.transform.position = transform1.position;
                    _objectPickup.transform.SetParent(transform1);
                    ToolTipHide();
                    return;
                }
            }
        }
        if (_objectPickup != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _objectPickup.transform.SetParent(null);
                
                var food = _objectPickup.GetComponent<ObjectFood>();
                
                if (food != null)
                {
                    food.ShootRaycast();
                }

                _bodyObjectPickup.useGravity = true;
                _bodyObjectPickup.isKinematic = false;

                _objectPickup = null;
                _bodyObjectPickup = null;
            }
        }
    }
}
