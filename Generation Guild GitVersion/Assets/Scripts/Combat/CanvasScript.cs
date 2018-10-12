using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    public static CanvasScript instance;
    public GameObject CombatMenuObject;

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
    public void InitiateCombat()
    {

    }
}
