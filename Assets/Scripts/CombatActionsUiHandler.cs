using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CombatActionsUiHandler : MonoBehaviour
{
    [SerializeField] GameObject visualContainer;
    [SerializeField] Button[] actionButtons;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CombatEvents.OnBeginTurn.AddListener(OnBeginTurn);
        
        CombatEvents.OnEndTurn.AddListener(OnEndTurn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginTurn(CombatCharacter character)
    {
        if (!character.isPlayer)
        {
            return;
        }

        visualContainer.SetActive(true);

        for(int i = 0; i < actionButtons.Length; i++)
        {
            if (i < character.actions.Count)
            {
                actionButtons[i].gameObject.SetActive(true);
                CombatActions ca = character.actions[i];

                actionButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = ca.DisplayName;
                actionButtons[i].onClick.RemoveAllListeners();
                actionButtons[i].onClick.AddListener(() => OnClickCombatAction(ca));
            }
            else
            {
                actionButtons[i].gameObject.SetActive(false);
            }
        }
    }

    public void OnEndTurn(CombatCharacter character)
    {
        visualContainer.SetActive(false);
    }

    public void OnClickCombatAction(CombatActions action)
    {
        TurnManager.instance.currentCharacter.CastCombatActions(action);
    }
}
