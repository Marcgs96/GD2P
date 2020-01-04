using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulation : MonoBehaviour
{
    public uint num_battles = 100;
    List<Battle> battles;
    public List<Character> characters;
    public bool auto;
    uint victories, loses;
    // Start is called before the first frame update
    void Start()
    {
        battles = new List<Battle>();
        for (int i = 0; i < num_battles; i++)
        {
            battles.Add(new Battle(auto, characters));
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Battle b in battles)
        {
            if (b.UpdateBattle())
            {
                if (b.IsVictory())
                    victories++;
                else loses++;

                battles.Remove(b);
            }
        }
    }
}
