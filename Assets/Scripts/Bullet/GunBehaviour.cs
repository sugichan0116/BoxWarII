using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class GunBehaviour : MonoBehaviour
{
    public StatusGun gun;
    public StatusBullet bullet;

    private float firingSpeed = 100f;
    private float cooltime = 0.3f;
    private float phase = 0f;
    private Vector2 firingOffset = new Vector2(0f, 0f);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gun == null || bullet == null) return;

        //一度だけでいい
        transform.localPosition = gun.offset;
        cooltime = gun.CooltimeRate * bullet.Cooltime;
        firingSpeed = gun.FiringSpeedRate * bullet.FiringSpeed;

        if (Input.GetMouseButtonDown(0) && phase >= cooltime)
        {
            Vector2 playerPosition = RectTransformUtility
                .WorldToScreenPoint(Camera.main, transform.position);
            Vector2 mouse = (Vector2)Input.mousePosition - playerPosition;
            
            Builder.Bullet(
                transform,
                bullet.prefabBullet,
                firingSpeed,
                mouse,
                firingOffset,
                LayerMask.LayerToName(gameObject.layer) + "Bullet"
                );

            phase = 0f;
        }
        phase += Time.deltaTime;

    }

    private void FixedUpdate()
    {
        GetComponent<SpriteRenderer>().sprite = (gun == null) ? null : gun.icon;
    }
}
