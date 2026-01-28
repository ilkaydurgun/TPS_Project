using System;
using UnityEngine;

public class PlayerTargetingState : PlayerBaseState
{
    private readonly int TargetingBlendTreeHash = Animator.StringToHash("TargetingBlendTree");
    public PlayerTargetingState(PlayerStateMachine stateMachine) : base(stateMachine){}

    public override void Enter()
    {
       stateMachine.InputReader.CancelEvent += OnCancel;
       stateMachine.Animator.Play(TargetingBlendTreeHash);
       Debug.Log("Entered Targeting State");
    }

    public override void Tick(float deltaTime)
    {
        if(stateMachine.Targeter.currentTarget==null)
        {
            stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
            return;
        }

        Vector3 movment =CalculateMovement();
        Move(movment * stateMachine.TargetingMovementSpeed, deltaTime);

        FaceTarget();

        Debug.Log(stateMachine.Targeter.currentTarget.name);
       
    }


    public override void Exit()
    {
        stateMachine.InputReader.CancelEvent -= OnCancel;   
    }

    private void OnCancel()
    {
        stateMachine.Targeter.Cancel();
        stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
    }  

    private Vector3 CalculateMovement()
    {
        Vector3 movment = new Vector3();

        movment += stateMachine.transform.right * stateMachine.InputReader.MovmentValue.x;
        movment += stateMachine.transform.forward * stateMachine.InputReader.MovmentValue.y;
            
        return movment;
    }

}
