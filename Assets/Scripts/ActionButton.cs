using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
    [SerializeField] Wheel wheel;
    Action action;

    void ChangeAction()
    {
        SetAction(wheel.GetRandomAction());
    }
    public void Start()
    {
        ChangeAction();
    }
    public void SetAction(Action action)
    {
        this.action = action;

        Image image = (Image)GetComponent("Image");
        image.sprite = action.sprite;
        image.color = action.backgroundColor;
    }
    void OnTriggerExit2D()
    {
        ChangeAction();
    }

    public void OnClick()
    {
        action.Act();
    }
}
