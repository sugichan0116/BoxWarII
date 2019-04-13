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
        transform.rotation = Quaternion.Euler(
            0f, 0f, AngleBetween(Vector2.zero, GetComponent<Rigidbody2D>().velocity) 
            );
    }

    public void SetInitialVelocity(Vector2 force) => initialVelocity = force;

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag != gameObject.tag) {
            Builder.Effecter(prefabExplosion, transform);
            Destroy(gameObject);
        }

        if(collision.rigidbody == null) Destroy(gameObject);
    }

    private float AngleBetween(Vector2 from, Vector2 to)
    {
        float dx = to.x - from.x;
        float dy = to.y - from.y;
        float rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    } 
}
