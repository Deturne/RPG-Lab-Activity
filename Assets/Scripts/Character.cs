using UnityEngine;

public class Character
{
    public Enums.CharacterClass cclass;

    public Enums.CharacterType ctype;

    public Enums.AbilityScoreNames anames;

    public string CharacterName;

    public GameObject character;



    public struct AbilityScores
    {

        public struct Abilities()
        {
            int Strength = 0;
            int Dexterity = 0;
            int Constitution = 0;
            int Intelligence = 0;
            int Wisdom = 0;
            int Charisma = 0;

            
        }

    }

    public Character(string name, GameObject characterobj)
    {
        characterobj = character;
        name = CharacterName;


        
    }

        


}
