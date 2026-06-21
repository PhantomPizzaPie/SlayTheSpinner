using Mono.Cecil;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class CombatManager : MonoBehaviour
{
    [SerializeField] private int damageReducer = 10;
    [SerializeField] private int accelerationRate = 10;
    [SerializeField] private Enemy[] enemies;
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

    private IEnumerator StartEnemyTurn()
    {
        currentState = CombatState.EnemyTurn;

        foreach (Enemy enemy in enemies)
        {
            yield return new WaitForSeconds(1f);
            if (enemy != null && enemy.GetSpeed() > 0)
            {
                enemy.Attack();
            }
        }

        currentState = CombatState.PlayerTurn;
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

                    StartCoroutine(StartEnemyTurn());
                    return;
                }
            }
        }
        else if (currentState == CombatState.EnemyTurn) 
        {
            return;
        }
        currentState = CombatState.PlayerTurn;
    }

    public void OnAttackButtonClicked() 
    {
        if (currentState == CombatState.PlayerTurn) 
        {
            action = Action.Attack;
            currentState = CombatState.SelectingTarget;
        }
    }

    public void OnAccelerateButtonClicked()
    {
        if (currentState == CombatState.PlayerTurn) 
        {
            int newSpeed = MainCharacter.instance.GetSpeed() + accelerationRate;
            MainCharacter.instance.SetSpeed(newSpeed);
            action = Action.Accelerate;
            StartCoroutine(StartEnemyTurn());
        }
    }
}
