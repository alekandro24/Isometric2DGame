public class EnemyStateMachine
{
    private IEnemyState currentState;

    public IEnemyState CurrentState { get => currentState; }

    //receives a new state and after checking if its a new state and its not null changes to that state
    public void ChangeState(IEnemyState newState)
    {
        if(currentState != newState && newState != null)
        {
            currentState?.Exit();
            currentState = newState;
            currentState.Enter();
        }
    }
    //execute Update method of the current state it it is not null
    public void Update()
    {
        currentState?.Update();
    }

    //execute FixedUpdate method of the current state if it is not null
    public void FixedUpdate()
    {
        currentState?.FixedUpdate();
    }

}
