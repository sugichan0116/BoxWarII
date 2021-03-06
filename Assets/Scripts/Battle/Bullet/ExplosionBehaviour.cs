﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ExplosionBehaviour : MonoBehaviour
{
    private Rigidbody2D rigidbody2;
    private bool isExplosion;
    [SerializeField]
    private float destruction = 100f;
    [SerializeField]
    private float strongth = 100f;
    [SerializeField]
    private float radius = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        isExplosion = false;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(isExplosion) return;

        isExplosion = true;
        foreach(Collider2D collider in 
            Physics2D.OverlapCircleAll(transform.position, radius))
        {
            Rigidbody2D other = collider.gameObject.GetComponent<Rigidbody2D>();
                
            if(other == null || transform.position == null) continue;
            other.AddExplosionForce(strongth, transform.position, radius);
            other.gameObject.GetComponent<EnduranceBody>()?.Impact(destruction);
        }
    }

    public string Text()
    {
        return $"属性 : 爆発 \n" +
            $"　破壊力 : + {destruction} \n" +
            $"　爆風 : {strongth} m/sec \n" +
            $"　範囲 : {radius} m \n";
    }
}
