using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] CombatCharacter[] characters;
    [SerializeField] float nextTurnDelay = 1.0f;
    private int currentCharacterIndex = -1;

    public CombatCharacter currentCharacter;

    public static TurnManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void OnBeginTurn()
    {
        currentCharacterIndex++;

        if (currentCharacterIndex == characters.Length)
        {
            currentCharacterIndex = 0;
        }

        currentCharacter = characters[currentCharacterIndex];
        CombatEvents.OnBeginTurn.Invoke(currentCharacter);


    }

    public void OnEndTurn()
    {
        CombatEvents.OnEndTurn.Invoke(currentCharacter);
        Invoke("OnBeginTurn", nextTurnDelay);
    }

    private void OnCharacterDeath(CombatCharacter character)
    {
        Debug.Log("Character is dead");

        //CombatEvents.OnDeath.Invoke(character);
        //character.gameObject.SetActive(false);
        //characters = System.Array.FindAll(characters, c => c != character);
        //if (characters.Length == 0)
        //{
        //    Debug.Log("Game Over");
        //    // Handle game over logic here
        //}
    }

}
