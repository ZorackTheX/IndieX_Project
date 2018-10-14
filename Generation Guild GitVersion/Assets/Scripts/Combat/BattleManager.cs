using UnityEngine;
using System.Collections.Generic;


public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;

    public List<GameObject> characters = new List<GameObject>();

    void Awake()
    {
        
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void OnEnable()
    {
        GetCharacters();
        NextTurn();
    }


    private void GetCharacters()
    {
        Hero[] heroChars = FindObjectsOfType<Hero>();
        Enemy[] enemyChars = FindObjectsOfType<Enemy>();

        foreach(var hero in heroChars)
        {
            characters.Add(hero.gameObject);
            hero.character.battleIndex = characters.IndexOf(hero.gameObject);
            //Debug.Log("Index: " + characters.IndexOf(hero.gameObject));
        }
        foreach(var enemy in enemyChars)
        {
            characters.Add(enemy.gameObject);
            enemy.character.battleIndex = characters.IndexOf(enemy.gameObject);
            //Debug.Log("Index: " + characters.IndexOf(enemy.gameObject));
        }
    }
    public void NextTurn()
    {
        int caracterIndex = 0;
        float lastSpeed = 0.0f;
        bool IsNooneAvailable = true;

        foreach(var character in characters)
        {
            Hero hero = character.GetComponent<Hero>();
            Enemy enemy = character.GetComponent<Enemy>();
            
            if(hero != null)
            {
                if(hero.character.state == Character.StateMachine.WAIT)
                {
                    if(hero.character.statusEffects.CheckStatus(StatusEffects.StatusType.Stun, 0))
                    {
                        hero.character.state = Character.StateMachine.END;
                    }
                    else if (lastSpeed <= hero.character.stats.speed)
                    {
                        caracterIndex = characters.IndexOf(character);
                        lastSpeed = hero.character.stats.speed;
                        IsNooneAvailable = false;
                    }
                }
            }
            if(enemy != null)
            {
                if (enemy.character.state == Character.StateMachine.WAIT)
                {
                    if(enemy.character.statusEffects.CheckStatus(StatusEffects.StatusType.Stun,0))
                    {
                        enemy.character.state = Character.StateMachine.END;
                    }
                    else if (lastSpeed <= enemy.character.stats.speed)
                    {
                        caracterIndex = characters.IndexOf(character);
                        lastSpeed = enemy.character.stats.speed;
                        IsNooneAvailable = false;
                    }
                }
            }
        }
        if(!IsNooneAvailable)
        {
            StartTurn(caracterIndex);
        }
        else
        {
            ResetStateMachines();
        }
        
    }
    void StartTurn(int index)
    {
        Hero hero = characters[index].GetComponent<Hero>();
        Enemy enemy = characters[index].GetComponent<Enemy>();

        if(hero != null)
        {
            hero.character.state = Character.StateMachine.ACTION;
        }
        if(enemy != null)
        {
            enemy.character.state = Character.StateMachine.ACTION;
        }
    }
    void EndTurn(int turnIndex)
    {
        Hero hero = characters[turnIndex].GetComponent<Hero>();
        Enemy enemy = characters[turnIndex].GetComponent<Enemy>();

        if (hero != null)
        {
            hero.character.state = Character.StateMachine.END;
        }
        if (enemy != null)
        {
            enemy.character.state = Character.StateMachine.END;
        }
        NextTurn();
    }
    void ResetStateMachines()
    {
        foreach(var character in characters)
        {
            Hero hero = character.GetComponent<Hero>();
            Enemy enemy = character.GetComponent<Enemy>();

            if(hero != null)
            {
                if(hero.character.state != Character.StateMachine.DEAD)
                {
                    hero.character.state = Character.StateMachine.WAIT;
                }
            }
            if(enemy != null)
            {
                if(enemy.character.state != Character.StateMachine.DEAD)
                {
                    enemy.character.state = Character.StateMachine.WAIT;
                }
            }
        }
        NextTurn();
    }
    public void CheckBattleOver()
    {
        int numberOfHeros = 0 , numberofHerosDead = 0;
        int numberOfEnemys = 0, numberOfEnemysDead = 0;

        foreach(var character in BattleManager.instance.characters)
        {
            Hero hero = character.GetComponent<Hero>();
            Enemy enemy = character.GetComponent<Enemy>();

            if(hero != null)
            {
                numberOfHeros ++; 

                if(hero.character.state == Character.StateMachine.DEAD)
                {
                    numberofHerosDead++;
                }
            }
            if(enemy != null)
            {
                numberOfEnemys++;

                if(enemy.character.state == Character.StateMachine.DEAD)
                {
                    numberOfEnemysDead++;
                }
            }
        }
    }
}
