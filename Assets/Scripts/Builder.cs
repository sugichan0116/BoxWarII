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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        BulletBehaviour prefabBullet, float speed, Vector2 direction, Vector2 firingOffset)
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
    }
}
