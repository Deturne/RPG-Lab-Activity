using UnityEngine;

[CreateAssetMenu(fileName = "CombatActions", menuName = "New Combat Action", order = 1)]
public class CombatActions : ScriptableObject
{
    public string DisplayName;
    public AttackType.Attack AttackType;

    public int Damage;
    public GameObject Projectile;

    public int HealAmount;

}
