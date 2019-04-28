using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBehaviour : MonoBehaviour
{
    public BulletBehaviour prefabBullet;
    public ParticleSystem prefabExplosion;

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

            BulletBehaviour bullet = Builder.Bullet(prefabBullet, transform);

            float speed = rigidbody2.velocity.magnitude * accelerationRate;
            bullet.Init(direction.normalized * speed, prefabBullet.Destruction);
            bullet.gameObject.layer = gameObject.layer;
            
            Builder.Effecter(prefabExplosion, transform);
        }

        Destroy(gameObject);
    }

    protected Vector2 Direction(int index, int entire)
    {
        return Quaternion.Euler(0, 0, Random.Range(-errorAngle, errorAngle))
             * rigidbody2.velocity.normalized;
    }
    
    public string Text()
    {
        return $"属性 : 分裂 \n" +
            $"　内部弾 : x {innerBullet} \n" +
            $"　分裂加速率 : x {accelerationRate} \n" +
            $"　誤差角 : ±{errorAngle}° \n";
    }
}
