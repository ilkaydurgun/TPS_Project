using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions

{
    public Vector2 MovmentValue { get; private set; }
    public event Action DodgeEvent;
    public event Action JumpEvent;

    private Controls controls;

    void Start()
    {
        controls = new Controls();
        controls.Player.SetCallbacks(this);
        controls.Player.Enable();
    }
    private void OnDestroy()
    {
        controls.Player.Disable();  
        
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed){ return; }
        JumpEvent?.Invoke();
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
         if (!context.performed){ return; }
        DodgeEvent?.Invoke();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MovmentValue = context.ReadValue<Vector2>();
    }
}
