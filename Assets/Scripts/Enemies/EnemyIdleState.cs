using UnityEngine;

public class EnemyIdleState : IEnemyState
{
    private EnemyController controller;
    private float idleTimer;

    //when a new state is created, the controller that created the state sends himself as a parametter for the new state
    public EnemyIdleState(EnemyController controller)
    {
        this.controller = controller;
    }

    //stops the enemy movement and set idleTimer to 0
    public void Enter()
    {
        controller.StopMovement();
        idleTimer = 0f;
    }

    //if the controller IsPlayerDetected is true, change the state of the enemy to chase state.
    //idleTimer increase constantly while in this state, when the timer reaches a certain poiint set in the controller, the enemy changes state to enemy patrol
    public void Update()
    {
        if (controller.IsPlayerDetected)
        {
            controller.StateMachine.ChangeState(new EnemyChaseState(controller));
        }

        idleTimer += Time.deltaTime;

        if (idleTimer >= controller.IdleDuration)
        {
            controller.StateMachine.ChangeState(new EnemyPatrolState(controller));
        }
    }

    public void Exit()
    {
        
    }

    public void FixedUpdate()
    {
        
    }

    
}
