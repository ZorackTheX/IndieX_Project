using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class GetCharacterName : MonoBehaviour
{
    TextMeshProUGUI nameText;

    private void OnEnable()
    {
        nameText = GetComponent<TextMeshProUGUI>();
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
