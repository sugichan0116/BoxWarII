using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnduranceBehaviour : MonoBehaviour
{
    [SerializeField]
    private float health, robustness = 10;
    private Rigidbody2D rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        health = rigidbody.mass * robustness;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D opponent = collision.rigidbody;
        Vector2 velocity = ((opponent == null) ? Vector2.zero : opponent.velocity) - rigidbody.velocity;
        float impact = Mathf.Pow(velocity.magnitude, 2) * rigidbody.mass;
        Debug.Log(impact);
        health -= impact;

        if(health <= 0f) Destroy(gameObject);
    }
}
