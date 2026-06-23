using UnityEngine;

[CreateAssetMenu(fileName = "AccelerateAction", menuName = "Scriptable Objects/AccelerateAction")]
public class AccelerateAction : Action
{
    public new Sprite sprite;
    public new Color backgroundColor;
    [SerializeField] private int speedAddition = 10;

    public override void Act()
    {
        int newSpeed = MainCharacter.instance.GetSpeed() + speedAddition;
        MainCharacter.instance.SetSpeed(newSpeed);
    }
}
