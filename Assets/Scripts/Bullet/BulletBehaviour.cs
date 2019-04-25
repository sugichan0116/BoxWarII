using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletBehaviour : MonoBehaviour
{
    public ParticleSystem prefabExplosion;
    protected Rigidbody2D rigidbody2;
    private Vector2 initialVelocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        rigidbody2.AddForce(initialVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Builder.Rotate(GetComponent<Rigidbody2D>().velocity);
    }

    public void Init(Vector2 force) => initialVelocity = force;

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (Builder.IsSameside(collision.collider.gameObject, gameObject)) return;
        
        Builder.Effecter(prefabExplosion, transform);
        Destroy(gameObject);
    }
}
