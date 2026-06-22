using Mono.Cecil;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class CombatManager : MonoBehaviour
{
    [SerializeField] int damageReducer = 10;
    public enum CombatState { Idle, SelectingTarget }
    public CombatState currentState = CombatState.Idle;
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

                    currentState = CombatState.Idle;
                }
            }
        }
        currentState = CombatState.Idle;
    }

    public void OnAttackButtonClicked() 
    {
        currentState = CombatState.SelectingTarget;
    }

}
