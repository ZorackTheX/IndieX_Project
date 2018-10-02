using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Card: MonoBehaviour
{
    //Type of events RoomCards can be
    public enum Type { Red, Blue, Black, Purple, Yellow, Green };

    //Types of events in each RoomCards
    public Type[] types;

    //Number of events in each RoomCard
    [Range(1, 5)]
    public int eventNumb;


    private void Update()
    {

        //Adding the number of events in each RoomCard
        if (types.Length != eventNumb)
        {
            int diff = Mathf.Abs(types.Length - eventNumb);

            Type[] newTypes = new Type[types.Length + diff];
            types = newTypes;
        }
    }
}
