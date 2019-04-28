using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Timer))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Vector2 move = new Vector2(4f, 100f);
    [SerializeField]
    int maxJump = 2;
    public float jumpInterval = 0.2f;
    public float maxSpeed = 10f;
    
    private Counter jumpCounter;
    private Timer jumpTimer;

    private List<string> groundTags = new List<string>{ "Ground", "Enemy" };
    private Rigidbody2D rigidbody2;

    // Start is called before the first frame update
    void Start()
    {
        jumpCounter = new Counter(maxJump);
        jumpTimer = GetComponent<Timer>().Init(jumpInterval);

        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() => Move();

    private void Move()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal") * move.x, 0f);

        if (jumpCounter.HaveRoom() && jumpTimer.IsReady() && (Input.GetButtonDown("Jump")))
        {
            input.y = move.y;
            jumpCounter.Count();
            jumpTimer.Reset();
        }

        rigidbody2.AddForce(input);
        rigidbody2.velocity = Vector3.ClampMagnitude(rigidbody2.velocity, maxSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (groundTags.Contains(collision.collider.gameObject.tag))
        {
            jumpCounter.Reset();
        }
    }
}

public class Counter
{
    int count, maxCount;

    public Counter(int max) => maxCount = max;

    public void Count() => count++;

    public bool HaveRoom() => count < maxCount;

    public void Reset() => count = 0;
}
