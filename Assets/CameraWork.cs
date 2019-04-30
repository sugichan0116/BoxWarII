using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWork : MonoBehaviour
{
    public GameObject target;
    public float range = 1f;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - target.transform.position;
    }

    void LateUpdate()
    {
        if (target == null) return;
        
        Vector2 size = Input.mousePosition / new Vector2(Screen.width, Screen.height);
        size.x = p(size.x);
        size.y = p(size.y);
        Vector3 look = new Vector3(
            Mathf.Lerp(-range, range, size.x),
            Mathf.Lerp(-range * 1f, range, size.y)
            );

        transform.position = target.transform.position + offset + look;

        // = target + offset
    }

    private float p(float x)
    {
        return (Mathf.Pow(x * 2 - 1, 3) + 1) / 2;
    }
}