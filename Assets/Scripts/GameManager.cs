using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Character[] playerChars;
    [SerializeField] TMP_InputField playerNameInput;
    [SerializeField] Image[] playerSprite;
    [SerializeField] TextMeshProUGUI statList;
    [SerializeField] TMP_Dropdown classes;    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //classes.AddOptions(new List<string> { "Warrior", "Mage", "Rogue" });
        PopulateClasses();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
