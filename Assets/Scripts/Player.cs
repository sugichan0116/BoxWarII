using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public BulletBehaviour prehabBullet;
    [SerializeField]
    private float firingSpeed = 100f;
    [SerializeField]
    private float cooltime = 0.3f;
    [SerializeField]
    private float movingSpeed = 10f;

    private float phase = 0f;
    private Vector2 firingOffset = new Vector2(0, 0.5f);
    private Rigidbody2D rigidbody2;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && phase >= cooltime)
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

    void FixedUpdate()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), 0f); //Input.GetAxis("Vertical"));

        rigidbody2.AddForce(input * movingSpeed);
    }
}
