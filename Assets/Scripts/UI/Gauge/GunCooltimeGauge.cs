using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GaugeBehaviour))]
public class GunCooltimeGauge : MonoBehaviour
{
    public GunBehaviour target;
    private GaugeBehaviour gauge;

    // Start is called before the first frame update
    void Start()
    {
        gauge = GetComponent<GaugeBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        gauge.Title(
            $"Cooltime | " +
            $"{(int)(target.Cooltime().Now / target.Cooltime().Timeout * 100)}" +
            $" % "
            );
        gauge.Rate(1 - target.Cooltime().Now / target.Cooltime().Timeout);
    }
}
