using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int speed;

    private void Awake()
    {
        speed = 100;
    }

    public int GetSpeed()
    {
        return speed; 
    }
    public void SetSpeed(int newSpeed)
    {
        this.speed = newSpeed;
    }

    private void Update()
    {
        if (this.speed <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
