using UnityEngine;
using UnityEngine.UI;

//This set's up buttons and positions them
public class TargetingChoicesScript : MonoBehaviour
{
    public TargetIndex[] buttonTargets = new TargetIndex[8];


    private void OnEnable()
    {
        SettingUpIndexes();
    }
    
    private void SettingUpIndexes()
    {
        foreach (var chars in BattleManager.instance.characters)
        {
            foreach (var button in buttonTargets)
            {
                bool IsAllowed = true;
                Hero    hero    = chars.GetComponent<Hero>();
                Enemy   enemy   = chars.GetComponent<Enemy>();
                if (button.gameObject.activeInHierarchy)
                {
                    if (!button.IsFilled )
                    {

                        if (hero != null)
                        {
                            if (hero.character.state == Character.StateMachine.DEAD)
                            {
                                button.gameObject.SetActive(false);
                                IsAllowed = false;
                                break;
                            }
                        }
                        if (enemy != null)
                        {
                            if (enemy.character.state == Character.StateMachine.DEAD)
                            {
                                IsAllowed = false;
                                button.gameObject.SetActive(false);
                                break;
                            }
                        }
                        if(IsAllowed)
                        {
                            button.Index = BattleManager.instance.characters.IndexOf(chars);
                            button.IsFilled = true;
                            Text text = button.GetComponentInChildren<Text>();
                            text.text = chars.gameObject.name;
                            IsAllowed = true;
                            break;
                        }
                    }
                }

            }
        }
    }

    private void OnDisable()
    {
        foreach (var button in buttonTargets)
        {
            button.IsFilled = false;
        }
    }
}
