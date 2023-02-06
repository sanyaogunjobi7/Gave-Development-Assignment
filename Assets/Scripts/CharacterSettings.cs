using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterSettings : MonoBehaviour
{
    

    public string characterName;
    public int selectedCharacterIndex = 0;
    public int selectedInputIndex = 0;

 
    public TMP_Text playerText;
    public TMP_Text characterText;
    public TMP_Text inputText;
    private GameManager gm;

    
    private void Awake()
    {
        gm = GameManager.Instance();

        // Initial GUI Values
        characterText.text = gm.characters[selectedCharacterIndex].name;
        inputText.text = gm.characterInputs[selectedInputIndex].name;
    }

    
    public void SetPlayerName(string name)
    {
        characterName = name;
        playerText.text = name;
    }

    public void PreviousCharacter()
    {
        selectedCharacterIndex = selectedCharacterIndex > 0 ? selectedCharacterIndex - 1 : gm.characters.Length - 1;
        characterText.text = gm.characters[selectedCharacterIndex].name;
    }

    public void NextCharacter()
    {
        selectedCharacterIndex = selectedCharacterIndex >= gm.characters.Length - 1 ? 0 : selectedCharacterIndex + 1;
        characterText.text = gm.characters[selectedCharacterIndex].name;
    }

    public void PreviousInput()
    {
        selectedInputIndex = selectedInputIndex > 0 ? selectedInputIndex - 1 : gm.characterInputs.Length - 1;
        inputText.text = gm.characterInputs[selectedInputIndex].name;
    }

    public void NextInput()
    {
        selectedInputIndex = selectedInputIndex >= gm.characterInputs.Length - 1 ? 0 : selectedInputIndex + 1;
        inputText.text = gm.characterInputs[selectedInputIndex].name;
    }

   
}
