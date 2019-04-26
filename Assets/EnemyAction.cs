using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    public List<BatteryBehaviour> batteries;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var battery in batteries)
        {
            battery.Play();
        }
    }
    
}
