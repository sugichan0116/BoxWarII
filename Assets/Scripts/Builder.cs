using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Builder : MonoBehaviour
{
    private static GameObject poolFX;
    private static string nameFX = "FX Pool";

    private static GameObject poolBullet;
    private static string nameBullet = "Bullet Pool";

    private static GameObject poolBlock;
    private static string nameBlock = "Block Pool";
    
    public static Quaternion Rotate(Vector2 a)
    {
        return Quaternion.Euler(0f, 0f, AngleBetween(Vector2.zero, a));
    }

    public static float AngleBetween(Vector2 from, Vector2 to)
    {
        float dx = to.x - from.x;
        float dy = to.y - from.y;
        float rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    }

    public static bool IsSameside(GameObject a, GameObject b)
    {//collision.collider.gameObject.layer != gameObject.layer
        return false;
        //return a.layer == b.layer;//collision.collider.gameObject.tag == gameObject.tag;
    }

    public static T FindGameObject<T>(string Tag)
    {
        return GameObject.FindGameObjectsWithTag(Tag)
             .FirstOrDefault(value => value.GetComponent<T>() != null)
            .GetComponent<T>();
    }

    public static void Block(EnduranceBody prefabBody, Vector2 position, Quaternion rotation)
    {
        if (poolBlock == null) poolBlock = GameObject.Find(nameBlock);

        EnduranceBody body = Instantiate(prefabBody, position, rotation);
        body.transform.parent = poolBlock.transform;
    }

    public static void Effecter(ParticleSystem prefabExplosion, Transform transform)
    {
        if(poolFX == null) poolFX = GameObject.Find(nameFX);

        ParticleSystem particle = Instantiate(prefabExplosion, transform.position, transform.rotation);
        particle.transform.parent = poolFX.transform;
    }

    public static void Bullet(Transform transform, 
        BulletBehaviour prefabBullet, float speed, Vector2 direction, 
        Vector2 firingOffset, string newLayer)
    {
        if (poolBullet == null) poolBullet = GameObject.Find(nameBullet);

        direction *= speed / direction.magnitude;
        BulletBehaviour bullet = Instantiate(
            prefabBullet, 
            transform.position + (Vector3)firingOffset, 
            transform.rotation
            );

        bullet.transform.parent = poolBullet.transform;
        bullet.SetInitialVelocity(direction);
        bullet.gameObject.layer = LayerMask.NameToLayer(newLayer);
    }
}
