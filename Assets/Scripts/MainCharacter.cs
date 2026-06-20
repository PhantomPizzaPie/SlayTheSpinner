using Unity.VisualScripting;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    public static MainCharacter instance { get; private set; }
    private int speed;

    private void Awake()
    {
        this.speed = 100;
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }

    public int GetSpeed() 
    {
        return this.speed;
    }

    public void SetSpeed(int newSpeed) 
    {
        this.speed = newSpeed;
    }
}
