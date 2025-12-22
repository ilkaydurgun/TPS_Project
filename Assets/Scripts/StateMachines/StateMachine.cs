using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
 
    private State currentState;
 

   
    public void switchState(State newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }
    private void Update()
    {
       currentState?.Tick(Time.deltaTime); 
    }
}
