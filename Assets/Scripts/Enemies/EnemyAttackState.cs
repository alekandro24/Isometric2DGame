using UnityEngine;

public class EnemyAttackState : IEnemyState
{
    private EnemyController controller;

    //when a new state is created, the controller that created the state sends himself as a parametter for the new state
    public EnemyAttackState(EnemyController controller)
    {
        this.controller = controller;
    }

    public void Enter()
    {
        
    }

    public void Exit()
    {
        
    }

    public void FixedUpdate()
    {
        controller.StopMovement();
    }

    public void Update()
    {
        if (controller.DistanceToPlayer() <= controller.AttackRange) 
        {
            Debug.Log("attacking the player");
        }
        else
        {
            controller.StateMachine.ChangeState(new EnemyChaseState(controller));
        }
    }
}
