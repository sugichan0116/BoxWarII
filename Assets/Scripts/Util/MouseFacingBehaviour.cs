﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFacingBehaviour : MonoBehaviour
{
    public bool X, Y, Z;
    public Vector3 flip = new Vector3(1, 1, 1);
    private Vector3 init;

    // Start is called before the first frame update
    void Start()
    {
        init = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPosition = RectTransformUtility
            .WorldToScreenPoint(Camera.main, transform.position);
        Vector2 mouse = (Vector2)Input.mousePosition - playerPosition;

        transform.rotation = Builder.Rotate(mouse);

        if(CameraWork.NormalizedMouse().x < .4f) flip = new Vector3((X)?-1:1, (Y)?-1:1, (Z)?-1:1);
        else flip = new Vector3(1, 1, 1);
        transform.localPosition = new Vector3(init.x * flip.x, init.y * flip.y, init.z * flip.z);
    }
}
