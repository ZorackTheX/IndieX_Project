using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public CardStorage cardsMap;
    public Player player;
    public MapManager mapMan;

    Card[] cards;

    bool starting = true;
    public int currentPosition = 0;

    private void Start()
    {
        cards = cardsMap.cards;
    }

    private void Update()
    {
        if (mapMan.mapOut)
        {
            PlayCheck();
        }
    }

    void PlayCheck()
    {
        if (starting)
        {
            currentPosition = mapMan.map[0].positionNumb;

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

}
