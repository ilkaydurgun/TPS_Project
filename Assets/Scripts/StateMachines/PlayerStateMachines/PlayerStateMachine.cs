using System;
using System.Diagnostics;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
   [field: SerializeField] public InputReader InputReader { get; private set; }
   [field: SerializeField] public CharacterController Controller { get; private set; }
   [field: SerializeField] public Animator Animator { get; private set; }
     public Transform MainCamera { get; private set; }
   [field: SerializeField] public float FreeLookMovementSpeed { get; private set; }
    void Start()
    {
        MainCamera = Camera.main.transform;
        SwitchState(new PlayerTestState(this));
    }

    
}
