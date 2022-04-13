using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string headerText;
    [SerializeField, Multiline()] private string contentText;
    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipSystem.Show(contentText, headerText);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipSystem.Hide();
    }

    public string GetContent()
    {
        return contentText;
    }

    public string GetHeader()
    {
        return headerText;
    }
}
