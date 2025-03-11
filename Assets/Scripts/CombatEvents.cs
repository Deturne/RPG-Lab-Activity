using UnityEngine;
using UnityEngine.Events;

public static class CombatEvents 
{
    public static UnityEvent<CombatCharacter> OnBeginTurn = new UnityEvent<CombatCharacter>();
    public static UnityEvent<CombatCharacter> OnEndTurn = new UnityEvent<CombatCharacter>();
    public static UnityEvent<CombatCharacter> OnDeath = new UnityEvent<CombatCharacter>();
    public static UnityEvent OnHealthChange = new UnityEvent();

}
