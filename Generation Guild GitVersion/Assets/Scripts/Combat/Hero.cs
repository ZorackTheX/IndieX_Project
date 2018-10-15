using UnityEngine;

public class Hero : MonoBehaviour
{
    public Character character;
    
    public NewStats stats;
    public float maxExperience;
    public float experience;

    [Header("Boolean Curses")]
    public bool IsNoHealing = false;
    public bool IsReducedHealing = false;
    public bool IsDeathCursed = false;
    public bool IsDoubleExp = false;
    //Need a bool to check if in combat
    public bool inCombat = false;

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
        if(character.stats.health <= 0)
        {
            character.state = Character.StateMachine.DEAD;
        }
        if(character.state == Character.StateMachine.DEAD )
        {
            if(IsDeathCursed)
            {
                CanvasScript.instance.CombatMenuObject.SetActive(false);
                CanvasScript.instance.YouLoseMenu.SetActive(true);
            }
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
        if (IsDoubleExp) experience += amount * 2.0f;
        else experience += amount;

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
    public virtual void ITakeDamage(float amount)
    {
        if(amount < 0 )
        {
            if (IsReducedHealing) character.stats.health -= amount * 0.95f;
            else if (IsNoHealing) return;
            else character.stats.health -= amount;
        }
        else
        {
            character.stats.health -= amount;
        }
    }
}
