using UnityEngine;
[CreateAssetMenu(menuName = "ClassSkills/Skills")]
public class SkillsData : ScriptableObject
{
    [Header("Skill Targets")]
    public SkillHandler[] skillHandler;
    public enum SkillSlot
    {
        Natural,
        Basic1,
        Basic2,
        Basic3,
        Ultimate
    }
    public enum SKillType
    {
        Active,
        Passive
    }
    [Header("Skill Settings")]
    public SkillSlot slot;
    public SKillType type;
    public int coolDownDuration;
    
}
