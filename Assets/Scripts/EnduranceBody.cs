using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnduranceBody : MonoBehaviour
{
    [SerializeField]
    protected float robustness = 10;
    private float health;
    private Rigidbody2D rigidbody2;

    protected void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        health = rigidbody2.mass * Mathf.Pow(robustness, 2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == gameObject.tag) return;

        Rigidbody2D opponent = collision.rigidbody;
        Vector2 velocity = ((opponent == null) ? Vector2.zero : opponent.velocity) - rigidbody2.velocity;
        float impact = Mathf.Pow(velocity.magnitude, 2) * rigidbody2.mass;
        
        //Debug.Log(impact);
        health -= impact;

        if (health <= 0f) Destruction();
    }

    protected virtual void Destruction()
    {
        Destroy(gameObject);
    }

}
