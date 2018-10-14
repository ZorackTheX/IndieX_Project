[System.Serializable]
public class Character
{
    public Stats            stats;
    public Skills           skills;
    public StatusEffects    statusEffects;
    public enum StateMachine
    {
        DEAD,
        WAIT,
        ACTION,
        PERFORM,
        END
    }
    public StateMachine state;
    public int battleIndex;
    
    public bool IsStunned()
    {
        return true;
    }
}
