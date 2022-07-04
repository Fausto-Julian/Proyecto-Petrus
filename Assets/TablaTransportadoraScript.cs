using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablaTransportadoraScript : MonoBehaviour
{
    //[SerializeField] Transform storagePosition_One;
    //[SerializeField] Transform storagePosition_Two;
    //[SerializeField] Transform storagePosition_Three;

    [SerializeField] private Transform[] storagePositions;

    private LayerMask tablaMask;
    private GameObject[] _storedItems = new GameObject[3];

    private void Awake()
    {
        tablaMask = LayerMask.GetMask("Tabla");
    }

    private void Start()
    {
        for (int i = 0; i < _storedItems.Length; i++)
        {
            _storedItems[i] = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Object"))
        {
            for (int i = 0; i < _storedItems.Length; i++)
            {
                if(_storedItems[i] == null)
                {
                    other.gameObject.transform.position = storagePositions[i].position;

                    other.gameObject.transform.SetParent(transform);
                    var body = gameObject.gameObject.GetComponent<Rigidbody>();
                    body.useGravity = false;
                    body.isKinematic = true;

                    _storedItems[i] = other.gameObject;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Object"))
        {
            for (int i = 0; i < _storedItems.Length; i++)
            {
                if (_storedItems[i] == other.gameObject)
                {
                    _storedItems[i] = null;
                }
            }
        }
    }
}
