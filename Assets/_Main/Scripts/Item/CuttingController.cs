using UnityEngine;

public class CuttingController : MonoBehaviour, ICuttable
{
    [SerializeField] private GameObject cuttingPrefab;
    [SerializeField] private int countInstance;

    public void Cutting()
    {
        var position = transform.position;
        var rotation = transform.rotation;
        for (var i = 0; i < countInstance; i++)
        {
            Instantiate(cuttingPrefab, position, rotation);
            position += Vector3.right * 2.5f;
        }
        gameObject.SetActive(false);
    }
}
