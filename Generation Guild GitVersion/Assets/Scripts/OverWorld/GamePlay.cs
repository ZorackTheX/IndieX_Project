using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public CardStorage cardsMap;
    public Player player;
    public MapManager mapMan;
    public Transform partyBase;
    public CardEvent cardEvent;

    Card[] cards;

    bool starting = true;
    bool newEvent = true;
    bool lockMove = false;
    public int currentPosition = 0;
    public int actualPosition = 0;
    public Transform currPos;

    [Range(0,3)]
    private int chosenHero = 0;

    private void Start()
    {
        cards = cardsMap.cards;

        currPos = player.currPos.transform;
    }

    private void Update()
    {
        if (mapMan.mapOut && !lockMove)
        {
            PlayCheck();
        }

        //Move Party (Reveal Card)

        if (newEvent)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ChangeRoom();
            }
        }
        

        //Reset

        if (Input.GetKeyDown(KeyCode.R))
        {
            player.transform.position = partyBase.position;
            currPos.position = player.transform.position;

            mapMan.Remake();
        }

        player.actualPosition = actualPosition;
    }

    void PlayCheck()
    {
        if (starting)
        {
            currentPosition = mapMan.map[0].positionNumb;

            actualPosition = currentPosition;

            starting = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (CheckCardPath(currentPosition - 1))
            {
                currentPosition -= 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (CheckCardPath(currentPosition - 6))
            {
                currentPosition -= 6;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (CheckCardPath(currentPosition + 1))
            {
                currentPosition += 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (CheckCardPath(currentPosition + 6))
            {
                currentPosition += 6;
            }
        }

        //Commit

        player.transform.position = cards[currentPosition].transform.position;
        currPos.position = player.transform.position;
    }

    bool CheckCardPath(int number)
    {
        bool temp = false;

        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i].positionNumb == number)
            {
                temp = cards[i].activated;
                break;
            }
        }

        return temp;
    }

    void ChangeRoom()
    {

        if (currentPosition == actualPosition + 1 || currentPosition == actualPosition - 1 ||
            currentPosition == actualPosition + 6 || currentPosition == actualPosition - 6)
        {
            actualPosition = currentPosition;

            currPos.position = player.transform.position;

            ChooseEvent();

            lockMove = true;
        }
    }

    void ChooseEvent()
    {
        if (cards[actualPosition].types.Length < 1)
        {
            return;
        }

        if(cards[actualPosition].types.Length == 1)
        {
            switch (cards[actualPosition].types[0])
            {
                case Card.Type.Purple:
                    DoPurpleEvents(ChooseCharacter());
                    break;
                case Card.Type.Blue:
                    DoBlueEvents();
                    break;
                case Card.Type.Yellow:
                    DoYellowEvents(ChooseCharacter());
                    break;
                case Card.Type.Red:
                    DoRedEvents();
                    break;
            }
        }

        //Do Courotine
        if (cards[actualPosition].types.Length > 1)
        {

        }
    }

    Hero ChooseCharacter()
    {
        //Do UI to chooseCharacter

        return player.heroes[chosenHero];
    }

    //--------------------------Events-----------------------------//

    //Need Complition

        void DoPurpleEvents(Hero hero)
        {
            int r = Random.Range(0, 4);

            switch (r)
            {
                case 0:
                    cardEvent.PurpleCursed1(hero);
                    break;
                case 1:
                    cardEvent.PurpleTrap1(hero);
                    break;
                case 2:
                    cardEvent.PurpleTrap4(hero);
                    break;
                case 3:
                    cardEvent.PurpleGoodie1(hero);
                    break;
            }
        }

        void DoBlueEvents()
        {
            int r = Random.Range(0, 3);

            switch (r)
            {
                case 0:
                    cardEvent.BlueCursed1(player.heroes);
                    break;
                case 1:
                    cardEvent.BlueCursed2(player.heroes);
                    break;
                case 2:
                    cardEvent.BlueGoodie2(player.heroes);
                    break;
            }
        }

        void DoYellowEvents(Hero hero)
        {
            int r = Random.Range(0, 2);

            switch (r)
            {
                case 0:
                    cardEvent.YellowItem1(hero);
                    break;
                case 1:
                    cardEvent.YellowItem2(this.GetComponent<GamePlay>());
                    break;
            }
        }

        void DoRedEvents()
        {
            cardEvent.RedRoom1();
        }
}
