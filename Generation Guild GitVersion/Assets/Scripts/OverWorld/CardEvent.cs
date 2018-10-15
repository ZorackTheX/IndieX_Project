using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEvent : MonoBehaviour
{

    // Para aceder a stats do character tem de ser character.stats.health
    //Mas preferia em vez de procurares por character para evitar erros procura por Hero que são controlados por players mesmo



    //---------------------------------Purple--------------------------------//

    //If you die everybody loses
    public void PurpleCursed1()
    {
        Debug.Log("You die, they lose");

        Hero[] heros = FindObjectsOfType<Hero>();

        int localRngValue = Random.Range(0, heros.Length - 1);

        if(heros[localRngValue] != null)
        {
            if(heros[localRngValue].character.state != Character.StateMachine.DEAD)
            {
                heros[localRngValue].IsDeathCursed = true;
            }
        }
        
    }

    //You lose 10% hp
    public void PurpleTrap1()
    {
        Debug.Log("Lose 10% hp");

        Hero[] heros = FindObjectsOfType<Hero>();

        int localRngValue = Random.Range(0, heros.Length - 1);

        if(heros[localRngValue] != null)
        {
            if ((heros[localRngValue].stats.health * 100) / heros[localRngValue].stats.maxHealth > 10)
            {
                heros[localRngValue].stats.health -= (10 * heros[localRngValue].stats.maxHealth / 100);
            }
        }
        else
        {
            PurpleTrap1();
        }
    }

    //No heal next Combat
    public void PurpleTrap4()
    {
        Debug.Log("No healing");
        Hero[] heros = FindObjectsOfType<Hero>();

        int localRngValue = Random.Range(0, heros.Length - 1);

        if (heros[localRngValue] != null)
        {
            //Store no heal
            heros[localRngValue].IsNoHealing = true;
        }
        else
        {
            PurpleTrap4();
        }
    } 

    //Get double xp
    public void PurpleGoodie1()
    {
        Debug.Log("Double Exp next batlle");
        Hero[] heros = FindObjectsOfType<Hero>();

        int localRngValue = Random.Range(0, heros.Length - 1);

        if (heros[localRngValue] != null)
        {
            heros[localRngValue].IsDoubleExp = true;
        }
        else
        {
            PurpleGoodie1();
        }
    }

    //---------------------------------Blue--------------------------------//

    //One party member dies everybody loses
    public void BlueCursed1()
    {
        Debug.Log("One Member dies, party loses the game");
        Hero[] heros = FindObjectsOfType<Hero>();

        foreach (var hero in heros)
        {
            if(hero != null)
            {
                if(hero.character.state != Character.StateMachine.DEAD)
                {
                    //Store If you die you all lose bool
                    hero.IsDeathCursed = true;
                }
            }
        }
    }

    //Reduced 5% heal for all party
    public void BlueCursed2()
    {
        Debug.Log("ReduceHeal");
        Hero[] heros = FindObjectsOfType<Hero>();

        foreach (var hero in heros)
        {
            if(hero != null)
            {
                if(hero.character.state != Character.StateMachine.DEAD)
                {
                    hero.IsReducedHealing = true;
                }
            }
        }
    }

    //Revive
    public void BlueGoodie2()
    {
        Debug.Log("Revive");
        Hero[] heros = FindObjectsOfType<Hero>();

        foreach(var hero in heros)
        {
            if(hero != null)
            {
                if(hero.character.state == Character.StateMachine.DEAD)
                {
                    hero.character.stats.health = hero.character.stats.maxHealth;
                    hero.character.state = Character.StateMachine.WAIT;
                }
            }
        }
    }

    //---------------------------------Yellow--------------------------------//

    //Naifa de sao mamada
    public void YellowItem1(Hero hero)
    {
        Debug.Log("Item : Naifa");
        //Get to hero item Naifa de sao mamada - Instakill
    }

    //Health Potion
    public void YellowItem2(GamePlay gp)
    {
        Debug.Log("Item : Health Potion");
        //Store potion


    }

    //-----------------------------------Red----------------------------------//

    public void RedRoom1()
    {

        Debug.Log("Combat");
        int rdmEnemies = Random.Range(1, 4);

        BattleManager.instance.InstantiateEnemies(rdmEnemies);
        //Go to encounter
    }
}
