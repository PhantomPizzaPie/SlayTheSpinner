using UnityEngine;
using UnityEngine.UI;

public class WheelNode : MonoBehaviour
{
    [SerializeField] private GameObject[] pointers; 
    private void Update()
    {
        if (Wheel.instance.state == Wheel.SpinState.Idle) 
        {
            foreach (GameObject pointer in pointers) 
            {
                if (GetScreenRect(this.GetComponent<RectTransform>()).Overlaps(GetScreenRect(pointer.GetComponent<RectTransform>())))
                {
                    this.GetComponent<Button>().interactable = true;
                    return;
                }
            }
        }
    }
    private Rect GetScreenRect(RectTransform rectTransform)
    {
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);
        return new Rect(corners[0], corners[2] - corners[0]);
    }
}
