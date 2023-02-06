using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PubCharacterState : MonoBehaviour
{
    public Action<int> AbilityCooldown;
    public Action<bool> IsJumping;
}
