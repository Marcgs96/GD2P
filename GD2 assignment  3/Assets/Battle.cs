using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle
{
    public List<Character> battle_characters;
    Turn current_turn = null;
    bool victory = true, finished;

    public Battle(List<Character> chars) {
        battle_characters = chars;

        foreach(Character charac in battle_characters)
        {
            charac.Init();
        }
    }
    public bool UpdateBattle() {
        if (!Simulation.instance.auto)
        {
            //UpdateCurrentTurn
            if(current_turn == null)
            {
                current_turn = new Turn(battle_characters);
                current_turn.OrderCharacters();
                current_turn.DoTurn();
            }
            else
            {
                current_turn.OrderCharacters();
                current_turn.DoTurn();
                if (current_turn.finished)
                    current_turn = null;
            }
        }
        else
        {
            current_turn = new Turn(battle_characters);
            current_turn.OrderCharacters();
            current_turn.DoTurn();
        }

        return IsFinished();
    }
    public void EndBattle() { }
    public bool IsFinished()
    {
        bool enemie_alive = false, allie_alive = false;

        foreach (Character c in battle_characters)
        {
            if(!c.dead)
            {
                if (c.friendly)
                    allie_alive = true;
                else
                    enemie_alive = true;
            }
        }

        if (!enemie_alive || !allie_alive)
        {
            finished = true;

            if (enemie_alive)
                victory = false;
            else victory = true;

            return true;
        }

        return false;
    }
    public bool IsVictory() {
        return victory;
    }

    public void ResetBattle()
    {
        foreach (Character charac in battle_characters)
        {
            charac.Init();
        }
        current_turn = null;
    }

    public void SelectAction(int action)
    {
        current_turn.SelectAction(action);
    }
}
