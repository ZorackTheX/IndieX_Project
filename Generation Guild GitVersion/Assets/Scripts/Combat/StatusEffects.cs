using System.Collections.Generic;
[System.Serializable]
public class StatusEffects
{

    public enum StatusType
    {
        Stun,
        Defense,
        Illusion,
        Poison,
        Vulnerable,
        Barrier,
        MagBarrier,
        Link,
        Shaken,
        Silence,
        Taunt,
        Clumsy,
        MuscleLock,
        Fear
    }

    public List<StatusEffectsData> statusEffectsApplied;

    public void AddStatusEffect(StatusType status, int duration)
    {
        if (CheckStatus(status, duration)) return;

        statusEffectsApplied.Add(new StatusEffectsData(status, duration));
    }
    
    public void RemoveATurnFor(StatusEffectsData statusEffect)
    {
        foreach(var status in statusEffectsApplied)
        {
            status.turnDuration--;
            if(status.turnDuration < 1)
            {
                statusEffectsApplied.Remove(status);
            }
        }
    }

    public bool CheckStatus(StatusType? status, int duration)
    {
        foreach (var statuses in statusEffectsApplied)
        {
            if (statuses.statusEffect == status)
            {
                statuses.turnDuration += duration;
                return true;
            }
        }
        return false;
    }
}
