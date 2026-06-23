using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public class Wheel : MonoBehaviour
{
    [SerializeField] Action[] actions;
    [SerializeField] float minSpinDuration = 1f;
    [SerializeField] float maxSpinDuration = 5f;
    [SerializeField] float maxSpinAngle = -1200;
    [SerializeField] float minSpinAngle = -2000;
    public void Spin()
    {
        float spinningAngle = Random.Range(minSpinAngle, maxSpinAngle);
        float spinningDuration = Random.Range(minSpinDuration, maxSpinDuration);
        transform.DORotate(new Vector3(0, 0, spinningAngle), spinningDuration, RotateMode.FastBeyond360);
    }

    public Action GetRandomAction()
    {
        return actions[Random.Range(0, actions.Length)];
    }
}
