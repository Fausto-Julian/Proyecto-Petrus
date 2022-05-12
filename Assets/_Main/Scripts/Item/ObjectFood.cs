using System;
using UnityEngine;

public class ObjectFood : MonoBehaviour
{
    [SerializeField] public int ID;

    private LayerMask _playerLayerMask;

    private void Start()
    {
        _playerLayerMask = LayerMask.GetMask("Object");
    }

    public void ShootRaycast()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out var hit, 20f,
                _playerLayerMask))
        {
            var plateController = hit.transform.gameObject.GetComponent<PlateController>();
            if (plateController != null)
            {
                plateController.AddFood(gameObject);
            }
        }
    }
}