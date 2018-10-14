using UnityEngine;
using System.Collections.Generic;

public class CombatMenu : MonoBehaviour
{
    [Header("Menu References")]
    public GameObject PrimaryActionMenu;
    public GameObject SkillChoiceMenu;
    public GameObject ConfirmSkillActionMenu;

    [Header("Attack Pointers")]
    public int dealer;
    public int receiveIndex;
    private List<int> skillReceivers;
    public float damage;
    private List<StatusEffectsData> statusEffects;
    private int numberOfTargets;
    SkillsData skilldata;
    private int filledChoices;

    private void OnEnable()
    {
        PrimaryActionMenu.SetActive(true);
    }
    public void Attack()
    {
        foreach(var character in BattleManager.instance.characters)
        {
            Hero hero = character.GetComponent<Hero>();
            Enemy enemy = character.GetComponent<Enemy>();

            if (hero != null && hero.character.state == Character.StateMachine.ACTION)
            {
                damage = hero.character.stats.strenght;
                dealer = BattleManager.instance.characters.IndexOf(character);
                break;
            }
            if (enemy != null && enemy.character.state == Character.StateMachine.ACTION)
            {
                damage = enemy.character.stats.strenght;
                dealer = BattleManager.instance.characters.IndexOf(character);
                break;
            }
        }
    }
    public void AttackActionReceiver(TargetIndex targetIndex)
    {
            receiveIndex = targetIndex.Index;
    }
    public void EnemyAttackRceiver(int targetInd)
    {
        receiveIndex = targetInd;
    }
    public void Skill(SkillsData skillData)
    {
        foreach (var character in BattleManager.instance.characters)
        {
            Hero hero = character.GetComponent<Hero>();
            Enemy enemy = character.GetComponent<Enemy>();

            if (hero != null && hero.character.state == Character.StateMachine.ACTION)
            {
                dealer = BattleManager.instance.characters.IndexOf(character);
                numberOfTargets = skillData.skillHandler.Length;
                skilldata = skillData;
                Debug.Log("Target Array Lenght: " + skillData.skillHandler.Length);
                break;
            }
            if (enemy != null && enemy.character.state == Character.StateMachine.ACTION)
            {
                //action.damageAmount = enemy.character.stats.strenght;
                //action.dealerIndex = BattleManager.instance.characters.IndexOf(character);
                break;
            }
        }
    }
    public void SkillTargetsChosen(TargetIndex targetIndex)
    {
        foreach (var skill in skilldata.skillHandler)
        {
            if (skill.IsChosen) continue;

            skill.IsChosen = targetIndex.IsFilled;
            skill.receiverIndex = targetIndex.Index;
            break;
        }
        SkillChoicesCheck();
    }
    public void SkillChoicesCheck()
    {
        int num = 0;
        TargetIndex[] targetButtons = GetComponentsInChildren<TargetIndex>();

        foreach(var targetButton in targetButtons)
        {
            if(targetButton.isActiveAndEnabled)
            {
                if (targetButton.IsFilled)
                {
                    num += 1;
                }
            }
        }
        if(num == skilldata.skillHandler.Length)
        {
            SkillChoiceMenu.SetActive(false);
            ConfirmSkillActionMenu.SetActive(true);
        }
        //Debug.Log("Targets picked? " + (filledChoices == numberOfTargets));
    }
    public void ConfirmActionAttack()
    {
        new ActionHandler(dealer, receiveIndex, damage);
    }
    public void ConfirmSkillAction()
    {
        new ActionHandler(skilldata, dealer);
    }
}
