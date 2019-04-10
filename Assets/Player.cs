using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D prehabBullet;
    [SerializeField]
    private float firingSpeed;
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
            FireBullet((Vector2)Input.mousePosition - RectTransformUtility.WorldToScreenPoint(Camera.main, transform.position));
        }
        phase += Time.deltaTime;
    }

    private void FireBullet(Vector2 direction)
    {
        direction *= firingSpeed / direction.magnitude;
        Rigidbody2D bullet = Instantiate(prehabBullet, transform.position + (Vector3)firingOffset, transform.rotation);
        bullet.AddForce(direction);
    }
}
