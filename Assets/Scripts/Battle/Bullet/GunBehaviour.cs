﻿using System.Collections;
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
    private bool IsInit = false;
    
    void Start() => Init();
    
    public bool Fire(Vector2 target)
    {
        if (Gun == null || Bullet == null) return false;

        if (fireTimer.IsReady())
        {
            foreach (var muzzle in gun.Muzzles)
            {
                BulletBehaviour bullet = Builder.Bullet(
                Bullet.prefabBullet,
                transform
                );

                Vector2 force = target.normalized * Gun.FiringSpeedRate * Bullet.FiringSpeed;
                float destruction = Bullet.prefabBullet.Destruction + gun.Destruction;

                bullet.Init(force, destruction);
                bullet.transform.position += new Vector3(muzzle.x, muzzle.y);
                bullet.gameObject.layer = LayerMask.NameToLayer(layer + "Bullet");
            }

            fireTimer.Reset();
            return true;
        }

        return false;
    }
    
    private void Refresh()
    {
        Init();
        GetComponent<SpriteRenderer>().sprite = Gun?.icon;

        if (Gun != null)
        {
            transform.localPosition = Gun.offset;
            if (Bullet != null)
            {
                fireTimer = GetComponent<Timer>().Init(Gun.CooltimeRate * Bullet.Cooltime);
            }
        }
    }

    private void Init()
    {
        if (IsInit) return;
        IsInit = true;

        fireTimer = GetComponent<Timer>().Init(0.3f);

        GetComponent<SpriteRenderer>().sprite = null;
        layer = LayerMask.LayerToName(gameObject.layer);
    }

    public Timer Cooltime() => fireTimer;
}
