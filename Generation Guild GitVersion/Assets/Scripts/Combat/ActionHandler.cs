using System.Collections.Generic;
public class ActionHandler
{
    public void ChangeDealerState(int dealerIndex)
    {
        Hero hero = BattleManager.instance.characters[dealerIndex].GetComponent<Hero>();
        Enemy enemy = BattleManager.instance.characters[dealerIndex].GetComponent<Enemy>();
        if (hero != null)
        {
            hero.character.state = Character.StateMachine.PERFORM;
        }
        if (enemy != null)
        {
            enemy.character.state = Character.StateMachine.PERFORM;
        }
    }
    public void DealDamage(List<int> receivers, float damageAmout)
    {
        if(receivers != null)
        {
            foreach (var receiverIndex in receivers)
            {
                Hero hero = BattleManager.instance.characters[receiverIndex].GetComponent<Hero>();
                Enemy enemy = BattleManager.instance.characters[receiverIndex].GetComponent<Enemy>();
                if (hero != null)
                {
                    hero.ITakeDamage(damageAmout);
                }
                if (enemy != null)
                {
                    enemy.ITakeDamage(damageAmout);
                }
            }
        }
    }
    public void EndDealerState(int index)
    {
        Hero hero = BattleManager.instance.characters[index].GetComponent<Hero>();
        Enemy enemy = BattleManager.instance.characters[index].GetComponent<Enemy>();
        if (hero != null)
        {
            hero.character.state = Character.StateMachine.END;
        }
        if (enemy != null)
        {
            enemy.character.state = Character.StateMachine.END;
        }
        BattleManager.instance.NextTurn();
    }
    public void DealAttackDamage(int receiverind, float damage)
    {
            Hero hero = BattleManager.instance.characters[receiverind].GetComponent<Hero>();
            Enemy enemy = BattleManager.instance.characters[receiverind].GetComponent<Enemy>();

            if (hero != null)
            {
                hero.ITakeDamage(damage);
            }
            if (enemy != null)
            {
                enemy.ITakeDamage(damage);
            }

    }
    public ActionHandler (int damageDealer, int damageReceiver, float damageAmount)
    {
        ChangeDealerState(damageDealer);
        DealAttackDamage(damageReceiver, damageAmount);
        EndDealerState(damageDealer);
    }
    public ActionHandler(SkillsData skillData, int dealerIndex)
    {
        ChangeDealerState(dealerIndex);
        foreach(var tag in skillData.skillHandler)
        {
            switch(tag.tag)
            {
                case (HyperTag.Tag.All):
                    foreach(var character in BattleManager.instance.characters)
                    {
                        if (tag.skilldamage != 0)
                        {
                            DealAttackDamage(BattleManager.instance.characters.IndexOf(character), tag.skilldamage);
                        }
                        if (tag.status.Length > 0)
                        {
                            AddEffect(BattleManager.instance.characters.IndexOf(character), tag.status[0]);
                        }
                    }
                    break;
                case (HyperTag.Tag.Others):
                    
                    if(tag.skilldamage != 0)
                    {
                        DealAttackDamage(tag.receiverIndex, tag.skilldamage);
                    }
                    if(tag.status.Length > 0 )
                    {
                        AddEffect(tag.receiverIndex, tag.status[0]);
                    }
                    break;
                case (HyperTag.Tag.Self):
                    if(tag.skilldamage != 0 )
                    {
                        DealAttackDamage(dealerIndex,tag.skilldamage);
                    }
                    if(tag.status.Length > 0)
                    {
                        AddEffect(dealerIndex, tag.status[0]);
                    }
                    break;
            }
        }
        EndDealerState(dealerIndex);
    }

    private static void AddEffect(int receiverind, StatusEffectsData status)
    {
        Hero hero = BattleManager.instance.characters[receiverind].GetComponent<Hero>();
        Enemy enemy = BattleManager.instance.characters[receiverind].GetComponent<Enemy>();

        if (hero != null)
        {
            hero.character.statusEffects.AddStatusEffect(status.statusEffect, status.turnDuration);
        }
        if (enemy != null)
        {
            enemy.character.statusEffects.AddStatusEffect( status.statusEffect,status.turnDuration);
        }
    }

}
