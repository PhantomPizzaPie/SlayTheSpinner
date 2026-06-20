using TMPro;
using UnityEngine;

public class EnemySpeedIndicator : MonoBehaviour
{
    private int speed;

    [SerializeField] private Enemy enemy;

    [SerializeField] private TextMeshProUGUI indicator;

    private void Awake()
    {
        speed = enemy.GetSpeed();
    }

    private void Update()
    {
        speed = enemy.GetSpeed();
        indicator.text = speed.ToString();
    }
}
