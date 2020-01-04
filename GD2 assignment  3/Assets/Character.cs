using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    List<BattleAction> all_actions;
    List<BattleAction> possible_actions;
    public List<BattleObject> objects_available;
    public bool friendly = false;

    Character target;
    public BattleObject selected_object;
    public BattleAction selected_action;

    public uint total_health, health, melee_attack, ranged_attack, melee_defense, ranged_defense, speed;
    bool defending;

    public void Init()
    {
        health = total_health;
        all_actions = new List<BattleAction>();
        possible_actions = new List<BattleAction>();
        objects_available = new List<BattleObject>();

        CreateAllActions();
        CreateAllObjects();
    }

    public void CreateAllActions()
    {
        Debug.Log("Create Actions");
        all_actions.Clear();

        all_actions.Add(new Attack());
        all_actions.Add(new Defend());
        //all_actions.Add(new UseObject());
    }
    public void CreateAllObjects()
    {

    }

    public void SetPossibleAction()
    {
        possible_actions.Clear();

        possible_actions.Add(new Attack());
        possible_actions.Add(new Defend());  
    }

    public void ChooseAction(List<Character> possible_targets)
    {
        SetPossibleAction();
        selected_action = possible_actions[Random.Range(0, possible_actions.Count)];
        ChooseTarget(possible_targets);
        //ChooseObject();
    }

    public void ChooseTarget(List<Character> possible_targets)
    {
        target = null;
        if (friendly)
        {
            while (!target) {
                int random = Random.Range(0, possible_targets.Count);
                if (!possible_targets[random].friendly)
                    target = possible_targets[random];
            }
        }else
        {
            while (!target)
            {
                int random = Random.Range(0, possible_targets.Count);
                if (possible_targets[random].friendly)
                    target = possible_targets[random];
            }
        }
    }
    
    public void ChooseObject()
    {
        selected_object = objects_available[Random.Range(0, objects_available.Count)];
    }

    void FillActions() { }
    void FillPosibleActions() { }
    public void AddHealthPoints(uint amount) { health += amount; }
    public void RemoveHealthPoints(uint amount) { health -= amount; }
    public void SetDefense(bool def) { defending = def; }
    public void SetTarget(Character target) { this.target = target; }
    public Character GetTarget() { return target; }
}
