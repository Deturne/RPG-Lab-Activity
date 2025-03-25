using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] private CombatCharacter character;
    [SerializeField] private AnimationCurve healRate;

    private void Start()
    {
       CombatEvents.OnBeginTurn.AddListener(OnBeginTurn);
    }

    public void OnBeginTurn(CombatCharacter c)
    {
        if(character == c)
        {
            DetermineCombatActions();
        }
    }

    public void DetermineCombatActions()
    {
        float healthPercentage = character.GetHealthPercentage();
        bool wantToHeal = Random.value < healRate.Evaluate(healthPercentage);
        CombatActions action = null;

        if(wantToHeal && DetermineIfHasCombatActionType(AttackType.Attack.Heal))
        {
            action = GetCombatActionOfType(AttackType.Attack.Heal);
        }
        else if (DetermineIfHasCombatActionType(AttackType.Attack.Attack))
        {
            action = GetCombatActionOfType(AttackType.Attack.Attack);
        }
        
        if(action != null)
        {
            character.CastCombatActions(action);
        }
        else
        {
            TurnManager.instance.OnEndTurn();
        }
    }

    private bool DetermineIfHasCombatActionType(AttackType.Attack type)
    {
        return character.actions.Exists(x => x.AttackType == type);
    }

    private CombatActions GetCombatActionOfType(AttackType.Attack type)
    {
        List<CombatActions> availableActions = character.actions.FindAll(x => x.AttackType == type);
        return availableActions[Random.Range(0, availableActions.Count)];
    }
}

