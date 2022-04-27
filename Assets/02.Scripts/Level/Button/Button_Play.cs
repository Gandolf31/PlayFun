using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Play : Button
{
    public override void hit() 
    {
        LevelManager.levelManager.Play_Turn();
    }
}
