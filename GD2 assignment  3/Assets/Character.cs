using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    List<BattleAction> all_actions;
    List<BattleAction> possible_actions;
    public List<BattleObject> objects_available;
    public bool friendly = false;
    public int level;

    Character target;
    public BattleObject selected_object;
    public BattleAction selected_action;
    public Slider hp_bar;

    [Serializable]
    public struct Weapon
    {
        public bool melee;
        public int power;
        public int level;
    }
    public Weapon weapon;

    public int base_health, base_melee_attack, base_ranged_attack, base_melee_defense, base_ranged_defense, base_speed;
    public int health, melee_attack, ranged_attack, melee_defense, ranged_defense, speed, max_health;
    public int health_scaling, speed_scaling, ranged_scaling, melee_scaling, melee_defense_scaling, ranged_defense_scaling;
    public bool defending = false, dead = false;

    public void Init()
    {
        health = base_health + (health_scaling * (level - 1));
        max_health = health;
        speed = base_speed + (speed_scaling * (level - 1));
        melee_attack = base_melee_attack + (melee_scaling * (level - 1));
        ranged_attack = base_ranged_attack + (ranged_scaling * (level - 1));
        melee_defense = base_melee_defense + (melee_defense_scaling * (level - 1));
        ranged_defense = base_ranged_defense + (ranged_defense_scaling * (level - 1));

        dead = false;
        all_actions = new List<BattleAction>();
        possible_actions = new List<BattleAction>();
        objects_available = new List<BattleObject>();

        hp_bar.value = (float)health / (float)max_health;

        CreateAllActions();
        CreateAllObjects();
    }

    public void CreateAllActions()
    {
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
        defending = false;
        possible_actions.Clear();

        possible_actions.Add(new Attack());
        possible_actions.Add(new Defend());  
    }

    public void ChooseAction(List<Character> possible_targets)
    {
        SetPossibleAction();
        selected_action = possible_actions[UnityEngine.Random.Range(0, possible_actions.Count)];
        ChooseTarget(possible_targets);
        //ChooseObject();
    }

    public void ChooseTarget(List<Character> possible_targets)
    {

        target = null;
        if (friendly)
        {
            while (!target) {
                int random = UnityEngine.Random.Range(0, possible_targets.Count);
                if (!possible_targets[random].friendly)
                    target = possible_targets[random];
            }
        }else
        {
            while (!target)
            {
                int random = UnityEngine.Random.Range(0, possible_targets.Count);
                if (possible_targets[random].friendly)
                    target = possible_targets[random];
            }
        }
    }
    
    public void ChooseObject()
    {
        selected_object = objects_available[UnityEngine.Random.Range(0, objects_available.Count)];
    }

    void FillActions() { }
    void FillPosibleActions() { }
    public void AddHealthPoints(int amount) { health += amount; }
    public void RemoveHealthPoints(int amount) {
        health -= amount;
        if (health <= 0)
        {
            health = 0;
            dead = true;
        }

        hp_bar.value = (float)health / (float)max_health;
    }
    public void SetDefense(bool def) {
        defending = def;
    }
    public void SetTarget(Character target) {
        this.target = target;
    }
    public Character GetTarget() {
        return target;
    }

    public void SelectAction(int action, List<Character> possible_targets)
    {
        selected_action = all_actions[action];
        ChooseTarget(possible_targets);
    }
}
