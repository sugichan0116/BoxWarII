using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletBehaviour : MonoBehaviour
{
    public ParticleSystem prefabExplosion;
    [SerializeField]
    private float destruction = 10f;
    
    private Rigidbody2D rigidbody2;
    private Vector2 initialVelocity = Vector2.zero;

    public float Destruction { get => destruction; private set => destruction = value; }

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

    public void Init(Vector2 force, float destruct)
    {
        initialVelocity = force;
        destruction = destruct;
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        EnduranceBody body = collision.collider.gameObject.GetComponent<EnduranceBody>();
        body?.Impact(KineticEnergy());

        Builder.Effecter(prefabExplosion, transform);
        Destroy(gameObject);
    }

    public float KineticEnergy() => destruction;// * Mathf.Pow(rigidbody2.velocity.magnitude, 2);
}
