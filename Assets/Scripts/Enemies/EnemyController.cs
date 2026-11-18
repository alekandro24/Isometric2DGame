using System.Collections.Generic;
using UnityEngine;

//force creation of the components
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class EnemyController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform playerTransform;
    //saves a list of transform for the enemy to patrol randomly
    [SerializeField] private List<Transform> patrolPoints;

    [Header("Movement")]
    [SerializeField] private float maxSpeed = 2f;
    [SerializeField] private float idleDuration = 3f;

    [Header("Detection")]
    //set the radious of the circle collider 2D
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private float attackRange = 1f;

    private Rigidbody2D rb;
    //responsible of representing the current state
    private EnemyStateMachine stateMachine;
    //collider to detect the player
    private CircleCollider2D circleCollider;
    private bool isPlayerDetected = false;

    public Transform PlayerTransform { get => playerTransform; }
    public List<Transform> PatrolPoints { get => patrolPoints; }
    public float MaxSpeed { get => maxSpeed; }
    public float DetectionRange { get => detectionRange; }
    public float AttackRange { get => attackRange; }
    public Rigidbody2D Rb { get => rb; }
    public EnemyStateMachine StateMachine { get => stateMachine; }
    public float IdleDuration { get => idleDuration; }
    public CircleCollider2D CircleCollider { get => circleCollider; }
    public bool IsPlayerDetected { get => isPlayerDetected; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        stateMachine = new EnemyStateMachine();
        circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.radius = detectionRange;
    }

    private void Start()
    {
        //change to the default enemy state, in this case being IdleState
        stateMachine.ChangeState(new EnemyIdleState(this));
    }

    private void Update()
    {
        //executes the Update methond from the stateMachine that at the same time executes the currentState Update method.
        stateMachine.Update();
    }

    private void FixedUpdate()
    {
        //executes the FixedUpdate methond from the stateMachine that at the same time executes the currentState FixedUpdate method.
        stateMachine.FixedUpdate();
    }

    //returns the distance between this enemy position and the playerCharacter position
    public float DistanceToPlayer()
    {
        return Vector2.Distance(transform.position, playerTransform.position);
    }

    //move this enemy towards the vector2 position sent trought the parameter
    public void MoveTowards(Vector2 target)
    {
        Vector2 direction = (target - (Vector2)transform.position).normalized;

        rb.linearVelocity = direction * maxSpeed;
    }

    public void StopMovement()
    {
        rb.linearVelocity = Vector2.zero;
    }

    //activates when a collider enters this enemy trigger collider.
    //Check if the other collider transform is the same as the one set from the playerCharacter, if true isPlayerDetected is set to true
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform == playerTransform)
        {
            isPlayerDetected = true;
        }
    }

    //activates when a collider exits this enemy trigger collider.
    //Check if the other collider transform is the same as the one set from the playerCharacter, if true isPlayerDetected is set to false
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform == playerTransform)
        {
            isPlayerDetected = false;
        }
    }
}
