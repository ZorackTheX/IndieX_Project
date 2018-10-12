using System.Collections.Generic;

[System.Serializable]

public class Action
{
    public int dealerIndex;
    public List<int> receivers;

    public float damageAmount;
    
    public List<StatusEffectsData> statuses;

    //Normal Attack Construtor
    public Action(int dealer, List<int> sentReceivers,float damage)
    {
        dealerIndex = dealer;
        damageAmount = damage;
        receivers = sentReceivers;
    }


    
    public Action(int dealer, List<int> sentReceivers, float damage,List<StatusEffectsData> statusi)
    {
        dealerIndex = dealer;
        receivers = sentReceivers;
        damageAmount = damage;
        statuses = statusi;
    }
}
