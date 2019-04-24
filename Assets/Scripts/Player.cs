using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private float movingSpeed = 1f;
    public GunBehaviour gunContainer;
    public string groundTag = "Ground";
    public int maxJump = 2;
    private int jump = 0;
    private float jumpInterval = 0.3f;
    private float jumpTime = 0f;

    private Rigidbody2D rigidbody2;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        jumpTime += Time.deltaTime;
    }

    void FixedUpdate()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), 0f); //Input.GetAxis("Vertical"));

        if(jump < maxJump && jumpTime > jumpInterval && (Input.GetButtonDown("Jump") || Input.GetAxis("Vertical") > 0f))
        {
            input.y += 20f;
            jump++;
            jumpTime = 0;
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
