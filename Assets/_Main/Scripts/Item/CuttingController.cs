using UnityEngine;

public class CuttingController : MonoBehaviour, ICuttable
{
    [SerializeField] private GameObject cuttingPrefab;
    

    public void Cutting()
    {
        var position = transform.position;
        var rotation = transform.rotation;

        for (var i = 0; i < GameManager.Instance.GetProgressLevels().FortuneLevel; i++)
        {
            Instantiate(cuttingPrefab, position, rotation);
            position += Vector3.right * 0.15f;
        }
        gameObject.SetActive(false);
    }
}
