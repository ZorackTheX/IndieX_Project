using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    public static CanvasScript instance;
    public GameObject UIPanel;
    public GameObject CombatMenuObject;
    public GameObject YouLoseMenu;

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
}
