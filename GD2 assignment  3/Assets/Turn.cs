using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Turn : MonoBehaviour
{
    List<Character> characters;

    public Turn(List<Character> characters) { this.characters = characters; }
    public void OrderCharacters() { characters.OrderByDescending(x => x.speed); }
    public void DoTurn()
    {
        for(int i = 0; i < characters.Count; i++)
        {
            characters[i].ChooseAction(characters);
        }

        for (int i = 0; i < characters.Count; i++)
        {
            characters[i].selected_action.Execute(characters[i]);
        }
    }
}
