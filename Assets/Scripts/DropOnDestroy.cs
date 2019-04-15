using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DropOnDestroy : BehaviourOnDestroy
{
    public EnduranceBody prefabBody;
    public ParticleSystem prefabSmoke;

    protected override void DoOnDestroy()
    {
        //drop item
        Builder.Block(
            prefabBody,
            transform.position + Quaternion.Euler(0f, 0f, 90f * i) * scale,
            transform.rotation);

        if(prefabSmoke != null) Builder.Effecter(prefabSmoke, transform);
    }

    private Vector2 SpriteSize()
    {
        return GetComponent<SpriteRenderer>().bounds.size;
    }
}