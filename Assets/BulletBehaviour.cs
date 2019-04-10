using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("" + Vector2.Angle(Vector2.zero, rigidbody.velocity) + "/" + rigidbody.velocity);
        transform.rotation = Quaternion.Euler(0f, 0f, angleBetween(Vector2.zero, rigidbody.velocity) );
    }

    private void OnCollisionEnter2D(Collision2D collision)
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
