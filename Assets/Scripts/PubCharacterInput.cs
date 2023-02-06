using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PubCharacterInput : MonoBehaviour
{
    public Action<Vector3> Move;
    public Action<bool> Jump;
    public Action<bool> Ability;

    protected Vector3 pastMoveInput;
    protected bool pastJumpInput;
    protected bool pastAbilityInput;

    protected void MoveInput(Vector3 moveInput)
    {
        if (pastMoveInput != moveInput)
        {
            Move?.Invoke(moveInput);
            pastMoveInput = moveInput;
        }
    }

    protected void JumpInput(bool jumpInput)
    {
        if (pastJumpInput != jumpInput)
        {
            Jump?.Invoke(jumpInput);
            pastJumpInput = jumpInput;
        }
    }

    protected void AbilityInput(bool abilityInput)
    {
        if (pastAbilityInput != abilityInput)
        {
            Ability?.Invoke(abilityInput);
            pastAbilityInput = abilityInput;
        }
    }
}
