using UnityEngine;

[CreateAssetMenu(fileName = "AttackAction", menuName = "Scriptable Objects/AttackAction")]
public class AttackAction : Action
{
    public override void Act()
    {
        CombatManager.instance.SetStateAttack();
    }
}
