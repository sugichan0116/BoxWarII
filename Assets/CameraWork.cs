using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraWork : MonoBehaviour
{
    public GameObject target;
    public float range = 1f;

    private Vector3 offset;

    void Start() => offset = transform.position - target.transform.position;

    void LateUpdate()
    {
        if (target == null) return;
        
        transform.position = target.transform.position + offset;
        //transform.position += CorrectionByOffset();

        //float effect = (NormalizedMouse() - new Vector2(.5f, .5f)).magnitude * 2;
        //effect = 1f + ((effect < 0.5) ? 0 : effect);
        //GetComponent<Camera>().orthographicSize = 5 * effect;
    }
    
    private Vector3 CorrectionByOffset()
    {
        Vector2 size = NormalizedMouse();
        size.x = p(size.x);
        size.y = p(size.y);

        return new Vector3(
            Mathf.Lerp(-range, range, size.x),
            Mathf.Lerp(-range * 1f, range, size.y)
            );
    }

    private Vector2 NormalizedMouse() => Input.mousePosition / new Vector2(Screen.width, Screen.height);

    private float p(float x) => (Mathf.Pow(x * 2 - 1, 5) + 1) / 2;
}