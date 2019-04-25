using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Timer))]
public class GunBehaviour : MonoBehaviour
{
    private StatusGun gun;
    private StatusBullet bullet;
    public StatusGun Gun { get => gun; set { gun = value; Refresh(); } }
    public StatusBullet Bullet { get => bullet; set { bullet = value; Refresh(); } }

    private Timer fireTimer;

    private string layer;
    
    // Start is called before the first frame update
    void Start()
    {
        fireTimer = GetComponent<Timer>();
        fireTimer.Init(0.3f);

        GetComponent<SpriteRenderer>().sprite = null;
        layer = LayerMask.LayerToName(gameObject.layer);
    }
    
    public void Fire(Vector2 target)
    {
        if (Gun == null || Bullet == null) return;

        if (fireTimer.IsReady())
        {
            BulletBehaviour bullet = Builder.Bullet(
                Bullet.prefabBullet,
                transform
                );

            bullet.Init(target.normalized * Gun.FiringSpeedRate * Bullet.FiringSpeed);
            bullet.gameObject.layer = LayerMask.NameToLayer(layer + "Bullet");
            
            fireTimer.Reset();
        }
    }
    
    private void Refresh()
    {
        GetComponent<SpriteRenderer>().sprite = Gun?.icon;

        if(Gun != null)
        {
            transform.localPosition = Gun.offset;
            if (Bullet != null)
            {
                fireTimer.Init(Gun.CooltimeRate * Bullet.Cooltime);
            }
        }
    }

    public Timer Cooltime() => fireTimer;
}
