using UnityEngine;

[RequireComponent(typeof(MeatController))] 
class CuttingMeatController : MonoBehaviour, ICuttable
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
            var newObj = Instantiate(cuttingPrefab, position, rotation);
            newObj.GetComponent<MeatController>()?.ChangeState(GetComponent<MeatController>().GetStatusFood);


            position += Vector3.right * 0.15f;
        }
        gameObject.SetActive(false);
    }
}

