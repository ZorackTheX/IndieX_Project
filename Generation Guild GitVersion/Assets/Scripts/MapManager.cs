using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    //Dice
    public Dice dice;

    //RoomCards
    public CardPaths[] cardPaths1;
    public CardPaths[] cardPaths2;
    Card[] cards;

    public int roomNumber = 4;
    public bool doMap = false;
    bool greenOut = false;
    bool typesDone = false;

    Animator anim;

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
            doMap = false;

            cards = new Card[roomNumber];

            CreateMap();
        }


        /*Testing*/

        /*
        if (Input.GetKeyDown(KeyCode.O))
        {
            CardTypeGeneration();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            AddEventToCard();
        }*/

        if (Input.GetKeyDown(KeyCode.R))
        {
            Remake();
        }
    }

    //Generates Route for the RoomCards to "appear"
    void CreateMap()
    {
        int random = Random.Range(0, 2);

        //First Path Choice
        if (random == 0)
        {
            switch (roomNumber)
            {
                case 4:
                    cards = cardPaths1[0].cardsDisplay;
                    break;
                case 5:
                    cards = cardPaths1[1].cardsDisplay;
                    break;
                case 6:
                    cards = cardPaths1[2].cardsDisplay;
                    break;
                case 7:
                    cards = cardPaths1[3].cardsDisplay;
                    break;
                case 8:
                    cards = cardPaths1[4].cardsDisplay;
                    break;
                case 9:
                    cards = cardPaths1[5].cardsDisplay;
                    break;
                case 10:
                    cards = cardPaths1[6].cardsDisplay;
                    break;
                case 11:
                    cards = cardPaths1[7].cardsDisplay;
                    break;
                case 12:
                    cards = cardPaths1[8].cardsDisplay;
                    break;
                case 13:
                    cards = cardPaths1[9].cardsDisplay;
                    break;
                case 14:
                    cards = cardPaths1[10].cardsDisplay;
                    break;
                case 15:
                    cards = cardPaths1[11].cardsDisplay;
                    break;
                case 16:
                    cards = cardPaths1[12].cardsDisplay;
                    break;
                case 17:
                    cards = cardPaths1[13].cardsDisplay;
                    break;
                case 18:
                    cards = cardPaths1[14].cardsDisplay;
                    break;
                case 19:
                    cards = cardPaths1[15].cardsDisplay;
                    break;
                case 20:
                    cards = cardPaths1[16].cardsDisplay;
                    break;
                case 21:
                    cards = cardPaths1[17].cardsDisplay;
                    break;
                case 22:
                    cards = cardPaths1[18].cardsDisplay;
                    break;
                case 23:
                    cards = cardPaths1[19].cardsDisplay;
                    break;
                case 24:
                    cards = cardPaths1[20].cardsDisplay;
                    break;
            }
        }

        //Second Path Choice
        else
        {
            switch (roomNumber)
            {
                case 4:
                    cards = cardPaths2[0].cardsDisplay;
                    break;
                case 5:
                    cards = cardPaths2[1].cardsDisplay;
                    break;
                case 6:
                    cards = cardPaths2[2].cardsDisplay;
                    break;
                case 7:
                    cards = cardPaths2[3].cardsDisplay;
                    break;
                case 8:
                    cards = cardPaths2[4].cardsDisplay;
                    break;
                case 9:
                    cards = cardPaths2[5].cardsDisplay;
                    break;
                case 10:
                    cards = cardPaths2[6].cardsDisplay;
                    break;
                case 11:
                    cards = cardPaths2[7].cardsDisplay;
                    break;
                case 12:
                    cards = cardPaths2[8].cardsDisplay;
                    break;
                case 13:
                    cards = cardPaths2[9].cardsDisplay;
                    break;
                case 14:
                    cards = cardPaths2[10].cardsDisplay;
                    break;
                case 15:
                    cards = cardPaths2[11].cardsDisplay;
                    break;
                case 16:
                    cards = cardPaths2[12].cardsDisplay;
                    break;
                case 17:
                    cards = cardPaths2[13].cardsDisplay;
                    break;
                case 18:
                    cards = cardPaths2[14].cardsDisplay;
                    break;
                case 19:
                    cards = cardPaths2[15].cardsDisplay;
                    break;
                case 20:
                    cards = cardPaths2[16].cardsDisplay;
                    break;
                case 21:
                    cards = cardPaths2[17].cardsDisplay;
                    break;
                case 22:
                    cards = cardPaths2[18].cardsDisplay;
                    break;
                case 23:
                    cards = cardPaths2[19].cardsDisplay;
                    break;
                case 24:
                    cards = cardPaths2[20].cardsDisplay;
                    break;
            }
        }

        if (!typesDone)
        {
            CardTypeGeneration();
            typesDone = true;
        }

        StartCoroutine(AppearCR());

    }


    //Couritine so the cards can have a flow 
    IEnumerator AppearCR()
    {
        for (int i = 0; i < cards.Length;i++)
        {
            anim = cards[i].gameObject.GetComponent<Animator>();
            anim.SetTrigger("AppearCard");
            yield return new WaitForSeconds(0.03f);
        }

    }

    //Reset variables to remake the map
    void Remake()
    {
        dice.ResetDiceCounter();
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
        //First card always the START
        for (int k = 0; k < cards[0].types.Length; k++)
        {
            cards[0].types[k] = Card.Type.START;
        }

        //Run through the cards to give them types
        for(int j = 1; j < cards.Length; j++)
        {
            //Just in case
            if (cards[j].types.Length < 0)
            {
                return;
            }

            else
            {
                //Run through the array of types to give 1 or several types
                for (int i = 0; i < cards[j].types.Length; i++)
                {

                    int rN = Random.Range(1, 7);

                    //In case green (the exit) is out
                    if (greenOut)
                    {
                        rN = Random.Range(1, 6);
                    }

                    switch (rN)
                    {
                        case 1:
                            cards[j].types[i] = Card.Type.Black;
                            break;
                        case 2:
                            cards[j].types[i] = Card.Type.Blue;
                            break;
                        case 3:
                            cards[j].types[i] = Card.Type.Red;
                            break;
                        case 4:
                            cards[j].types[i] = Card.Type.Purple;
                            break;
                        case 5:
                            cards[j].types[i] = Card.Type.Yellow;
                            break;
                        case 6:
                            cards[j].types[i] = Card.Type.Green;
                            break;
                    }

                    if (cards[j].types[i] == Card.Type.Green && !greenOut)
                    {
                        greenOut = true;
                    }

                    //In case there is no green card
                    if (j == cards.Length && !greenOut)
                    {
                        //Search to see if there is a green card
                        foreach (Card c in cards)
                        {
                            if (c.types[0] == Card.Type.Green)
                            {
                                greenOut = true;
                                break;
                            }
                        }

                        //Give the last card the type green
                        if (greenOut)
                        {
                            cards[j].types[i] = Card.Type.Green;
                        }
                    }

                    //In case of more than 1 type per card
                    if (cards[j].types.Length > 1)
                    {
                        //If green type no more types
                        if (cards[j].types[i] == Card.Type.Green)
                        {
                            greenOut = true;

                            for (i = 0; i < cards[j].types.Length; i++)
                            {
                                cards[j].types[i] = Card.Type.Green;
                            }
                        }

                        //No green
                        if (i > 0 && cards[j].types[i] != Card.Type.Green)
                        {
                            //Only one type
                            for (int l = i - 1; l >= 0; l--)
                            {
                                if (cards[j].types[l] == cards[j].types[i])
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

/*
    void CheckGreen()
    {
        foreach (Card c in cards)
        {
            if (c.types[0] == Card.Type.Green)
            {
                greenOut = true;
            }
        }
    }
    */
}
