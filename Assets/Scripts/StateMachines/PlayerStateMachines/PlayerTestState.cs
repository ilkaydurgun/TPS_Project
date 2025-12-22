using UnityEngine;

public class PlayerTestState : PlayerBaseState
{

    private float timer=5f;
    public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine) {}

    public override void Enter()
    {
        Debug.Log("Entered Test State");
    }
    public override void Tick(float deltaTime)
    {
        timer -= deltaTime;    
        Debug.Log("Ticking Test State , time left: " + timer);

        if (timer <= 0f)
        {
            stateMachine.SwitchState(new PlayerTestState(stateMachine));
        }
        
    }

    public override void Exit()
    {
        Debug.Log("Exited Test State");
    }

   
    
}
