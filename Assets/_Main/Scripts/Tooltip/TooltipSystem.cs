using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    [SerializeField] private Tooltip tooltip;
    
    public static TooltipSystem Instance { get; private set; }

    private void Awake()
    {
        if (TooltipSystem.Instance == null)
        {
            TooltipSystem.Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Show(string content, string header = "")
    {
        tooltip.SetText(content, header);
        tooltip.gameObject.SetActive(true);
    }

    public void Hide()
    {
        try
        {
            tooltip.gameObject.SetActive(false);
        }
        catch
        {
            Debug.LogError("Herror en hide tooltip");
        }
    }
}
