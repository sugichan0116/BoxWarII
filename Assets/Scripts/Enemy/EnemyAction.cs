using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    public List<BatteryBehaviour> batteries;
    public float eyesight = 10f;
    private Player player;
    private bool isFind = false;

    // Start is called before the first frame update
    void Start()
    {
        player = Builder.FindGameObject<Player>("Player");
    }

    private void Update()
    {
        bool now = IsFound();
        if(now != isFind)
        {
            isFind = now;
            if (isFind) OnFind();
            else OnLost();
        }

    }

    private bool IsFound()
    {
        Vector2 position = player.transform.position - transform.position;
        if (position.magnitude > eyesight) return false;

        int layerMask = 1 << LayerMask.NameToLayer("Ground");
        return !Physics2D.Raycast(transform.position, position, position.magnitude, layerMask);
    }

    private void OnFind()
    {
        foreach (var battery in batteries)
        {
            battery.Play();
        }
    }

    private void OnLost()
    {
        foreach (var battery in batteries)
        {
            battery.Stop();
        }
    }
    
}
