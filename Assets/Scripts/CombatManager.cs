using Mono.Cecil;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class CombatManager : MonoBehaviour
{
    public static CombatManager instance { get; private set; }
    [SerializeField] private int damageReducer = 10;
    [SerializeField] private Enemy[] enemies;
    public enum CombatState { PlayerTurn, SelectingTarget, EnemyTurn }
    public enum Action { Attack, Accelerate };
    public CombatState currentState = CombatState.PlayerTurn;
    private PlayerInputs inputActions;
    private Camera mainCamera;
    private int bonusDamage;
    private int accelerationBonus;

    public void setBonusDamage(int bonusDamage)
    {
        this.bonusDamage = bonusDamage;
    }

    public void setAccelerationBonus(int accelerationBonus)
    {
        this.accelerationBonus = accelerationBonus;
    }

    private void Awake()
    {
        inputActions = new PlayerInputs();
        mainCamera = Camera.main;

        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
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
                    int damage = MainCharacter.instance.GetSpeed() / damageReducer + bonusDamage;
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

    public void SetStateAttack()
    {
        if (currentState == CombatState.PlayerTurn)
        {
            currentState = CombatState.SelectingTarget;
        }
    }

    public void OnAccelerateButtonClicked()
    {
        if (currentState == CombatState.PlayerTurn)
        {
            int newSpeed = MainCharacter.instance.GetSpeed() + accelerationBonus;
            MainCharacter.instance.SetSpeed(newSpeed);
            StartCoroutine(StartEnemyTurn());
        }
    }
}
