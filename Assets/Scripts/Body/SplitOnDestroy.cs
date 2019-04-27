using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnduranceBody))]
public class SplitOnDestroy : MonoBehaviour
{
    public EnduranceBody prefabBody;
    public ParticleSystem prefabSmoke;

    private void Start()
    {
        GetComponent<EnduranceBody>().OnDestroy += DoOnDestroy;
    }

    private void DoOnDestroy()
    {
        Builder.Block(prefabBody, transform);

        if (prefabSmoke != null) Builder.Effecter(prefabSmoke, transform);
    }
}