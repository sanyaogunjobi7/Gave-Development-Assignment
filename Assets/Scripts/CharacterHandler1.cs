using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHandler1 : MonoBehaviour
{
    
    public string characterName { get; private set; }
    public Character characterState { get; private set; }
    public PubCharacterInput characterInput { get; private set; }

   

    void OnEnable()
    {
        characterState?.Subscribe(characterInput);
    }

    void OnDisable()
    {
        characterState?.Unsubscribe(characterInput);
    }

    //	Initializing characters    	
   

    public void InitCharacter(string name, Character characterPrefab, PubCharacterInput inputPrefab)
    {
        characterName = name;
        characterState = Instantiate(characterPrefab, transform);
        characterInput = Instantiate(inputPrefab, transform);

        characterState.Subscribe(characterInput);
    }

}