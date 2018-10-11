[System.Serializable]
public class Character : ITakeDamage
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

    public virtual void ITakeDamage(float amount)
    {
        stats.health -= amount;
    }
    
    public bool IsStunned()
    {
        return true;
    }
}
