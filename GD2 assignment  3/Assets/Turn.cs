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


public class Turn : MonoBehaviour
{
    List<Character> characters;

    public Turn(List<Character> characters) {
        this.characters = characters;
    }
    public void OrderCharacters() {
        characters.OrderByDescending(x => x.speed);
    }
    public void DoTurn()
    {

        for (int i = 0; i < characters.Count; i++)
        {
            if(!characters[i].dead)
             characters[i].ChooseAction(characters);
        }

        characters.Shuffle();
        IEnumerable<Character> t2 = characters.OrderBy(x => x.selected_action.priority).ThenByDescending(x => x.speed);
        foreach(Character character in t2)
        {
            if (!character.dead)
                character.selected_action.Execute(character);
        }
    }
}
