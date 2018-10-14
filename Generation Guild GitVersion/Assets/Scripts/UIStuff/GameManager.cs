using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public AudioManager am;
    public UIManager UIm;
    public Dice dice;
    public GameObject menu;

    Scene scene;

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
        dice.gameObject.SetActive(false);
        menu.SetActive(true);
    }

    void Update()
    {

        scene = SceneManager.GetActiveScene();

        if (scene.name == "GamePlay")
        {
            UIm.panel.gameObject.SetActive(true);
        }
    }

    public void PlayGane()
    {
        menu.SetActive(false);
        dice.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
