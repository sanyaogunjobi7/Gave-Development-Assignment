using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CharacterInfo : MonoBehaviour, SubscriberCharacterInput, SubscriberCharacterState
{
    
    //	Variables					
    

    [SerializeField]
    private TMP_Text playerName;

    [SerializeField]
    private TMP_Text inputMovingText;
    [SerializeField]
    private TMP_Text inputJumpingText;
    [SerializeField]
    private TMP_Text inputAbilityText;

    [SerializeField]
    private TMP_Text stateJumpingText;
    [SerializeField]
    private TMP_Text stateAbilityCooldownText;

    
    //	Member Functions	    		
    

    public void SetPlayerName(string name)
    {
        playerName.text = name;
    }

    private void InputMoving(Vector3 moveDir)
    {
        inputMovingText.color = moveDir.magnitude > 0 ? Color.red : Color.white;
    }

    private void InputJumping(bool jumping)
    {
        inputJumpingText.color = jumping ? Color.red : Color.white;
    }

    private void InputAbility(bool ability)
    {
        inputAbilityText.color = ability ? Color.red : Color.white;
    }

    private void StateJumping(bool jumping)
    {
        stateJumpingText.color = jumping ? Color.red : Color.white;
    }

    private void StateAbilityCooldown(int abilityCooldown)
    {
        stateAbilityCooldownText.text = "Ability Cooldown" + (abilityCooldown != 0 ? " [" + abilityCooldown + "]" : "");
        stateAbilityCooldownText.color = abilityCooldown != 0 ? Color.red : Color.white;
    }

    
    //	Subscriptions 	   
   

    public void Subscribe(PubCharacterInput publisher)
    {
        publisher.Move += InputMoving;
        publisher.Jump += InputJumping;
        publisher.Ability += InputAbility;
    }

    public void Unsubscribe(PubCharacterInput publisher)
    {
        publisher.Move -= InputMoving;
        publisher.Jump -= InputJumping;
        publisher.Ability -= InputAbility;
    }

    public void Subscribe(PubCharacterState publisher)
    {
        publisher.IsJumping += StateJumping;
        publisher.AbilityCooldown += StateAbilityCooldown;
    }

    public void Unsubscribe(PubCharacterState publisher)
    {
        publisher.IsJumping -= StateJumping;
        publisher.AbilityCooldown -= StateAbilityCooldown;
    }

    
}
