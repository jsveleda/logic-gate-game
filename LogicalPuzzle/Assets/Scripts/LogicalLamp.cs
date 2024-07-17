using System.Collections;
using System.Collections.Generic;
using Operational;
using UnityEngine;

public class LogicalLamp : LogicalElement
{
    protected override void UpdateOutput()
    {
        base.UpdateOutput();

        if (output)
        {
            FindObjectOfType<GameController>().ShowCompletionPopup();
        }
    }
}
