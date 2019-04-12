using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBehaviour : MonoBehaviour
{
    [SerializeField]
    private BulletBehaviour prefabBullet;
    [SerializeField]
    private ParticleSystem prefabExplosion;

    [SerializeField]
    private int innerBullet = 2;
    [SerializeField]
    private float timeSplit = 1f;
    [SerializeField]
    private float errorAngle = 30f;
    [SerializeField]
    private float accelerationRate = 1f;
    private Rigidbody2D rigidbody2;

    private void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        Invoke("Split", timeSplit);
    }

    private void Split()
    {
        for (int i = 0; i < innerBullet; i++)
        {
            Vector2 direction = Direction(i, innerBullet);

            Gun.FireBullet(
                transform,
                prefabBullet,
                rigidbody2.velocity.magnitude * accelerationRate,
                direction,
                Vector2.zero //direction.normalized
                );

            Gun.DeployEffect(prefabExplosion, transform);
        }

        Destroy(gameObject);
    }

    protected Vector2 Direction(int index, int entire)
    {
        return Quaternion.Euler(0, 0, Random.Range(-errorAngle, errorAngle))
             * rigidbody2.velocity.normalized;
    }
}
