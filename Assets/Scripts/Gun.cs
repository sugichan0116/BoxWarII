using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Explosion(ParticleSystem prefabExplosion, Transform transform)
    {
        Instantiate(prefabExplosion, transform.position, transform.rotation);
    }

    public static void FireBullet(Transform transform, BulletBehaviour prefabBullet, float speed, Vector2 direction, Vector2 firingOffset)
    {
        direction *= speed / direction.magnitude;
        BulletBehaviour bullet = Instantiate(prefabBullet, transform.position + (Vector3)firingOffset, transform.rotation);
        bullet.SetInitialVelocity(direction);
    }
}
