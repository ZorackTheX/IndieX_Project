using UnityEngine;

[CreateAssetMenu( menuName = "Class Stats/Stats")]
public class NewStats : ScriptableObject
{
    [Header("BaseStats")]
    public float maxHealth;
    public float health;
    public float strenght;
    public float intelligence;
    public float defense;
    public float speed;
    [Header("PerLevel")]
    public float healthPerLevel;
    public float strenghtPerLevel;
    public float intelligencePerLevel;
    public float defensePerLevel;
    public float speedPerLevel;
}
