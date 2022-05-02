using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour, ITooltipTrigger
{
    [SerializeField] private string infoText = "Press F for pickup";

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
        if (_objectPickup == null)
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out var hit, 2f))
            {
                if (hit.transform.gameObject.CompareTag("Object"))
                {
                    ToolTipShow(infoText, hit.transform.gameObject.name.ToUpper());

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        _objectPickup = hit.transform.gameObject;

                        _bodyObjectPickup = _objectPickup.GetComponent<Rigidbody>();

                        _bodyObjectPickup.useGravity = false;
                        _bodyObjectPickup.isKinematic = true;

                        var transform1 = transform;
                        _objectPickup.transform.position = transform1.position;
                        _objectPickup.transform.rotation = transform1.rotation;
                        _objectPickup.transform.SetParent(transform1);
                        ToolTipHide();
                    }
                }
                else
                {
                    ToolTipHide();
                }
            }
        }

        if (_objectPickup != null)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                _objectPickup.transform.SetParent(null);
                _bodyObjectPickup.useGravity = true;
                _bodyObjectPickup.isKinematic = false;

                _objectPickup = null;
                _bodyObjectPickup = null;
            }
        }
    }
}
