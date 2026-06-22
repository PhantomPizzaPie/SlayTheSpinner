using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Pointer : MonoBehaviour
{
    void Awake()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
    }
}