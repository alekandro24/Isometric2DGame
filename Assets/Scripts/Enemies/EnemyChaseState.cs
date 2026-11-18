using UnityEngine;

public class EnemyChaseState : IEnemyState
{
    private EnemyController controller;

    //when a new state is created, the controller that created the state sends himself as a parametter for the new state
    public EnemyChaseState(EnemyController controller)
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
        controller.MoveTowards(controller.PlayerTransform.position);
    }

    public void Update()
    {
        if (controller.AttackRange >= controller.DistanceToPlayer())
        {
            controller.StateMachine.ChangeState(new EnemyAttackState(controller));
        }
        else if (!controller.IsPlayerDetected)
        {
            controller.StateMachine.ChangeState(new EnemyPatrolState(controller));
        }
    }
}
