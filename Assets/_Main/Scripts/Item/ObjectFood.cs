using System.Collections;
using UnityEngine;

public class ObjectFood : MonoBehaviour
{
    [SerializeField] private ObjectId id;
    [SerializeField] private string name;
    [SerializeField, Multiline()] private string description;

    private LayerMask _plateLayerMask;

    public ObjectId Id => id;
    public string Name => name;
    public string Description => description;
    
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
                StartCoroutine(nameof(ConvertToStatic));
            }
        }
    }

    private IEnumerator ConvertToStatic()
    {
        yield return new WaitForSeconds(1.5f);
        var body = GetComponent<Rigidbody>();
        body.velocity = Vector3.zero;
        body.isKinematic = true;
        body.useGravity = false;
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