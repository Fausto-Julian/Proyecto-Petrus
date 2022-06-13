using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITooltipTrigger
{
    public void ToolTipShow(string content, string header = "");
    public void ToolTipHide();

}
