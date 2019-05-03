using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFlip : MonoBehaviour
{
    public bool X, Y, Z;
    public Vector3 flip = new Vector3(1, 1, 1);
    private Vector3 init;

    // Start is called before the first frame update
    void Start()
    {
        init = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(CameraWork.NormalizedMouse().x < .4f) flip = new Vector3((X)?-1:1, (Y)?-1:1, (Z)?-1:1);
        else flip = new Vector3(1, 1, 1);
        transform.localScale = new Vector3(init.x * flip.x, init.y * flip.y, init.z * flip.z);
    }
}
