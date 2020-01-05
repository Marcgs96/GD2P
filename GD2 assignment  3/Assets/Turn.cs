using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

        IEnumerable<Character> t2 = characters.OrderBy(x => x.selected_action.priority).ThenByDescending(x => x.speed);
        foreach(Character character in t2)
        {
            if (!character.dead)
                character.selected_action.Execute(character);
        }
    }
}
