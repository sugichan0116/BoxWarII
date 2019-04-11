using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
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
        transform.rotation = Quaternion.Euler(0f, 0f, angleBetween(Vector2.zero, GetComponent<Rigidbody2D>().velocity) );
    }

    public void SetInitialVelocity(Vector2 force) => initialVelocity = force;

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.rigidbody == null) Destroy(gameObject);
    }

    private float angleBetween(Vector2 a, Vector2 b)
    {
        float dx = b.x - a.x;
        float dy = b.y - a.y;
        float rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    } 
}
