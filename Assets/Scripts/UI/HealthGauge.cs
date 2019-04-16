using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GaugeBehaviour))]
public class HealthGauge : MonoBehaviour
{
    public EnduranceBody target;
    private GaugeBehaviour gauge;

    // Start is called before the first frame update
    void Start()
    {
        gauge = GetComponent<GaugeBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        gauge.Title($"Health | {(int)target.Health()} / {(int)target.MaxHealth()}");
        gauge.Rate(target.Health() / target.MaxHealth());
    }
}
