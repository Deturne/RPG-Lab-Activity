using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Character[] playerChars;
    [SerializeField] TMP_InputField playerNameInput;
    [SerializeField] Image[] playerSprite;
    [SerializeField] TextMeshProUGUI statList;
    [SerializeField] TMP_Dropdown classes;
    [SerializeField] Button rerollButton;
    [SerializeField] Button confirm;
    public int str;
    public int dex;
    public int cons;
    public int intel;
    public int wis;
    public int cha;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //classes.AddOptions(new List<string> { "Warrior", "Mage", "Rogue" });
        PopulateClasses();
        DisplayStats();
        str = UnityEngine.Random.Range((int)0, (int)10);
        dex = UnityEngine.Random.Range((int)0, (int)10);
        cons = UnityEngine.Random.Range((int)0, (int)10);
        intel = UnityEngine.Random.Range((int)0, (int)10);
        wis = UnityEngine.Random.Range((int)0, (int)10);
        cha = UnityEngine.Random.Range((int)0, (int)10);
        rerollButton.onClick.AddListener(Reroll);

    }

    // Update is called once per frame
    void Update()
    {
        DisplayStats();
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void PopulateClasses()
    {
        // Populate the classes dropdown with the available classes
        List<string> classNames = Enums.CharacterClass.GetNames(typeof(Enums.CharacterClass)).ToList();
        for(int i = 0; i < classNames.Count; i++)
        {
            classes.options.Add(new TMP_Dropdown.OptionData(classNames[i]));
        }
        
        
    }

    void DisplayStats() 
    { 
        statList.text = "Strength: " + str + "\n" +
                        "Dexterity: " + dex + "\n" +
                        "Constitution: " + cons + "\n" +
                        "Intelligence: " + intel + "\n" +
                        "Wisdom: " + wis + "\n" +
                        "Charisma: " + cha + "\n";
    }

    void Reroll()
    {
        str = UnityEngine.Random.Range((int)0, (int)10);
        dex = UnityEngine.Random.Range((int)0, (int)10);
        cons = UnityEngine.Random.Range((int)0, (int)10);
        intel = UnityEngine.Random.Range((int)0, (int)10);
        wis = UnityEngine.Random.Range((int)0, (int)10);
        cha = UnityEngine.Random.Range((int)0, (int)10);
    }

    void ConfirmCharacter()
    {
        //// Create a new character with the selected class and stats
        //Enums.CharacterClass selectedClass = (Enums.CharacterClass)classes.value;
        //Enums.CharacterType player = Enums.CharacterType.Player;
        //Character newCharacter = new Character(playerNameInput.text, playerCh,player,selectedClass,ability: );
        //playerChars[0] = newCharacter;
    }



}
