using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryBehaviour : MonoBehaviour
{
    public StatusGun gun;
    public StatusBullet bullet;
    public List<Vector2> directions;

    private Vector2 direction = new Vector2(-1, 1);
    private int index = 0;
    private bool IsPlayed = false;
    private GunBehaviour battery;

    // Start is called before the first frame update
    void Start()
    {
        battery = GetComponentInChildren<GunBehaviour>();

    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlayed)
        {
            bool IsFired = battery.Fire(direction);
            if(IsFired) Transition();
        }
    }

    private void Transition()
    {
        direction = directions[(int)Mathf.PingPong(++index, directions.Count - 1)];
        transform.rotation = Builder.Rotate(direction);
    }

    public void Play()
    {
        IsPlayed = true;
        Init();
    }

    private void Init()
    {
        Debug.Log("Battery @@@@@@: " + battery + "/" + this);
        battery.Bullet = bullet;
        battery.Gun = gun;
    }
}
