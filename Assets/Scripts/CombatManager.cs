using Mono.Cecil;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class CombatManager : MonoBehaviour
{
    [SerializeField] private int damageReducer = 10;
    [SerializeField] private int accelerationRate = 10;
    public enum CombatState { PlayerTurn, SelectingTarget, EnemyTurn }
    public enum Action { Attack, Accelerate};

    private Action action;
    public CombatState currentState = CombatState.PlayerTurn;
    private PlayerInputs inputActions;
    private Camera mainCamera;

    private void Awake()
    {
        inputActions = new PlayerInputs();
        mainCamera = Camera.main;
    }
    private void OnEnable()
    {
        inputActions.PlayerActions.Enable();
        inputActions.PlayerActions.EnemySelection.performed += EnemySelection_performed;
    }

    private void OnDisable()
    {
        inputActions.PlayerActions.EnemySelection.performed -= EnemySelection_performed;
        inputActions.PlayerActions.Disable();
    }

    private void Update()
    {
        if (currentState == CombatState.EnemyTurn) 
        {
            // Enemy Action

            currentState = CombatState.PlayerTurn;
        }
    }

    private void EnemySelection_performed(InputAction.CallbackContext obj)
    {
        if (currentState == CombatState.SelectingTarget)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Ray ray = mainCamera.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {

                Enemy target = hit.collider.GetComponentInParent<Enemy>();

                if (target != null)
                {
                    int damage = MainCharacter.instance.GetSpeed() / damageReducer;
                    int newSpeed = target.GetSpeed() - damage;
                    target.SetSpeed(newSpeed);

                    currentState = CombatState.EnemyTurn;
                }
            }
        }
        currentState = CombatState.PlayerTurn;
    }

    public void OnAttackButtonClicked() 
    {
        action = Action.Attack;
        currentState = CombatState.SelectingTarget;
    }

    public void OnAccelerateButtonClicked() 
    {
        int newSpeed = MainCharacter.instance.GetSpeed() + accelerationRate;
        MainCharacter.instance.SetSpeed(newSpeed);
        action = Action.Accelerate;
        currentState = CombatState.EnemyTurn;
    }

}
