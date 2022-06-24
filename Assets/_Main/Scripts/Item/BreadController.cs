using UnityEngine;

public class BreadController : MonoBehaviour
{
    [SerializeField] private StatusFood statusFood;
    [SerializeField] private float timeCooking;
    [SerializeField] private GameObject breadRaw;
    [SerializeField] private GameObject breadToasted;
    [SerializeField] private GameObject breadBurned;

    [Header("Sounds")]
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip audioClip;

    private bool _audioPlay;
    private float _cookingTimer;

    private bool _isCooking;

    private ObjectFood _objectFood;

    private void Start()
    {
        _objectFood = GetComponent<ObjectFood>();
        _audioPlay = true;
        _cookingTimer = timeCooking;
        switch (statusFood)
        {
            case StatusFood.Raw:
                breadRaw.SetActive(true);
                breadToasted.SetActive(false);
                breadBurned.SetActive(false);
                _objectFood.ChangeId(ObjectId.BreadRaw);
                break;
            case StatusFood.Cooked:
                breadRaw.SetActive(false);
                breadToasted.SetActive(true);
                breadBurned.SetActive(false);
                _objectFood.ChangeId(ObjectId.BreadToasted);
                break;
            case StatusFood.Burned:
                breadRaw.SetActive(false);
                breadToasted.SetActive(false);
                breadBurned.SetActive(true);
                _objectFood.ChangeId(ObjectId.BreadBurned);
                break;
            default:
                breadRaw.SetActive(true);
                breadToasted.SetActive(false);
                breadBurned.SetActive(false);
                _objectFood.ChangeId(ObjectId.BreadRaw);
                break;
        }
    }

    private void Update()
    {
        if (_isCooking)
        {
            _cookingTimer -= Time.deltaTime;
            if(_audioPlay && statusFood != StatusFood.Burned)
            {
                source.PlayOneShot(audioClip);
                _audioPlay = false;
            }
            if (_cookingTimer < 0)
            {
                ChangeStateMeat();
                _audioPlay = true;
                Debug.Log("Entro a true");
                _cookingTimer = timeCooking;
            }
        }
    }

    public void OnCooking()
    {
        _isCooking = true;
    }

    public void OffCooking()
    {
        _isCooking = false;
        _cookingTimer = timeCooking;
    }

    private void ChangeStateMeat()
    {
        switch (statusFood)
        {
            case StatusFood.Raw:
                statusFood = StatusFood.Cooked;
                breadRaw.SetActive(false);
                breadToasted.SetActive(true);
                breadBurned.SetActive(false);
                _objectFood.ChangeId(ObjectId.BreadToasted);
                break;
            case StatusFood.Cooked:
                statusFood = StatusFood.Burned;
                breadRaw.SetActive(false);
                breadToasted.SetActive(false);
                breadBurned.SetActive(true);
                _objectFood.ChangeId(ObjectId.BreadBurned);
                _audioPlay = false;
                break;
            case StatusFood.Burned:
                break;
            default:
                breadRaw.SetActive(true);
                breadToasted.SetActive(false);
                breadBurned.SetActive(false);
                _objectFood.ChangeId(ObjectId.BreadRaw);
                break;
        }
    }
}
