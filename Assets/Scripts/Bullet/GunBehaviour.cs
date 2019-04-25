using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Timer))]
public class GunBehaviour : MonoBehaviour
{
    public StatusGun gun;
    public StatusBullet bullet;

    private Timer fireTimer;
    private float firingSpeed = 100f;
    private Vector2 firingOffset = new Vector2(0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        fireTimer = GetComponent<Timer>();
        fireTimer.Init(0.3f);

        GetComponent<SpriteRenderer>().sprite = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (gun == null || bullet == null) return;

        if (Input.GetMouseButtonDown(0) && fireTimer.IsReady())
        {
            Vector2 playerPosition = RectTransformUtility
                .WorldToScreenPoint(Camera.main, transform.position);
            Vector2 mouse = (Vector2)Input.mousePosition - playerPosition; //for enemy : player
            
            Builder.Bullet(
                transform,
                bullet.prefabBullet,
                firingSpeed,
                mouse,
                firingOffset,
                LayerMask.LayerToName(gameObject.layer) + "Bullet"
                );

            fireTimer.Reset();
        }

    }

    public void Gun(StatusGun _gun) {
        gun = _gun;
        UpdateEquip();
    }

    public void Bullet(StatusBullet _bullet) {
        bullet = _bullet;
        UpdateEquip();
    }

    private void UpdateEquip() {
        //一度だけでいい
        transform.localPosition = gun.offset;
        firingSpeed = gun.FiringSpeedRate * bullet.FiringSpeed;
        fireTimer.Init(gun.CooltimeRate * bullet.Cooltime);

        GetComponent<SpriteRenderer>().sprite = (gun == null) ? null : gun.icon;
        
    }
}
