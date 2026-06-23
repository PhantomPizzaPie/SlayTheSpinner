using UnityEngine;

[CreateAssetMenu(fileName = "AttackAction", menuName = "Scriptable Objects/AttackAction")]
public class AttackAction : Action
{
    public new Sprite sprite;
    public new Color backgroundColor;
    int damageReducer = 10;
    [SerializeField] private Enemy target;

    public override void Act()
    {
        int damage = MainCharacter.instance.GetSpeed() / damageReducer;
        int newSpeed = target.GetSpeed() - damage;
        target.SetSpeed(newSpeed);
    }
}
