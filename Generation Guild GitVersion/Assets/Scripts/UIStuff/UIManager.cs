using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject panel;
    public GameObject dicePanel;
    public GameObject heroPanel;

    Dice dice;

    private void Awake()
    {
        dice = dicePanel.GetComponentInChildren<Dice>();
    }

    // Start is called before the first frame update
    void Start()
    {
        dice.gameObject.SetActive(false);
        dicePanel.SetActive(false);
        heroPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayDice()
    {
        dicePanel.SetActive(true);
        dice.gameObject.SetActive(true);
    }

    public void DesmiseDice()
    {
        dicePanel.SetActive(false);
        dice.gameObject.SetActive(false);
    }

    public void HeroButtons()
    {
        panel.SetActive(true);
        heroPanel.SetActive(true);
    }

    public void NoHeroButtons()
    {
        panel.SetActive(false);
        heroPanel.SetActive(false);
    }

}
