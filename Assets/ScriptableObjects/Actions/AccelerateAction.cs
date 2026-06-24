using UnityEngine;

[CreateAssetMenu(fileName = "AccelerateAction", menuName = "Scriptable Objects/AccelerateAction")]
public class AccelerateAction : Action
{
    [SerializeField] private int speedAddition = 10;

    public override void Act()
    {
        int newSpeed = MainCharacter.instance.GetSpeed() + speedAddition;
        MainCharacter.instance.SetSpeed(newSpeed);
    }
}
