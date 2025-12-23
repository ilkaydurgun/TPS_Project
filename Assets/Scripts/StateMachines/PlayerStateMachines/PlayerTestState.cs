using UnityEngine;

public class PlayerTestState : PlayerBaseState
{

    
    public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine) {}

    public override void Enter()
    {
    
    }
    public override void Tick(float deltaTime)
    {
        Vector3 movment = new Vector3();

        movment.x = stateMachine.InputReader.MovmentValue.x ;
        movment.y = 0f;
        movment.z = stateMachine.InputReader.MovmentValue.y ;

      
        stateMachine.Controller.Move(movment * stateMachine.FreeLookMovementSpeed * deltaTime   );

        if (movment == Vector3.zero) { return; }

        stateMachine.transform.rotation = Quaternion.LookRotation(movment);
        
      Debug.Log( stateMachine.InputReader.MovmentValue);
        
    }

    public override void Exit()
    {
    }

   
   
    
}
