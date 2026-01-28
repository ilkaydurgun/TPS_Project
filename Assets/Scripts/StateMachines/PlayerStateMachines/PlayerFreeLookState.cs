using UnityEngine;

public class PlayerFreeLookState : PlayerBaseState
{
    private readonly int FreeLookBlendTreeHash = Animator.StringToHash("FreeLookBlendTree");
    private readonly int FreeLookSpeedHash   = Animator.StringToHash("FreeLookSpeed");
    
  
    

    private const float AnimatorDampTime= 0.1f;
    public PlayerFreeLookState(PlayerStateMachine stateMachine) : base(stateMachine) {}
    public override void Enter()
    {
        stateMachine.InputReader.TargetEvent += OnTarget;
        stateMachine.Animator.Play(FreeLookBlendTreeHash);
        @Debug.Log("Entered Free Look State");
    }
    public override void Tick(float deltaTime)
    {
        Vector3 movement = CalculateMovement();


       
         Move(movement * stateMachine.FreeLookMovementSpeed, deltaTime);

        if (stateMachine.InputReader.MovmentValue == Vector2.zero)
        {

            stateMachine.Animator.SetFloat(FreeLookSpeedHash, 0, AnimatorDampTime, deltaTime);
            return;

        }
        stateMachine.Animator.SetFloat(FreeLookSpeedHash, 1, AnimatorDampTime, deltaTime);
        FaceMovmentDirection(movement, deltaTime);

        Debug.Log(stateMachine.InputReader.MovmentValue);

    }



    public override void Exit()
    {
        stateMachine.InputReader.TargetEvent -= OnTarget;
    }

    
    private void OnTarget()
    {
        if (!stateMachine.Targeter.SelectTarget()){
            return;
        }
        stateMachine.SwitchState(new PlayerTargetingState(stateMachine));
    }

    private Vector3 CalculateMovement()
    {
        Vector3 forward = stateMachine.MainCamera.forward;
        Vector3 right = stateMachine.MainCamera.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();
        return forward * stateMachine.InputReader.MovmentValue.y + right * stateMachine.InputReader.MovmentValue.x;
    }
        private void FaceMovmentDirection(Vector3 movement, float deltaTime)
    {
        stateMachine.transform.rotation = Quaternion.Lerp(
        stateMachine.transform.rotation, 
        Quaternion.LookRotation(movement),
        deltaTime*stateMachine.RotationSmoothValue  
        );
    }
}
