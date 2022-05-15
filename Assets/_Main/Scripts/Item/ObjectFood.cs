using System;
using UnityEngine;

public class ObjectFood : MonoBehaviour
{
    [SerializeField] public int ID;

    private LayerMask _plateLayerMask;

    private void Start()
    {
        _plateLayerMask = LayerMask.GetMask("Plate");
    }

    public void ShootRaycast()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out var hit, 20f, _plateLayerMask))
        {
            var plateController = hit.transform.gameObject.GetComponent<PlateController>();
            Debug.Log(plateController);
            if (plateController != null)
            {
                plateController.AddFood(gameObject);
            }
        }
    }


    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector3.down, Color.red);
    }
}