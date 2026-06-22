using UnityEngine;

public class AttackButton : MonoBehaviour
{
    [SerializeField] private int damageReducer;

    [SerializeField] private Enemy target;

    public void Attack() 
    {
        int damage = MainCharacter.instance.GetSpeed()/damageReducer;
        int newSpeed = target.GetSpeed() - damage;
        target.SetSpeed(newSpeed);
    }
}
