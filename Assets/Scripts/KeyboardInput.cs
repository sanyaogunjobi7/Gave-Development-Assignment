using UnityEngine;

public class KeyboardInput : PubCharacterInput
{
    public string xMoveAxis = "Horizontal";
    public string yMoveAxis = "Vertical";
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode abilityKey = KeyCode.LeftShift;

    void Update()
    {
        MoveInput(new Vector3(Input.GetAxis(xMoveAxis), 0f, Input.GetAxis(yMoveAxis)));
        JumpInput(Input.GetKey(jumpKey));
        AbilityInput(Input.GetKey(abilityKey));
    }
}

