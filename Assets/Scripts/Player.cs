using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public BulletBehaviour prehabBullet;
    [SerializeField]
    private float firingSpeed = 1f;
    private float cooltime = 0.3f, phase = 0f;
    private Vector2 firingOffset = new Vector2(0, 0.5f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && phase >= cooltime)
        {
            phase = 0f;
            Vector2 playerPosition = RectTransformUtility.WorldToScreenPoint(Camera.main, transform.position);
            GunBehaviour.FireBullet(
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
