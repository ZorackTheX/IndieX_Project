﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEvent : MonoBehaviour
{

    // Para aceder a stats do character tem de ser character.stats.health
    //Mas preferia em vez de procurares por character para evitar erros procura por Hero que são controlados por players mesmo



    //---------------------------------Purple--------------------------------//

    //If you die everybody loses
    public void PurpleCursed1(Hero hero)
    {
        if (hero.stats.health <= 0 && hero.inCombat)
        {
            //GameOver for party
        }

        if (!hero.inCombat)
        {
            //Store a counter of 
        }
    }

    //You lose 10% hp
    public void PurpleTrap1(Hero hero)
    {
        if ((hero.stats.health*100)/hero.stats.maxHealth > 10)
        {
            hero.stats.health -= (10 * hero.stats.maxHealth / 100);
        }
    }

    //No heal next Combat
    public void PurpleTrap4(Hero hero)
    {
        if (!hero.inCombat)
        {
            //Store no heal
        }   
    } 

    //Get double xp
    public void PurpleGoodie1(Hero hero)
    {
        if (!hero.inCombat)
        {
            //Store double xp
        }
    }

    //---------------------------------Blue--------------------------------//

    //One party member dies everybody loses
    public void BlueCursed1(Hero[] heroes)
    {
        foreach (Hero h in heroes)
        {
            if (h.inCombat && h.stats.health <= 0)
            {
                //GameOver for party
                break;
            }

            if (!h.inCombat)
            {
                //Store a counter of 
            }
        }
    }

    //Reduced 5% heal for all party
    public void BlueCursed2(Hero[] heroes)
    {
        foreach (Hero h in heroes)
        {
            if (!h.inCombat)
            {
                //Store 5% less heal
            }
        }
    }

    //Revive
    public void BlueGoodie2(Hero[] heroes)
    {
        bool alive = false;
        int[] j = new int[heroes.Length];
        int counter = 0;

        for (int k = 0; k < j.Length; k++)
        {
            j[k] = 0;
        }

        for (int i = 0; i < heroes.Length; i++)
        {
            Hero h = heroes[i];

            if (!alive && h.stats.health <= 0.0f)
            {
                h.stats.health = (h.stats.maxHealth * 75) / 100;
                j[i] = 1;
                counter++;

                if (i == heroes.Length)
                {
                    alive = true;
                    i = -1;
                }
            }

            if (alive && j[i] == 1)
            {
                if ((h.stats.health * 100) / h.stats.maxHealth > 10)
                {
                    h.stats.maxHealth -= (counter*10 * h.stats.maxHealth / 100);

                    if (h.stats.maxHealth < h.stats.health)
                    {
                        h.stats.health = h.stats.maxHealth;
                    }
                }
            }
        }
    }

    //---------------------------------Yellow--------------------------------//

    //Naifa de sao mamada
    public void YellowItem1(Hero hero)
    {
        //Get to hero item Naifa de sao mamada - Instakill
    }

    //Health Potion
    public void YellowItem2(GamePlay gp)
    {
        //Store potion


    }

    //-----------------------------------Red----------------------------------//

    public void RedRoom1()
    {
        //Go to encounter
    }
}