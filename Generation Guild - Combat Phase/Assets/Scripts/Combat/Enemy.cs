using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Character character;
    public EnemyClasses enemyClass;
    public NewStats stats;


    // Start is called before the first frame update
    void Awake()
    {
       SetStartingValues();
        
    }

    void SetStartingValues()
    {
        character.stats.health = stats.health;
        character.stats.maxHealth = stats.maxHealth;
        character.stats.strenght = stats.strenght;
        character.stats.intelligence = stats.intelligence;
        character.stats.defense = stats.defense;
        character.stats.speed = stats.speed;
    }
    // Update is called once per frame
    void Update()
    {
        if(character.stats.health <=0)
        {
            character.state = Character.StateMachine.DEAD;
        }
    }

}
