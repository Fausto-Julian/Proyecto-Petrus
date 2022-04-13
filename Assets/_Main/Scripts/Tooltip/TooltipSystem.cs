using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipSystem : MonoBehaviour
{
    private static TooltipSystem Instance;

    [SerializeField] private Tooltip tooltip;

    private void Awake()
    {
        Instance = this;
    }

    public static void Show(string content, string header = "")
    {
        Instance.tooltip.SetText(content, header);
        Instance.tooltip.gameObject.SetActive(true);
    }

    public static void Hide()
    {
        try
        {
            Instance.tooltip.gameObject.SetActive(false);
        }
        catch
        {
            Debug.LogError("Herror en hide tooltip");
        }
    }
}
