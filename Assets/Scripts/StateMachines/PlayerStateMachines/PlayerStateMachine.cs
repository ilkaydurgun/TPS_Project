using System;
using System.Diagnostics;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{

    void Start()
    {
        SwitchState(new PlayerTestState(this));
    }

    
}
