using UnityEngine;

public class CuttingController : MonoBehaviour, ICuttable
{
    [SerializeField] private GameObject cuttingPrefab;
    [SerializeField] private int countInstance;

    private void Start()
    {
        if (countInstance <= 0)
        {
            countInstance = 1;
        }
    }

    public void Cutting()
    {
        var position = transform.position;
        var rotation = transform.rotation;

        for (var i = 0; i < countInstance; i++)
        {
            Instantiate(cuttingPrefab, position, rotation);
            position += Vector3.right * 0.15f;
        }
        gameObject.SetActive(false);
    }
}
