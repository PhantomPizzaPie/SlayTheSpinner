using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;
using System.Collections;
using UnityEngine.UI;

public class Wheel : MonoBehaviour
{
    [SerializeField] Action[] actions;
    [SerializeField] float minSpinDuration = 1f;
    [SerializeField] float maxSpinDuration = 5f;
    [SerializeField] float maxSpinAngle = -1200;
    [SerializeField] float minSpinAngle = -2000;
    public static Wheel instance { get; private set; }
    public enum SpinState { Idle, Spinning };
    public SpinState state;
    [SerializeField] private Button[] WheelNodes;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
        state = SpinState.Idle;
    }

    public void Spin()
    {
        if (state == SpinState.Spinning) return;

        state = SpinState.Spinning;
        foreach (Button node in WheelNodes)
        {
            node.interactable = false;
        }

        float spinningAngle = Random.Range(minSpinAngle, maxSpinAngle);
        float spinningDuration = Random.Range(minSpinDuration, maxSpinDuration);
        transform.DORotate(new Vector3(0, 0, spinningAngle), spinningDuration, RotateMode.FastBeyond360)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                state = SpinState.Idle;
            });
    }

    public IEnumerator Wait(float Duration)
    {
        yield return new WaitForSeconds(Duration);
    }

    public Action GetRandomAction()
    {
        return actions[Random.Range(0, actions.Length)];
    }
}
