using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingController : MonoBehaviour, ICuttable
{
    [SerializeField] private GameObject cuttingPrefab;

    public void Cutting()
    {
        var position = transform.position;
        var rotation = transform.rotation;
        Instantiate(cuttingPrefab, position, rotation);
        gameObject.SetActive(false);
    }
}
