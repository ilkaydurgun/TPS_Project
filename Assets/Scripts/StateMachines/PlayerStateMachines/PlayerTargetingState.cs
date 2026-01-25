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
}
