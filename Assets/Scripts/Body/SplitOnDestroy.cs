using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitOnDestroy : BehaviourOnDestroy
{
    public EnduranceBody prefabBody;
    public ParticleSystem prefabSmoke;

    protected override void DoOnDestroy()
    {
        Builder.Block(prefabBody, transform);

        if (prefabSmoke != null) Builder.Effecter(prefabSmoke, transform);
    }
}