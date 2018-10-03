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

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !diceblock)
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

        if (counter == 4)
        {
            StartCoroutine(DiceCR());
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


    public void ResetDiceCounter()
    {
        roomCalcDone = false;
        counter = 0;
        _roomCalc = 0;
    }
}
