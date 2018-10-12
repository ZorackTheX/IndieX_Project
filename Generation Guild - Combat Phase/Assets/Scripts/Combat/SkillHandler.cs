using UnityEngine;
[System.Serializable]
public class SkillHandler 
{
    [Header("Target Index")]
    public int receiverIndex;
    public bool IsChosen;
    [Header("Skill Stats")]
    public float skilldamage;
    public StatusEffectsData[] status;
    public HyperTag.Tag tag;
}
