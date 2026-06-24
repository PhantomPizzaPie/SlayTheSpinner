using UnityEngine;
using UnityEngine.UI;

public class NonRectangleButton : MonoBehaviour
{
    void Start()
    {
        ((Image)GetComponent("Image")).alphaHitTestMinimumThreshold = 0.1f;
    }

}
