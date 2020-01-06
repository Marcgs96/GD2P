using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Simulation : MonoBehaviour
{
    public static Simulation instance;

    public int num_battles = 100;
    public int battles_completed = 0;
    Battle battle;
    public List<Character> characters;
    public bool auto;
    public int victories, loses;

    public bool finished = false;


    public Text char_text;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        battle = new Battle(characters);
    }

    // Update is called once per frame
    void Update()
    {
        if(!finished)
        {
            if (battle.UpdateBattle())
            {
                Debug.Log("Battle finished");
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


    public void SelectAction(int action)
    {
        battle.SelectAction(action);
    }
}
