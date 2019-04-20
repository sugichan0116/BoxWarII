using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    public BulletBehaviour prehabBullet;
    [SerializeField]
    private float firingSpeed = 100f;
    [SerializeField]
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
        if (prehabBullet != null && Input.GetMouseButtonDown(0) && phase >= cooltime)
        {
            phase = 0f;
            Vector2 playerPosition = RectTransformUtility.WorldToScreenPoint(
                Camera.main, transform.position);

            Builder.Bullet(
                transform,
                prehabBullet,
                firingSpeed,
                (Vector2)Input.mousePosition - playerPosition,
                firingOffset
                );
        }
        phase += Time.deltaTime;

    }
}
