using UnityEngine;

public class PlayerTestState : PlayerBaseState
{

    
    public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine) {}

    public override void Enter()
    {
    
    }
    public override void Tick(float deltaTime)
    {
        Vector3 movement = new Vector3();

        movement.x = stateMachine.InputReader.MovmentValue.x ;
        movement.y = 0f;
        movement.z = stateMachine.InputReader.MovmentValue.y ;

      
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

   
   
    
}
