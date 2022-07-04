using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablaTransportadoraScript : MonoBehaviour
{
    [SerializeField] Transform storagePosition_One;
    [SerializeField] Transform storagePosition_Two;
    [SerializeField] Transform storagePosition_Three;

    private LayerMask tablaMask;
    private List<GameObject> _storedItems;

    private void Awake()
    {
        tablaMask = LayerMask.GetMask("Tabla");
    }

    private void Update()
    {
        if(_storedItems.Count > 0)
        {
            for (int i = 0; i < 2; i++)
            {
                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Object"))
        {
            
            
            other.gameObject.transform.SetParent(transform);
            var body = gameObject.gameObject.GetComponent<Rigidbody>();
            body.useGravity = false;
            body.isKinematic = true;

            _storedItems.Add(gameObject);
        }
    }

    public void AddItemToStorage(GameObject gameObject)
    {
        if (gameObject.CompareTag("Object"))
        {
            gameObject.transform.SetParent(transform);
            var body = gameObject.gameObject.GetComponent<Rigidbody>();
            body.useGravity = false;
            body.isKinematic = true;

            _storedItems.Add(gameObject);
        }
    }
}
