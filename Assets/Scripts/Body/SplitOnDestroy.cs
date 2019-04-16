using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SplitOnDestroy : BehaviourOnDestroy
{
    public EnduranceBody prefabBody;
    public ParticleSystem prefabSmoke;

    protected override void DoOnDestroy()
    {
        //drop item
        Builder.Block(
            prefabBody,
            transform.position,
            transform.rotation);
    }

    private Vector2 SpriteSize()
    {
        return GetComponent<SpriteRenderer>().bounds.size;
    }
}