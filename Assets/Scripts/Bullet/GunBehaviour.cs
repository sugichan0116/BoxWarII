using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Timer))]
public class GunBehaviour : MonoBehaviour
{
    private StatusGun gun;
    private StatusBullet bullet;

    private Timer fireTimer;
    private Vector2 firingOffset = new Vector2(0f, 0f);

    public StatusGun Gun { get => gun; set { gun = value; UpdateEquip(); } }
    public StatusBullet Bullet { get => bullet; set { bullet = value; UpdateEquip(); } }

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
        if (Gun == null || Bullet == null) return;
        
        if (Input.GetMouseButtonDown(0) && fireTimer.IsReady())
        {

            Vector2 playerPosition = RectTransformUtility
                .WorldToScreenPoint(Camera.main, transform.position);
            Vector2 mouse = (Vector2)Input.mousePosition - playerPosition; //for enemy : player
            
            Builder.Bullet(
                transform,
                Bullet.prefabBullet,
                Gun.FiringSpeedRate * Bullet.FiringSpeed,
                mouse,
                firingOffset, //gun.firingOffsetにしたい
                LayerMask.LayerToName(gameObject.layer) + "Bullet"
                );

            fireTimer.Reset();
        }

    }
    
    private void UpdateEquip()
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
}
