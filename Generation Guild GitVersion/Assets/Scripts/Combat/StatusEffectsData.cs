[System.Serializable]
public class StatusEffectsData 
{
    public StatusEffects.StatusType statusEffect;
    public int turnDuration;
    
    public StatusEffectsData(StatusEffects.StatusType status, int turnDur)
    {
        
        statusEffect = status;
        turnDuration = turnDur;
    }
}
