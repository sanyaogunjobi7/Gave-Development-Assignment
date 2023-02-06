using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public List<CharacterHandler> players = new List<CharacterHandler>();
    private GameManager gm;

   

    private void Start()
   {
        gm = GameManager.Instance();
   }

   
    //	Spawn Player function    	
    

    public void SpawnPlayer(string playerName, int characterIndex, int inputIndex)
    {
        GameObject playerObject = new GameObject(playerName);
        players.Add(playerObject.AddComponent<CharacterHandler>());

        int index = players.Count - 1;
        players[index].InitCharacter(playerName, gm.characters[characterIndex], gm.characterInputs[inputIndex]);
        players[index].transform.position = new Vector3((index - (gm.numberOfPlayers * 0.5f)) * 2, 0, 0);
    }



}
