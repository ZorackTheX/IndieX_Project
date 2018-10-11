using UnityEngine;

public class TargetIndex : MonoBehaviour
{
    public int Index;
    public bool IsFilled;

    private void OnEnable()
    {
        IsFilled = false;
    }
    public void SetBool()
    {
        if(IsFilled)
        {
            IsFilled = false;
        }
        if(!IsFilled)
        {
            IsFilled = true;
        }
    }
}

