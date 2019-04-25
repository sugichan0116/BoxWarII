using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Timer))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private float movingSpeed = 1f;
    public GunBehaviour gunContainer;
    public string groundTag = "Ground";
    public int maxJump = 2;
    private int jump = 0;
    private Timer jumpTimer;

    private Rigidbody2D rigidbody2;

    // Start is called before the first frame update
    void Start()
    {
        jumpTimer = GetComponent<Timer>();
        jumpTimer.Init(0.3f);

        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), 0f); //Input.GetAxis("Vertical"));

        if(jump < maxJump && jumpTimer.IsReady() && (Input.GetButtonDown("Jump") || Input.GetAxis("Vertical") > 0f))
        {
            input.y += 20f;
            jump++;
            jumpTimer.Reset();
        }

        rigidbody2.AddForce(input * movingSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == groundTag)
        {
            jump = 0;
        }
    }
}
