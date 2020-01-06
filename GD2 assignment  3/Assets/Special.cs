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

    }
}


public class JetSpecial : Special
{
    public JetSpecial()
    {
        priority = 3;
    }
    public override void Execute(Character active_character)
    {
        if (active_character.weapon.level >= active_character.charge_level)
            active_character.charge_level++;

        Debug.Log("JET CHARGE LEVEL: " + active_character.charge_level);
    }
}

public class MiraSpecial : Special
{
    public MiraSpecial()
    {
        priority = 3;
    }
    public override void Execute(Character active_character)
    {
        active_character.GenerateEnergy(true);
        active_character.GetTarget().GenerateEnergy(false);

        int attack = active_character.ranged_attack;
        int defense = active_character.GetTarget().ranged_defense;

        float total_power = ((2 * active_character.level / 5) + 2) * (active_character.weapon.power * attack) / defense;
        total_power /= 50;
        total_power += 2;

        total_power = total_power * Random.Range(0.85f, 1.0f);
        total_power *= 5;

        total_power *= active_character.weapon.level + 1;
        active_character.ResetEnergy();

        if (active_character.GetTarget().defending)
            total_power = total_power * 0.5f;


        Debug.Log("MIRA SPECIAL ATTACK FOR: " + (int)total_power);

        active_character.GetTarget().RemoveHealthPoints((int)total_power);
    }
}

public class JohnSpecial : Special
{
    public JohnSpecial()
    {
        priority = 3;
    }
    public override void Execute(Character active_character)
    {
        int heal_power = 20 + (50 * (active_character.weapon.level - 1));

        Debug.Log("JOHN HEALS FOR " + heal_power);

        active_character.GetTarget().AddHealthPoints(heal_power);

        active_character.ResetEnergy();
    }
}
