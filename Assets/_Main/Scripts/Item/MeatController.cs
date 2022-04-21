using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatController : MonoBehaviour
{
    [SerializeField] private Food meatStats;

    private Mesh currentMesh;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        currentMesh = GetComponent<Mesh>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        currentMesh = meatStats.CurrentMesh;
        meshRenderer.materials = meatStats.CurrentMeshRenderer.materials;
    }

    public void ChangeStateMeat(StatusFood state)
    {
        meatStats.StatusFood = state;
    }
}
