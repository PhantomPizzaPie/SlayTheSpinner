using System;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public class Wheel : MonoBehaviour
{

    [SerializeField] float minSpinDuration = 3.5f;
    [SerializeField] float maxSpinDuration = 5f;
    [SerializeField] float maxSpinAngle = 2000;
    [SerializeField] float minSpinAngle = 1200;
    public void Spin()
    {
        float spinningAngle = Random.Range(minSpinAngle, maxSpinAngle);
        float spinningDuration = Random.Range(minSpinDuration, maxSpinDuration);
        transform.DORotate(new Vector3(0, 0, spinningAngle), spinningDuration, RotateMode.FastBeyond360);
    }
}
