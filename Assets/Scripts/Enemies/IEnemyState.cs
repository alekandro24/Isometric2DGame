//interface to use as base for each enemy state
public interface IEnemyState
{
    void Enter();
    void Update();
    void FixedUpdate();
    void Exit();
}
