using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine stateMachine;
    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
    protected void Move(Vector3 motion, float deltaTime)
    {
        stateMachine.Controller.Move((motion + stateMachine.ForceReceiver.Movment) * deltaTime);
    }

    protected void FaceTarget()
    {
        if(stateMachine.Targeter.currentTarget==null) return;

        Vector3 lookPos = stateMachine.Targeter.currentTarget.transform.position - stateMachine.transform.position;
        lookPos.y = 0;
        
        stateMachine.transform.rotation = Quaternion.LookRotation(lookPos); 

    }
}
