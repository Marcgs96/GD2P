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
        active_character.GenerateEnergy(true);
        active_character.GetTarget().GenerateEnergy(false);

        int attack = active_character.weapon.melee ? active_character.melee_attack : active_character.ranged_attack;
        int defense = active_character.weapon.melee ? active_character.GetTarget().melee_defense : active_character.GetTarget().ranged_defense;

        float total_power = ((2 * active_character.level / 5) + 2) * (active_character.weapon.power * attack) / defense;
        total_power /= 50;
        total_power += 2;

        total_power = total_power * Random.Range(0.85f, 1.0f);
        total_power *= 5;

        if (active_character.charge_level > 1)
        {
            Debug.Log("CHARGED ATTACK FOR " + total_power);
            total_power *= active_character.charge_level;
            active_character.ResetEnergy();
            active_character.charge_level = 1;
        }

        if (active_character.GetTarget().defending)
        total_power = total_power * 0.5f;


        Debug.Log(active_character.name+" DEALS " + (int)total_power + " DAMAGE");

        active_character.GetTarget().RemoveHealthPoints((int)total_power);
    }

}
