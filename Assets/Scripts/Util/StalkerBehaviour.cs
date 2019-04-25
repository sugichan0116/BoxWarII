using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerBehaviour : MonoBehaviour
{
    public GameObject target;
    [SerializeField][Range(0f, 1f)]
    private float stalkingRate = 1f;
    public bool X = true, Y = true;
    private Vector3 offset;

    void Start () 
    {
        offset = transform.position - target.transform.position;
    }
    
    void LateUpdate () 
    {
        if (target == null) return;

        Vector3 position = 
                (target.transform.position + offset - transform.position) * stalkingRate;

        if (!X) position.x = 0f;
        if (!Y) position.y = 0f;

        transform.position += position;

        // = target + offset
    }
}
