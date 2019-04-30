using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWork : MonoBehaviour
{
    public GameObject target;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - target.transform.position;
    }

    void LateUpdate()
    {
        if (target == null) return;
        
        Vector3 look = Vector3.zero;
        float height = Input.mousePosition.y / Screen.height;
        look.y = Mathf.Lerp(-1, 2, height);

        transform.position = target.transform.position + offset + look;

        // = target + offset
    }
}