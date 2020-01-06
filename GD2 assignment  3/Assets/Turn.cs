using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.Security.Cryptography;

public static class Randomlel
{
    public static void Shuffle<T>(this IList<T> list)
    {
        RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
        int n = list.Count;
        while (n > 1)
        {
            byte[] box = new byte[1];
            do provider.GetBytes(box);
            while (!(box[0] < n * (Byte.MaxValue / n)));
            int k = (box[0] % n);
            n--;
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}


public class Turn
{
    List<Character> characters;
    int current_character = 0;
    public bool finished = false;

    public Turn(List<Character> characters) {
        Debug.Log("new turn created");
        this.characters = characters;
        foreach (Character character in this.characters)
        {
            character.selected_action = null;
        }
    }
    public void OrderCharacters() {
        characters.OrderByDescending(x => x.speed);
    }
    public void DoTurn()
    {
        if(Simulation.instance.auto)
        {
            for (int i = 0; i < characters.Count; i++)
            {
                characters[i].ChooseAction(characters);
            }
        }
        else
        {
            if (current_character < characters.Count)
            {
                if (characters[current_character].dead)
                {
                    characters[current_character].ChooseAction(characters);
                    current_character++;
                }
                else
                {
                    if (!characters[current_character].friendly)
                    {
                        characters[current_character].ChooseAction(characters);
                        current_character++;
                    }
                    else
                    {
                        Simulation.instance.char_text.text = characters[current_character].name;
                    }
                }
            }


            foreach (Character character in characters)
            {
                if (character.selected_action == null)
                    return;
            }
        }



        characters.Shuffle();
        IEnumerable<Character> t2 = characters.OrderBy(x => x.selected_action.priority).ThenByDescending(x => x.speed);
        foreach(Character character in t2)
        {
            if (!character.dead)
            {
                character.selected_action.Execute(character);
                character.selected_action = null;
            }
        }

        finished = true;
    }

    public void SelectAction(int action)
    {
        if (current_character < characters.Count)
        {
            characters[current_character].SelectAction(action, characters);
            current_character++;
        }
    }
}
