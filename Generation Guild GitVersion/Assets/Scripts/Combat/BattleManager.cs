using UnityEngine;
using System.Collections.Generic;


public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;

    public List<GameObject> inCombatCharacters = new List<GameObject>();

    [SerializeField]
    private Enemy[] enemies;

    public bool InCombat = false;
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

    private void Update()
    {
        if(InCombat) CheckBattleOver();
    }

    private void GetCharacters()
    {
        Hero[] heroChars = FindObjectsOfType<Hero>();
        Enemy[] enemyChars = FindObjectsOfType<Enemy>();

        foreach(var hero in heroChars)
        {
            if(hero.character.state != Character.StateMachine.DEAD)
            {
                inCombatCharacters.Add(hero.gameObject);
                hero.character.battleIndex = inCombatCharacters.IndexOf(hero.gameObject);
                //Debug.Log("Index: " + characters.IndexOf(hero.gameObject));
            }

        }
        foreach(var enemy in enemyChars)
        {
            if(enemy.character.state != Character.StateMachine.DEAD)
            {
                inCombatCharacters.Add(enemy.gameObject);
                enemy.character.battleIndex = inCombatCharacters.IndexOf(enemy.gameObject);
                //Debug.Log("Index: " + characters.IndexOf(enemy.gameObject));
            }
        }
        InCombat = true;
        CanvasScript.instance.SetCardsAside();
        NextTurn();
    }
    public void NextTurn()
    {
        int caracterIndex = 0;
        float lastSpeed = 0.0f;
        bool IsNooneAvailable = true;
        if (CheckBattleOver()) return;
        foreach(var character in inCombatCharacters)
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
                        caracterIndex = inCombatCharacters.IndexOf(character);
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
                        caracterIndex = inCombatCharacters.IndexOf(character);
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
        Hero hero = inCombatCharacters[index].GetComponent<Hero>();
        Enemy enemy = inCombatCharacters[index].GetComponent<Enemy>();

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
        Hero hero = inCombatCharacters[turnIndex].GetComponent<Hero>();
        Enemy enemy = inCombatCharacters[turnIndex].GetComponent<Enemy>();

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
        foreach(var character in inCombatCharacters)
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
    public bool CheckBattleOver()
    {
        int numberOfHeros = 0 , numberofHerosDead = 0;
        int numberOfEnemys = 0, numberOfEnemysDead = 0;

        foreach(var character in inCombatCharacters)
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
        Debug.Log("Heros: " + numberOfHeros);
        Debug.Log("Heros ded: " + numberofHerosDead);
        Debug.Log("Enemies: " + numberOfEnemys);
        Debug.Log("Enemies Ded: " + numberOfEnemysDead);
        if (numberOfEnemys == numberOfEnemysDead || numberOfHeros == numberofHerosDead)
        {
            Debug.Log("BattleOver");
            CanvasScript.instance.CombatMenuObject.SetActive(false);

            foreach(var character in inCombatCharacters)
            {
                Hero hero = character.GetComponent<Hero>();

                if(hero != null)
                {
                    hero.experience += 100;
                    hero.character.state = Character.StateMachine.END;
                }
            }
            for(int i = inCombatCharacters.Count -1; i >= 0; i--)
            {
                inCombatCharacters.RemoveAt(i);
            }
            GamePlay gP = FindObjectOfType<GamePlay>();

            gP.lockMove = false;
            InCombat = false;
            CanvasScript.instance.GetCardsBack();
            return true;
        }
        return false;
    }
    public void InstantiateEnemies(int number)
    {
        for (int i = 0; i < number; i++)
        {
            int rngEnemyType = Random.Range(0, enemies.Length-1);
            
            Instantiate(enemies[rngEnemyType]);
            
        }
        GetCharacters();
    }
}
