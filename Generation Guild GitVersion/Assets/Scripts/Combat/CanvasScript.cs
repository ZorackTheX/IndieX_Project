using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    public static CanvasScript instance;
    public GameObject UIPanel;
    public GameObject CombatMenuObject;
    public GameObject YouLoseMenu;
    public GameObject Cards;

    private Vector3 lastpos;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void SetCardsAside()
    {
        lastpos = Cards.transform.position;
        Cards.transform.position = new Vector3(-10000.0f,-10000.0f,-10000.0f);
    }
    public void GetCardsBack()
    {
        Cards.transform.position = lastpos;
    }
}
