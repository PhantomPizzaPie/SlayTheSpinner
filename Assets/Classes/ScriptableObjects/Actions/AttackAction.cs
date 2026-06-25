using UnityEngine;

[CreateAssetMenu(fileName = "AttackAction", menuName = "Scriptable Objects/AttackAction")]
public class AttackAction : ActionDetails
{
    public override void Act(int luckFactor)
    {
        CombatManager.instance.setBonusDamage(luckFactor);
        CombatManager.instance.SetStateAttack();
    }
}
