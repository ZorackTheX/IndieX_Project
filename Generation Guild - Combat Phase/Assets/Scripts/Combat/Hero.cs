using UnityEngine;

public class Hero : MonoBehaviour
{
    public Character character;
    
    public NewStats stats;
    public float maxExperience;
    public float experience;

    private void Awake()
    {
        SetStartingValues();
        SetExperienceValues();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            AddExperience(10.0f);
        }
        HeroStateMachine();
    }

    private void HeroStateMachine()
    {
        if(character.state == Character.StateMachine.ACTION)
        {
            CanvasScript.instance.CombatMenuObject.SetActive(true);
        }
        if(character.stats.health <=0)
        {
            character.state = Character.StateMachine.DEAD;
        }
    }

    private void SetExperienceValues()
    {
        character.stats.level = 1.0f;
        maxExperience = 100.0f;
    }

    private void SetStartingValues()
    {
        character.stats.health = stats.health;
        character.stats.maxHealth = stats.maxHealth;
        character.stats.strenght = stats.strenght;
        character.stats.intelligence = stats.intelligence;
        character.stats.defense = stats.defense;
        character.stats.speed = stats.speed;
    }

    public void AddExperience(float amount)
    {
        experience += amount;
        if(experience > maxExperience)
        {
            experience -= maxExperience;
            AddLevel();
            maxExperience += + (maxExperience * 0.1f);
        }
    }
    public void AddLevel()
    {
        character.stats.level++;
        Constitution();
        Strenght();
        Intelligence();
        Defense();
        Speed();
    }
    public void Strenght()
    {
        character.stats.strenght += stats.strenghtPerLevel;
    }
    public void Constitution()
    {
        character.stats.maxHealth += stats.healthPerLevel;
        character.stats.health += stats.healthPerLevel;
    }
    public void Intelligence()
    {
        character.stats.intelligence += stats.intelligencePerLevel;
    }
    public void Defense()
    {
        character.stats.defense += stats.defensePerLevel;
    }
    public void Speed()
    {
        character.stats.speed += stats.speedPerLevel;
    }

}
