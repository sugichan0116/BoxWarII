using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DropOnDestroy : BehaviourOnDestroy
{
    public EnduranceBody prefabItem;
    public ParticleSystem prefabSmoke;

    protected override void DoOnDestroy()
    {
        //drop item
        Builder.Block(
            prefabItem,
            transform.position,
            transform.rotation);
    }

    private Vector2 SpriteSize()
    {
        return GetComponent<SpriteRenderer>().bounds.size;
    }
}