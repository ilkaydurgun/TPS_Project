using UnityEngine;

public class PlayerTestState : PlayerBaseState
{

    
    public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine) {}

    public override void Enter()
    {
    
    }
    public override void Tick(float deltaTime)
    {
        Vector3 movement = CalculateMovement();

  
      
        stateMachine.Controller.Move(movement * stateMachine.FreeLookMovementSpeed * deltaTime   );

        if (stateMachine.InputReader.MovmentValue == Vector2.zero) { 
          
          stateMachine.Animator.SetFloat("FreeLookSpeed", 0, 0.1f, deltaTime);
          return;
          
       }
        stateMachine.Animator.SetFloat("FreeLookSpeed", 1, 0.1f, deltaTime);

        stateMachine.transform.rotation = Quaternion.LookRotation(movement);
        
      Debug.Log( stateMachine.InputReader.MovmentValue);
        
    }

    public override void Exit()
    {
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
    
}
