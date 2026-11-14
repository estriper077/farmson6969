using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float RunSpeed = 8f;

    PlayerInput playerInput;
    InputAction moveAction;
    InputAction SprintActhion;
    Animator animator;


    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
        SprintActhion = playerInput.actions.FindAction("Sprint");

        animator = GetComponent<Animator>();
        
    }

    
    void Update()
    {
        movePlayer();
    }
    void movePlayer()
    {
        Vector2 derection = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(derection.x, 0, derection.y);

        bool isMoving = move.magnitude > 0.1f;
        bool isRunning = SprintActhion.IsPressed() && isMoving;

        float currentSpeed = isRunning ? RunSpeed : speed;
        

        transform.position += move * currentSpeed * Time.deltaTime;

        if(animator != null)
        {
            animator.SetFloat("Speed",move.magnitude);
            animator.SetBool("isRunning",isRunning);
        }

        if(move != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);

            transform.rotation = Quaternion.Slerp(
                transform.rotation, targetRotation, 
                Time.deltaTime * 10f);

        }
    }
}
