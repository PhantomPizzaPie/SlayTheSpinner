using TMPro;
using UnityEngine;

public class SpeedIndicator : MonoBehaviour
{
    public TextMeshProUGUI speedIndicator;

    private int speed;

    void Start()
    {
        speed = MainCharacter.instance.GetSpeed();
    }

    private void Update()
    {
        speed = MainCharacter.instance.GetSpeed();
        speedIndicator.text = speed.ToString();
    }
}
