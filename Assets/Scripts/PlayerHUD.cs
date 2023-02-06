using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerHUD : MonoBehaviour
{
    
    // Variables					
  

    public CharacterSettings characterSettingsPrefab;
    public CharacterInfo characterInfoPrefab;

    public GameManager gm;
    public CharacterSettings[] characterSettings;
    public CharacterInfo[] characterInfos;

    //	Routine Functions	    	
    void Awake()
    {
        gm = GameManager.Instance();
        CreateCharacterSettingHUDs();
    }

    void OnEnable()
    {
         for (int i = 0; i < gm.playerManager.players.Count; i++)
       
        {

            CharacterHandler characterHandler = gm.playerManager.players[i];
          characterInfos[i].Subscribe(characterHandler.characterState);
            characterInfos[i].Subscribe(characterHandler.characterInput);
        }
    }

    void OnDisable()
    {
        for (int i = 0; i < gm.playerManager.players.Count; i++)
        {
            CharacterHandler characterHandler = gm.playerManager.players[i];
            characterInfos[i].Unsubscribe(characterHandler.characterState);
            characterInfos[i].Unsubscribe(characterHandler.characterInput);
        }
    }

    //Member Functions	    		
    

    public void CreateCharacterSettingHUDs()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        characterSettings = new CharacterSettings[gm.numberOfPlayers];
        for (int i = 0; i < gm.numberOfPlayers; i++)
        {
            characterSettings[i] = Instantiate(characterSettingsPrefab, transform).GetComponent<CharacterSettings>();
            characterSettings[i].SetPlayerName("Player " + (i + 1));
        }
    }

    public void CreateCharacterInfoHUDs()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        characterInfos = new CharacterInfo[gm.playerManager.players.Count];
        for (int i = 0; i < gm.playerManager.players.Count; i++)
        {
            CharacterHandler characterHandler = gm.playerManager.players[i];
            characterInfos[i] = Instantiate(characterInfoPrefab, transform).GetComponent<CharacterInfo>();
            characterInfos[i].SetPlayerName(characterHandler.characterName);
            characterInfos[i].Subscribe(characterHandler.characterState);
            characterInfos[i].Subscribe(characterHandler.characterInput);
        }
    }

    public void SpawnPlayers()
    {
        for (int i = 0; i < characterSettings.Length; i++)
        {
            gm.playerManager.SpawnPlayer(characterSettings[i].characterName, characterSettings[i].selectedCharacterIndex, characterSettings[i].selectedInputIndex);
        }
        CreateCharacterInfoHUDs();
    }

    
}


