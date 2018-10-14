using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    public Character character;
    public NewStats stats;
    public List<int> heroIndexes;

    // Start is called before the first frame update
    void Awake()
    {
       SetStartingValues();
    }

    void SetStartingValues()
    {
        character.stats.health = stats.health;
        character.stats.maxHealth = stats.maxHealth;
        character.stats.strenght = stats.strenght;
        character.stats.intelligence = stats.intelligence;
        character.stats.defense = stats.defense;
        character.stats.speed = stats.speed;
    }
    // Update is called once per frame
    void Update()
    {
        if(character.stats.health <=0)
        {
            character.state = Character.StateMachine.DEAD;
        }
        if(character.state == Character.StateMachine.ACTION)
        {
            CanvasScript.instance.CombatMenuObject.SetActive(true);
        }
        if(character.state == Character.StateMachine.DEAD)
        {
            bool IsCheckedBattleOver = false;

            if(!IsCheckedBattleOver)
            {
                BattleManager.instance.CheckBattleOver();
                IsCheckedBattleOver = true;
            }
        }
    }
     public void ITakeDamage(float amount)
    {
        character.stats.health -= amount;
    }

}
