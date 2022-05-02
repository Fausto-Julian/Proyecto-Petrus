using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipSystem : MonoBehaviour
{

    [SerializeField] private static Tooltip _tooltip;

    public static void Show(string content, string header = "")
    {
        _tooltip.SetText(content, header);
        _tooltip.gameObject.SetActive(true);
    }

    public static void Hide()
    {
        try
        {
            _tooltip.gameObject.SetActive(false);
        }
        catch
        {
            Debug.LogError("Herror en hide tooltip");
        }
    }
}
