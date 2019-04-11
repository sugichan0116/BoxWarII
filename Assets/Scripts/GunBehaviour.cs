using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void FireBullet(Transform transform, BulletBehaviour prehabBullet, float speed, Vector2 direction, Vector2 firingOffset)
    {
        direction *= speed / direction.magnitude;
        BulletBehaviour bullet = Instantiate(prehabBullet, transform.position + (Vector3)firingOffset, transform.rotation);
        bullet.SetInitialVelocity(direction);
    }
}
