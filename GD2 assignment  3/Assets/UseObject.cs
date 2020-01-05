using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseObject : BattleAction
{
    public UseObject()
    {
        priority = 2;
    }
    public override void Execute(Character active_character)
    {
        active_character.selected_object.Use(active_character);
    }

}
