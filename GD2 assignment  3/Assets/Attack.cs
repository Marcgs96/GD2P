using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : BattleAction
{
    public Attack()
    {
        priority = 3;
    }
    public override void Execute(Character active_character)
    {
        int attack = active_character.weapon.melee ? active_character.melee_attack : active_character.ranged_attack;
        int defense = active_character.weapon.melee ? active_character.GetTarget().melee_defense : active_character.GetTarget().ranged_defense;

        float total_power = ((2 * active_character.level / 5) + 2) * active_character.weapon.power * attack / defense;
        total_power /= 50;
        total_power += 2;

        total_power = total_power * Random.Range(0.85f, 1.0f);

        if (active_character.GetTarget().defending)
            total_power = total_power * 0.5f;

        Debug.Log("CALCULATED POWER IS " + (int)total_power);

        active_character.GetTarget().RemoveHealthPoints((int)total_power);
    }

}
