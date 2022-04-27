using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_TurnBack : Button
{
    public override void hit()
    {
        LevelManager.levelManager.TurnBack();
    }
}
