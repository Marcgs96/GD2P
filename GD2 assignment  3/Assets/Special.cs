using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special : BattleAction
{
    public Special()
    {
        priority = 3;
    }
    public override void Execute(Character active_character)
    {
        if(active_character.weapon.level >= active_character.charge_level)
            active_character.charge_level++;
    }
}
