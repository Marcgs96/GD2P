using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulation : MonoBehaviour
{
    public int num_battles = 100;
    public int battles_completed = 0;
    Battle battle;
    public List<Character> characters;
    public bool auto;
    public int victories, loses;

    public bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        battle = new Battle(auto, characters);
    }

    // Update is called once per frame
    void Update()
    {
        if(!finished)
        {
            if (battle.UpdateBattle())
            {
                if (battle.IsVictory())
                    victories++;
                else loses++;


                battle.ResetBattle();
                battles_completed++;
            }
        }


        if (battles_completed == num_battles)
            finished = true;
    }
}
