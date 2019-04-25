using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerBehaviour : MonoBehaviour
{
    public GameObject target;
    [SerializeField]
    private float stalkingRate = 1f;
    private Vector3 offset;

    void Start () 
    {
        offset = transform.position - target.transform.position;
    }
    
    void LateUpdate () 
    {
        if (target == null) return;

        transform.position += (target.transform.position + offset - transform.position) * stalkingRate;
        // = target + offset
    }
}
