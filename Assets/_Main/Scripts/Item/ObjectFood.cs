using System;
using UnityEngine;

public class ObjectFood : MonoBehaviour
{
    [SerializeField] private ObjectId id;

    private LayerMask _plateLayerMask;

    public ObjectId Id => id;
    
    private void Start()
    {
        _plateLayerMask = LayerMask.GetMask("Plate");
    }

    public void ShootRaycast()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out var hit, 20f, _plateLayerMask))
        {
            var plateController = hit.transform.gameObject.GetComponent<PlateController>();
            
            if (plateController != null)
            {
                plateController.AddFood(gameObject);
            }
        }
    }

    public void ChangeId(ObjectId newId)
    {
        id = newId;
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector3.down, Color.red);
    }
}