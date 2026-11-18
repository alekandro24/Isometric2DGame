using UnityEngine;

public class EnemyPatrolState : IEnemyState
{
    private EnemyController controller;
    private Transform targetPatrolLocation;

    private int currentPatrolPointIndex = 0;

    //when a new state is created, the controller that created the state sends himself as a parametter for the new state
    public EnemyPatrolState(EnemyController controller)
    {
        this.controller = controller;
    }

    //calls change patrol point
    public void Enter()
    {
        ChangePatrolPoint();
    }

    public void Exit()
    {
        
    }

    //if the distance to the current patrol point is less than the set, changePatrolPoint is called to set a new one
    //if the distance is big enought the enemy moves towards the current patrol point
    public void FixedUpdate()
    {
        if(targetPatrolLocation != null)
        {
            float distance = Vector2.Distance(controller.transform.position, targetPatrolLocation.position);
            if (distance <= 0.5f)
            {
                ChangePatrolPoint();
            }
            else
            {
                controller.MoveTowards(targetPatrolLocation.position);
            }
        }
    }

    //if IsPlayerDetected is true, change state to chase
    public void Update()
    {
        if (controller.IsPlayerDetected) 
        {
            controller.StateMachine.ChangeState(new EnemyChaseState(controller));
        }
    }

    //select randomly a patrol point from the controller list, if the selected patrol point is the same as the last one, the method is called again in the next tick
    private void ChangePatrolPoint() 
    {
        int tempInt = Random.Range(0, controller.PatrolPoints.Count);
        currentPatrolPointIndex = tempInt;
        targetPatrolLocation = controller.PatrolPoints[currentPatrolPointIndex];
    }
}
