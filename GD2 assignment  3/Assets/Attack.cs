using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : BattleAction
{
    public override void Execute(Character active_character)
    {
        uint total_power = active_character.melee_attack - active_character.GetTarget().melee_defense;

        active_character.GetTarget().RemoveHealthPoints(total_power);
    }

}
