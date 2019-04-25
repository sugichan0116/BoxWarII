using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ExplosionBehaviour : MonoBehaviour
{
    private Rigidbody2D rigidbody2;
    private bool isExplosion;
    [SerializeField]
    private float strongth = 1000f;
    [SerializeField]
    private float radius = 100f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        isExplosion = false;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(isExplosion) return;
        if (Builder.IsSameside(collision.collider.gameObject, gameObject)) return;

        isExplosion = true;
        foreach(Collider2D collider in 
            Physics2D.OverlapCircleAll(transform.position, radius))
        {
            Rigidbody2D other = collider.gameObject.GetComponent<Rigidbody2D>();
                
            if(other == null || transform.position == null) continue;
            other.AddExplosionForce(strongth, transform.position, radius);
        }
    }

    public string Text()
    {
        return $"属性 : 爆発 \n" +
            $"　強さ : {strongth} \n" +
            $"　範囲 : {radius} \n";
    }
}
