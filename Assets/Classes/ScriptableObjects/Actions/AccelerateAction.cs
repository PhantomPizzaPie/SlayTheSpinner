using UnityEngine;

[CreateAssetMenu(fileName = "AccelerateAction", menuName = "Scriptable Objects/AccelerateAction")]
public class AccelerateAction : ActionDetails
{
    public override void Act(int luckFactor)
    {
        CombatManager.instance.setAccelerationBonus(luckFactor);
        CombatManager.instance.OnAccelerateButtonClicked();
    }
}
