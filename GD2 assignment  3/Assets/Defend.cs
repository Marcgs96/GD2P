using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : BattleAction
{
    public Defend()
    {
        priority = 1;
    }
    public override void Execute(Character active_character)
    {
        active_character.SetDefense(true);
    }
}
