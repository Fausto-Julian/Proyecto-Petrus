using UnityEngine;

public class GriddleController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var meatController = other.gameObject.GetComponent<MeatController>();
        if (meatController != null)
        {
            meatController.OnCooking();
        }

        var breadController = other.gameObject.GetComponent<BreadController>();
        if (breadController != null)
        {
            breadController.OnCooking();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var meatController = other.gameObject.GetComponent<MeatController>();
        if (meatController != null)
        {
            meatController.OffCooking();
        }

        var breadController = other.gameObject.GetComponent<BreadController>();
        if (breadController != null)
        {
            breadController.OffCooking();
        }
    }
}