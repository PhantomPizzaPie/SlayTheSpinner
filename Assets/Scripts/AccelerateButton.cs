using UnityEngine;

public class AccelerateButton : MonoBehaviour
{
    [SerializeField] private int speedAddition = 10;
    public void UpdateSpeed() 
    {
        int newSpeed = MainCharacter.instance.GetSpeed() + speedAddition;
        MainCharacter.instance.SetSpeed(newSpeed);
    }
}
