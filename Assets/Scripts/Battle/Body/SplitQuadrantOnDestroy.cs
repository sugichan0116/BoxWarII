using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(EnduranceBody))]
public class SplitQuadrantOnDestroy : MonoBehaviour
{
    public EnduranceBody prefabBody;
    public ParticleSystem prefabSmoke;
    private bool isDestroy = false;

    private void Start()
    {
        GetComponent<EnduranceBody>().OnDestroy += DoOnDestroy;
    }

    private void DoOnDestroy()
    {
        if (isDestroy) return;
        isDestroy = true;

        Vector2 scale = SpriteSize() / (4 * Mathf.Sqrt(2));
        for (int i = 0; i < 4; i++)
        {
            EnduranceBody block = Builder.Block(prefabBody, transform);
            block.transform.position += Quaternion.Euler(0f, 0f, 90f * i) * scale;
        }

        if(prefabSmoke != null) Builder.Effecter(prefabSmoke, transform);
        
    }

    private Vector2 SpriteSize()
    {
        return GetComponent<SpriteRenderer>().bounds.size;
    }
}
