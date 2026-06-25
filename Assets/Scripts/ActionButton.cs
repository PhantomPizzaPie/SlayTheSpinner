using TMPro;
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
        image.sprite = action.actionDetails.sprite;
        image.color = action.actionDetails.backgroundColor;

        Transform textTransform = transform.Find("luckFactorText");
        TextMeshProUGUI textComponent = textTransform.GetComponent<TextMeshProUGUI>();

        textComponent.text = action.luckFactor.ToString();
    }
    void OnTriggerExit2D()
    {
        ChangeAction();
    }

    public void OnClick()
    {
        action.actionDetails.Act(action.luckFactor);
    }
}
