﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class QuadrantBody : EnduranceBody
{
    public EnduranceBody prefabBody;
    public ParticleSystem prefabSmoke;

    private bool isSplit = false;

    protected override void Destruction()
    {
        if (isSplit) return;
        Debug.Log("** " + transform.localScale + "." + transform.position + "/" + SpriteSize());

        Vector2 scale = SpriteSize() / (4 * Mathf.Sqrt(2));
        for (int i = 0; i < 4; i++)
        {
            Builder.Block(
                prefabBody,
                transform.position + Quaternion.Euler(0f, 0f, 90f * i) * scale,
                transform.rotation);
        }

        if(prefabSmoke != null) Builder.Effecter(prefabSmoke, transform);

        isSplit = true;

        Destroy(gameObject);
    }

    private Vector2 SpriteSize()
    {
        return GetComponent<SpriteRenderer>().bounds.size;
    }
}