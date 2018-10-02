using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    //Dice
    public Dice dice;

    //RoomCards
    public Card[] cards;
    public Card[] entryCards;

    public int roomNumber = 0;
    bool doMap = false;
    int cardOrderRandom;

    private void Update()
    {
        if(dice.roomCalcDone && !doMap)
        {
            roomNumber = dice.roomCalc;
            dice.roomCalcDone = false;
            doMap = true;
        }

        if (doMap)
        {
            cardOrderRandom = Random.Range(1, 4);

            CreateMap();
        }


        /*Testing*/


        if (Input.GetKeyDown(KeyCode.O))
        {
            CardTypeGeneration();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            AddEventToCard();
        }
    }

    //Generates Route for the RoomCards to "appear"
    void CreateMap()
    {

        if (roomNumber == 24)
        {
            
        }
    }

    //AddEvent to every RoomCard
    void AddEventToCard()
    {
        foreach (Card c in cards)
        {
            c.eventNumb++;
        }
    }

    //Generate new types for each RoomCard
    void CardTypeGeneration()
    {
        foreach (Card c in cards)
        {

            if (c.types.Length < 0)
            {
                return;
            }

            else
            {
                for (int i = 0; i < c.types.Length; i++)
                {
                    int rN = Random.Range(1,6);

                    switch (rN)
                    {
                        case 1:
                            c.types[i] = Card.Type.Black;
                            break;
                        case 2:
                            c.types[i] = Card.Type.Blue;
                            break;
                        case 3:
                            c.types[i] = Card.Type.Red;
                            break;
                        case 4:
                            c.types[i] = Card.Type.Purple;
                            break;
                        case 5:
                            c.types[i] = Card.Type.Yellow;
                            break;
                    }

                    if (i > 0)
                    {
                        
                        for (int j = i - 1; j >= 0 ; j--)
                        {
                            if (c.types[j] == c.types[i])
                            {
                                i--;
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
