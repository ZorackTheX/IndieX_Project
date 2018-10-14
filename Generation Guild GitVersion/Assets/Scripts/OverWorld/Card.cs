using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Card: MonoBehaviour
{
    //Type of events RoomCards can be
    public enum Type { Red, Blue, Purple, Yellow, Green, START};

    //Types of events in each RoomCards
    public Type[] types;

    //Number of events in each RoomCard
    [Range(1, 5)]
    public int eventNumb;

    public bool activated = false;
    public int positionNumb;


    private void Update()
    {

        //Adding the number of events in each RoomCard (Resize())
        if (types.Length != eventNumb)
        {
            int diff = Mathf.Abs(types.Length - eventNumb);

            Type[] newTypes = new Type[types.Length + diff];
            types = newTypes;
        }
    }
}
