using UnityEngine.UI;
using UnityEngine;

public class GetASkill : MonoBehaviour
{
    private SkillsData skillData;
    public SkillsData.SkillSlot slotType;

    private void OnEnable()
    {
        SetSkillNames();
    }

    private void SetSkillNames()
    {
        foreach (var character in BattleManager.instance.characters)
        {
            Hero hero = character.GetComponent<Hero>();
            Enemy enemy = character.GetComponent<Enemy>();

            if (hero != null && hero.character.state == Character.StateMachine.ACTION)
            {
                foreach (var skill in hero.character.skills.skillsAvailable)
                {
                    if (skill.slot == slotType)
                    {
                        Text text = GetComponentInChildren<Text>();
                        skillData = skill;
                        text.text = skill.name;
                    }
                }
            }
        }
    }

    public void SendSkills()
    {
        foreach (var character in BattleManager.instance.characters)
        {
            Hero hero = character.GetComponent<Hero>();
            Enemy enemy = character.GetComponent<Enemy>();

            if (hero != null && hero.character.state == Character.StateMachine.ACTION)
            {
                foreach (var skill in hero.character.skills.skillsAvailable)
                {
                    if (skill.slot == slotType)
                    {
                        CombatMenu cM = CanvasScript.instance.CombatMenuObject.GetComponent<CombatMenu>();
                        cM.Skill(skillData);
                    }
                }
            }
        }
    }
}
