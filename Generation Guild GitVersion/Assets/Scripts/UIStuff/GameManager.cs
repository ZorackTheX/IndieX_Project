using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public AudioManager am;
    public UIManager UIm;
    public GameObject menu;

    [HideInInspector]
    public int n = 0;

    Scene scene;

    bool inMenu = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        am.Play("Overworld");
        UIm.panel.gameObject.SetActive(false);
        menu.SetActive(true);
    }

    void Update()
    {

        scene = SceneManager.GetActiveScene();

        if (scene.name == "GamePlay" || inMenu)
        {
            UIm.panel.gameObject.SetActive(true);
        }

        if (!inMenu)
        {
            UIm.panel.gameObject.SetActive(false);
        }
    }

    public void PlayGane()
    {
        menu.SetActive(false);
        inMenu = false;
        UIm.PlayDice();
        
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void DiceDisapear()
    {
        UIm.DesmiseDice();
    }

    public void ChoseHero()
    {
        UIm.HeroButtons();
    }

    public void Warrior()
    {
        n = 0;
        UIm.NoHeroButtons();
    }

    public void Priest()
    {
        n = 1;
        UIm.NoHeroButtons();
    }

    public void Mystic()
    {
        n = 2;
        UIm.NoHeroButtons();
    }

    public void Assassin()
    {
        n = 3;
        UIm.NoHeroButtons();
    }

    public void ResetGame()
    {
        UIm.NoHeroButtons();
        UIm.DesmiseDice();
        inMenu = true;

    }
}
