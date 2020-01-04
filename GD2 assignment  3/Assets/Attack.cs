using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : BattleAction
{
    public override void Execute(Character active_character)
    {
        uint total_power = 0;

        active_character.GetTarget().RemoveHealthPoints(total_power);
    }

}
