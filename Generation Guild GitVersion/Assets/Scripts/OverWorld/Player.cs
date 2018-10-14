using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /* Just a test
    private int _actualPosition;

    public int actualPosition
    {
        get
        {
            return _actualPosition;
        }

        set
        {
            _actualPosition = actualPosition;
        }
    }*/

    [HideInInspector]
    public int actualPosition;

    public GameObject currPos;

    [Range(1,4)]
    public static int size = 4;

    //Array of characters (Create Class Chars)
    public Hero[] heroes;

    private void Awake()
    {
        heroes = new Hero[size];
    }
}
