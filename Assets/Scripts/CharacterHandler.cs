using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterHandler : MonoBehaviour
{
   

    public string characterName = "Player 1";
    public Character statePrefab;
    public PubCharacterInput inputPrefab;

    public Character characterState;
    public PubCharacterInput characterInput;

  

    private void Awake()
    {
        characterName = name;
        characterState = Instantiate(statePrefab, transform);
        characterInput = Instantiate(inputPrefab, transform);

        characterState.Subscribe(characterInput);
    }

    void OnEnable()
    {
        characterState.Subscribe(characterInput);
    }

    void OnDisable()
    {
        characterState.Unsubscribe(characterInput);
    }

    public void InitCharacter(string name, Character characterPrefab, PubCharacterInput inputPrefab)
    {
        characterName = name;
        characterState = Instantiate(characterPrefab, transform);
        characterInput = Instantiate(inputPrefab, transform);

        characterState.Subscribe(characterInput);
    }
}
