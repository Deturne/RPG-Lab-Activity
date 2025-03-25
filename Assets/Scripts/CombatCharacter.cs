using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCharacter : MonoBehaviour
{
    public bool isPlayer;

    public List<CombatActions> actions;

    public int currHP;
    public int maxHP;

    [SerializeField] CombatCharacter opponent;

    private Vector3 startPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Taking damage: " + damage);
        currHP -= damage;
        CombatEvents.OnHealthChange.Invoke();

        if (currHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        CombatEvents.OnDeath.Invoke(this);
        Destroy(gameObject);
    }

    public void Heal(int healAmount)
    {
        currHP += healAmount;
        CombatEvents.OnHealthChange.Invoke();

        if (currHP > maxHP)
        {
            currHP = maxHP;
        }
    }

    public void CastCombatActions(CombatActions action)
    {
        if (action.Damage > 0)
        {
            StartCoroutine(AttackOpponent(action));
        }
        else if (action.Projectile != null)
        {
            GameObject projectile = Instantiate(action.Projectile, startPos, Quaternion.identity);
        }
        else if (action.HealAmount > 0)
        {
            Heal(action.HealAmount);
            TurnManager.instance.OnEndTurn();
        }
        else
        {
            TurnManager.instance.OnEndTurn();
        }
    }

    IEnumerator AttackOpponent(CombatActions action)
    {
        while(transform.position != opponent.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, opponent.transform.position, 50 * Time.deltaTime);
            yield return null;
        }

        opponent.TakeDamage(action.Damage);

        while (transform.position != startPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, 20 * Time.deltaTime);
            yield return null;
        }

        TurnManager.instance.OnEndTurn();
    }

    public float GetHealthPercentage()
    {
        float healthPercentage = (float)currHP / maxHP;
        return healthPercentage;

    }
}
