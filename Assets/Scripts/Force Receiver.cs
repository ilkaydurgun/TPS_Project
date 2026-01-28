using UnityEngine;

public class ForceReceiver : MonoBehaviour
{
    [SerializeField] private CharacterController characterController; 
    private float verticalVelocity;

    public Vector3 Movment =>  Vector3.up * verticalVelocity;

    private void Update()
    {
        if(verticalVelocity < 0f && characterController.isGrounded)
        {
           verticalVelocity=Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            
                verticalVelocity += Physics.gravity.y * Time.deltaTime; 
        }
    }
   
}
