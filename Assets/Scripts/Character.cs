using System;
using UnityEngine;

public class Character
{
    [SerializeField] public Enums.CharacterClass cclass;
    [SerializeField] public Enums.CharacterType ctype;
    [SerializeField] private string characterName;
    [SerializeField] public GameObject character;
    [SerializeField] private AbilityScores abilityScore;

    public string CharacterName
    {
        get => characterName;
        set => characterName = value;
    }

    public GameObject CharacterObject
    {
        get => character;
        set => character = value;
    }

    public Enums.CharacterType CharacterType
    {
        get => ctype;
        set => ctype = value;
    }

    public Enums.CharacterClass CharacterClass
    {
        get => cclass;
        set => cclass = value;
    }

    public AbilityScores AbilityScore
    {
        get => abilityScore;
        set => abilityScore = value;
    }


    public struct AbilityScores
    {
        public struct Abilities
        {
            private int strength;
            private int dexterity;
            private int constitution;
            private int intelligence;
            private int wisdom;
            private int charisma;

            public int Strength
            {
                get => strength;
                set => strength = Math.Clamp(value, 0, 10);
            }

            public int Dexterity
            {
                get => dexterity;
                set => dexterity = Math.Clamp(value, 0, 10);
            }

            public int Constitution
            {
                get => constitution;
                set => constitution = Math.Clamp(value, 0, 10);
            }

            public int Intelligence
            {
                get => intelligence;
                set => intelligence = Math.Clamp(value, 0, 10);
            }

            public int Wisdom
            {
                get => wisdom;
                set => wisdom = Math.Clamp(value, 0, 10);
            }

            public int Charisma
            {
                get => charisma;
                set => charisma = Math.Clamp(value, 0, 10);
            }

            public Abilities(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
            {
                this.strength = Math.Clamp(strength, 0, 10);
                this.dexterity = Math.Clamp(dexterity, 0, 10);
                this.constitution = Math.Clamp(constitution, 0, 10);
                this.intelligence = Math.Clamp(intelligence, 0, 10);
                this.wisdom = Math.Clamp(wisdom, 0, 10);
                this.charisma = Math.Clamp(charisma, 0, 10);
            }

            public int getModifier(Enums.AbilityScoreNames name)
            {
                int modifier = 0;
                switch (name)
                {
                    case Enums.AbilityScoreNames.Strength:
                        modifier = Strength;
                        break;
                    case Enums.AbilityScoreNames.Dexterity:
                        modifier = Dexterity;
                        break;
                    case Enums.AbilityScoreNames.Constitution:
                        modifier = Constitution;
                        break;
                    case Enums.AbilityScoreNames.Intelligence:
                        modifier = Intelligence;
                        break;
                    case Enums.AbilityScoreNames.Wisdom:
                        modifier = Wisdom;
                        break;
                    case Enums.AbilityScoreNames.Charisma:
                        modifier = Charisma;
                        break;
                }

                if (modifier <= 2)
                {
                    return -1;
                }
                else if (modifier <= 4)
                {
                    return 0;
                }
                else if (modifier <= 6)
                {
                    return 1;
                }
                else if (modifier <= 8)
                {
                    return 2;
                }
                else
                {
                    return 3;
                }
            }


        }
    }

    
    public Character(string name, GameObject characterobj, Enums.CharacterType characterType, Enums.CharacterClass characterClass,AbilityScores ability)
    {
        characterName = name;
        character = characterobj;
        ctype = characterType;
        cclass = characterClass;
        abilityScore = ability;

    }
}
