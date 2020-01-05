using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAction
{
    public int priority = 0;
    public virtual void Execute(Character active_character) { }
}
