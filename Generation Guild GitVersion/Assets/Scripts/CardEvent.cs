using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEvent : MonoBehaviour
{

    // Para aceder a stats do character tem de ser character.stats.health
    //Mas preferia em vez de procurares por character para evitar erros procura por Hero que são controlados por players mesmo



    //---------------------------------Blue--------------------------------//

    //Again character script needed
    public void BlueCursed1(Character character)
    {
        /*if (character.inCombat && character.HP <= 0)
        {
            //GameOver for party
        }*/
    }

    public void BlueTrap1(Character character)
    {
        /*if ((character.HP*100)/character.totalHP > 10)
        {
            character.HP -= (10 * character.totalHP / 100);
        }*/
    }


    //---------------------------------Purple--------------------------------//

    public void PurpleCursed1(Character[] characters)
    {
        foreach (Character c in characters)
        {
            /*if (c.inCombat && c.HP <= 0)
            {
                //GameOver for party
                break;
            }*/
        }
    }
}
