using System;
using System.Diagnostics;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
   [field: SerializeField] public InputReader InputReader { get; private set; }
    void Start()
    {
        SwitchState(new PlayerTestState(this));
    }

    
}
