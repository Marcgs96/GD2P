using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    public List<Character> battle_characters;
    Turn current_turn;
    bool auto = true, victory = true, finished;

    public Battle(bool auto, List<Character> chars) { this.auto = auto; battle_characters = chars; }

    public void StartBattle() {

    }
    public bool UpdateBattle() {
        if (!auto)
        {
            //UpdateCurrentTurn
        }else
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
            if(c.health > 0)
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
}
