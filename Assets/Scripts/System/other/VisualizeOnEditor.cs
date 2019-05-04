using UnityEngine;

public class VisualizeOnEditor : MonoBehaviour
{
    void OnDrawGizmos()
    {
        // Draws the Light bulb icon at position of the object.
        // Because we draw it inside OnDrawGizmos the icon is also pickable
        // in the scene view.

        Gizmos.DrawIcon(transform.position, "Event.png", true);
    }
}
