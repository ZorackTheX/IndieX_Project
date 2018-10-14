using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{

    public float spinTime = 2.0f;
    public float diceCD = 3.5f;

    int diceNum;
    float time = 0.0f;
    bool diceClicked = false;
    bool diceblock = false;

    int counter = 0;

    private int _roomCalc = 0;

    //This way it's read-only
    public int roomCalc
    {
        get
        {
            return _roomCalc;
        }
    }

    public bool roomCalcDone = false;
    public bool working = true;
    public bool mapOutDiceBlock = false;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (roomCalcDone)
        {
            diceblock = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !diceblock && !mapOutDiceBlock)
        {
            diceblock = true;
            diceClicked = true;
            anim.SetTrigger("StartDice");
            diceNum = Random.Range(1,6);
            anim.SetInteger("Random", diceNum);
            time = Time.time;
            counter++;

            if (counter <= 4)
            {
                StoreDiceValue();
            }
        }

        if (Time.time - time >= spinTime && diceClicked)
        {
            anim.SetTrigger("StopDice");
            diceClicked = false;
        }

        if (Time.time - time >= diceCD && diceblock)
        {
            diceblock = false;
        }

        float newTime = 0.0f;

        if (counter >= 4 && working)
        {
            newTime = Time.time;
            working = false;
            StartCoroutine(DiceCR());
        }

        if ((Time.time - newTime) >= 10f && working)
        {
            roomCalcDone = false;
        }
    }

    IEnumerator DiceCR()
    {
        yield return new WaitForSeconds(3.5f);
        roomCalcDone = true;
    }

    void StoreDiceValue()
    {
        if (!roomCalcDone)
        {
            _roomCalc += diceNum;
        }
    }


    public void ResetDice()
    {
        mapOutDiceBlock = false;
        working = true;
        diceblock = false;
        counter = 0;
        _roomCalc = 0;
    }
}
