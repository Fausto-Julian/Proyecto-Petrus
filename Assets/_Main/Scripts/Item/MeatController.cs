using UnityEngine;

public enum StatusFood
{
    Raw,
    Cooked,
    Burned
}

public class MeatController : MonoBehaviour
{
    [SerializeField] private bool isCube;
    [SerializeField] private StatusFood statusFood;
    [SerializeField] private float timeCooking;
    [SerializeField] private GameObject meatRaw;
    [SerializeField] private GameObject meatCooked;
    [SerializeField] private GameObject meatBurned;
    [SerializeField]private ObjectFood objectFood;

    public StatusFood GetStatusFood => statusFood;

    
    private float _cookingTimer;

    private bool _isCooking;


    private void Start()
    {
        _cookingTimer = timeCooking / GameManager.Instance.GetProgressLevels().KitchenSpeedLevel;
        switch (statusFood)
        {
            case StatusFood.Raw:
                meatRaw.SetActive(true);
                meatCooked.SetActive(false);
                meatBurned.SetActive(false);
                if(isCube)
                {
                    objectFood.ChangeId(ObjectId.CubeMeatRaw);
                }
                else objectFood.ChangeId(ObjectId.MeatRaw);
                break;
            case StatusFood.Cooked:
                meatRaw.SetActive(false);
                meatCooked.SetActive(true);
                meatBurned.SetActive(false);
                if (isCube)
                {
                    objectFood.ChangeId(ObjectId.CubeMeatCooked);
                }
                else objectFood.ChangeId(ObjectId.MeatCooked);
                break;
            case StatusFood.Burned:
                meatRaw.SetActive(false);
                meatCooked.SetActive(false);
                meatBurned.SetActive(true);
                if (isCube)
                {
                    objectFood.ChangeId(ObjectId.CubeMeatBurned);
                }
                else objectFood.ChangeId(ObjectId.MeatBurned);
                break;
            default:
                meatRaw.SetActive(true);
                meatCooked.SetActive(false);
                meatBurned.SetActive(false);
                if (isCube)
                {
                    objectFood.ChangeId(ObjectId.CubeMeatRaw);
                }
                else objectFood.ChangeId(ObjectId.MeatRaw);
                break;
        }
    }

    private void Update()
    {

        if (_isCooking)
        {
            _cookingTimer -= Time.deltaTime;
            
            if (_cookingTimer < 0)
            {
                ChangeStateMeat();
                _cookingTimer = timeCooking / GameManager.Instance.GetProgressLevels().KitchenSpeedLevel;
            }
            //cockingParticle.Play();
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
                meatRaw.SetActive(false);
                meatCooked.SetActive(true);
                meatBurned.SetActive(false);
                if (isCube)
                {
                    objectFood.ChangeId(ObjectId.CubeMeatCooked);
                }
                else objectFood.ChangeId(ObjectId.MeatCooked);
                break;
            case StatusFood.Cooked:
                statusFood = StatusFood.Burned;
                meatRaw.SetActive(false);
                meatCooked.SetActive(false);
                meatBurned.SetActive(true);
                if (isCube)
                {
                    objectFood.ChangeId(ObjectId.CubeMeatBurned);
                }
                else objectFood.ChangeId(ObjectId.MeatBurned);
                break;
            case StatusFood.Burned:
                break;
            default:
                if (isCube)
                {
                    objectFood.ChangeId(ObjectId.CubeMeatRaw);
                }
                else objectFood.ChangeId(ObjectId.MeatRaw);
                statusFood = StatusFood.Raw;
                meatRaw.SetActive(true);
                meatCooked.SetActive(false);
                break;
        }
    }

    public void ChangeState(StatusFood newStatusFood)
    {
        statusFood = newStatusFood;

        switch (statusFood)
        {
            case StatusFood.Raw:
                meatRaw.SetActive(true);
                meatCooked.SetActive(false);
                meatBurned.SetActive(false);
                if (isCube)
                {
                    objectFood.ChangeId(ObjectId.CubeMeatRaw);
                }
                else objectFood.ChangeId(ObjectId.MeatRaw);
                break;
            case StatusFood.Cooked:
                meatRaw.SetActive(false);
                meatCooked.SetActive(true);
                meatBurned.SetActive(false);
                if (isCube)
                {
                    objectFood.ChangeId(ObjectId.CubeMeatCooked);
                }
                else objectFood.ChangeId(ObjectId.MeatCooked);
                break;
            case StatusFood.Burned:
                meatRaw.SetActive(false);
                meatCooked.SetActive(false);
                meatBurned.SetActive(true);
                if (isCube)
                {
                    objectFood.ChangeId(ObjectId.CubeMeatBurned);
                }
                else objectFood.ChangeId(ObjectId.MeatBurned);
                break;
            default:
                meatRaw.SetActive(true);
                meatCooked.SetActive(false);
                meatBurned.SetActive(false);
                if (isCube)
                {
                    objectFood.ChangeId(ObjectId.CubeMeatRaw);
                }
                else objectFood.ChangeId(ObjectId.MeatRaw);
                break;
        }
    }
}
