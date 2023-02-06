using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class Character : PubCharacterState, SubscriberCharacterInput
{

    public float moveSpeed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float abilityCooldown = 5.0f;

    protected CharacterController characterController;
    protected Vector3 moveDirection = Vector3.zero;
   

    protected float modifiedJumpSpeed;
    protected float modifiedMoveSpeed;
    protected int currentCooldown = 0;
    protected bool wasGrounded = true;



    // Start is called before the first frame update
    void Start()
    {
        modifiedJumpSpeed = jumpSpeed;
        modifiedMoveSpeed = moveSpeed;
        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);

        if (wasGrounded != characterController.isGrounded)
        {
            IsJumping?.Invoke(!characterController.isGrounded);
            wasGrounded = characterController.isGrounded;
        }
    }

    protected void OnMove(Vector3 direction)
    {
        if (characterController.isGrounded)
        {
            moveDirection = direction;
            moveDirection = transform.rotation * moveDirection;
            moveDirection *= modifiedMoveSpeed;
        }
    }

    protected void OnJump(bool jumping)
    {
        if (jumping)
        {
            moveDirection.y = modifiedJumpSpeed;
        }
    }

    protected void OnAbility(bool use)
    {
        if (currentCooldown <= 0)
        {
            StartCoroutine(StartAbilityCooldown());
        }
    }

    public void Subscribe(PubCharacterInput publisher)
    {
        publisher.Move += OnMove;
        publisher.Jump += OnJump;
        publisher.Ability += OnAbility;
   }

    public void Unsubscribe(PubCharacterInput publisher)
    {
        publisher.Move -= OnMove;
        publisher.Jump -= OnJump;
        publisher.Ability -= OnAbility;
    }

  

    IEnumerator StartAbilityCooldown()
{
 currentCooldown = (int)abilityCooldown;
 AbilityCooldown?.Invoke(currentCooldown);

 float startTime = Time.time;
 while (Time.time - startTime < abilityCooldown)
 {
     int newCooldown = (int)(abilityCooldown - (Time.time - startTime));
     if (currentCooldown != newCooldown)
     {
         currentCooldown = newCooldown;
         AbilityCooldown?.Invoke(currentCooldown);
     }

     yield return null;
 }
}

}
