using UnityEngine.UI;
using UnityEngine;

public class GetCharacterName : MonoBehaviour
{
    Text nameText;

    private void OnEnable()
    {
        nameText = GetComponent<Text>();
        GetCharName();
    }
    void GetCharName()
    {
        foreach(var character in BattleManager.instance.inCombatCharacters)
        {
            Hero hero = character.GetComponent<Hero>();
            Enemy enemy = character.GetComponent<Enemy>();

            if(hero != null)
            {
                if(hero.character.state == Character.StateMachine.ACTION)
                {
                    nameText.text = character.name;
                }
            }
            if(enemy != null)
            {
                if(enemy.character.state == Character.StateMachine.ACTION)
                {
                    nameText.text = character.name;
                }
            }
        }
    }
}
