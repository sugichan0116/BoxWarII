using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class GunBehaviour : MonoBehaviour
{
    private BulletBehaviour prefabBullet;
    public StatusGun gun;
    public StatusBullet bullet;

    private float firingSpeed = 100f;
    private float cooltime = 0.3f;
    private float phase = 0f;
    private Vector2 firingOffset = new Vector2(1f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gun == null || bullet == null) return;

        prefabBullet = bullet.prefabBullet;
        cooltime = gun.CooltimeRate * bullet.Cooltime;
        firingSpeed = gun.FiringSpeedRate * bullet.FiringSpeed;

        if (Input.GetMouseButtonDown(0) && phase >= cooltime)
        {
            phase = 0f;
            Vector2 playerPosition = RectTransformUtility.WorldToScreenPoint(
                Camera.main, transform.position);

            Builder.Bullet(
                transform,
                prefabBullet,
                firingSpeed,
                (Vector2)Input.mousePosition - playerPosition,
                firingOffset
                );
        }
        phase += Time.deltaTime;

    }

    private void FixedUpdate()
    {
        GetComponent<SpriteRenderer>().sprite = (gun == null) ? null : gun.icon;
    }
}
