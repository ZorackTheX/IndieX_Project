using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPaths : MonoBehaviour
{
    [Range(1,24)]
    public int[] cardNumb;

    CardStorage cardsStored;

    Card[] cards;

    
    public Card[] cardsDisplay
    {
        get
        {
            return cards;
        }
    }


    /*
    [Range(1, 24)]
    public int numberOfCard;
    */

    private void Awake()
    {
        cardsStored = GetComponentInParent<CardStorage>();

        cards = new Card[cardNumb.Length];
    }

    private void Start()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i] = cardsStored.cards[cardNumb[i] - 1];
            cards[i].positionNumb = cardNumb[i] - 1;
        }
    }
}
