using UnityEngine;
using UnityEngine.UI;

//This set's up buttons and positions them
public class TargetingChoicesScript : MonoBehaviour
{
    public TargetIndex[] buttonTargets = new TargetIndex[8];
    int lastIndex;
    private void OnEnable()
    {
        SettingUpIndexes();
    }
    
    private void SettingUpIndexes()
    {
        if(buttonTargets.Length - BattleManager.instance.inCombatCharacters.Count > 0)
        {
            for(int i = 0; i < buttonTargets.Length - BattleManager.instance.inCombatCharacters.Count; i++)
            {
                buttonTargets[i].gameObject.SetActive(false);
            }
        }
        foreach (var chars in BattleManager.instance.inCombatCharacters)
        {
            bool IsAllowed = true;
            Hero hero = chars.GetComponent<Hero>();
            Enemy enemy = chars.GetComponent<Enemy>();
            
            if(hero != null)
            {
                if(hero.character.state == Character.StateMachine.DEAD)
                {
                    IsAllowed = false;
                }
            }
            if(enemy != null)
            {
                if(enemy.character.state == Character.StateMachine.DEAD)
                {
                    IsAllowed = false;
                }
            }
            
            foreach (var button in buttonTargets)
            {
                if (!button.IsFilled)
                {
                    if(IsAllowed)
                    {
                        button.Index = BattleManager.instance.inCombatCharacters.IndexOf(chars);
                        button.IsFilled = true;
                        Text text = button.GetComponentInChildren<Text>();
                        text.text = chars.gameObject.name;

                        break;
                    }
                    else
                    {
                        button.IsFilled = true;
                        Button buttonInteraction = button.GetComponent<Button>();
                        buttonInteraction.interactable = false;

                        Image buttonImage = button.GetComponent<Image>();
                        buttonImage.color = new Color(20, 20, 20, 250);

                        break;
                    }
                }
            }
        }
    }
}
