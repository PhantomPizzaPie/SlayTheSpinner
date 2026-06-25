using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Collider2D))] // Ensures the node has a collider attached
public class WheelNode : MonoBehaviour
{
    private Button button;
    private Collider2D nodeCollider;
    private ContactFilter2D pointerFilter;

    // An array to temporarily hold any colliders we are touching
    private Collider2D[] overlapResults = new Collider2D[5];

    private void Awake()
    {
        button = GetComponent<Button>();
        nodeCollider = GetComponent<Collider2D>();
        button.interactable = false;

        // Set up the filter to ONLY look for objects tagged or layered as "Pointer"
        pointerFilter = new ContactFilter2D();
        pointerFilter.useTriggers = true; // We want to check triggers
    }

    private void Update()
    {
        if (Wheel.instance.state == Wheel.SpinState.Idle)
        {
            // FORCE Unity to update the physics position of this child element
            Physics2D.SyncTransforms();

            // Check how many pointer colliders are currently overlapping this node's collider
            int overlappingCount = nodeCollider.Overlap(pointerFilter, overlapResults);

            bool touchingPointer = false;

            // Loop through what we touched to verify it's a pointer
            for (int i = 0; i < overlappingCount; i++)
            {
                if (overlapResults[i] != null && overlapResults[i].CompareTag("Pointer"))
                {
                    touchingPointer = true;
                    break;
                }
            }

            // Toggle button interactability based on the real-time physics check
            if (touchingPointer)
            {
                if (!button.interactable)
                {
                    button.interactable = true;
                }
            }
            else
            {
                if (button.interactable)
                {
                    button.interactable = false;
                }
            }
        }
        else
        {
            if (button.interactable)
            {
                button.interactable = false;
            }
        }
    }
}