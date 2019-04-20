using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    public CellUnit cellBullet;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cellBullet.item == null) return;
        if (cellBullet.item.status is StatusBullet bullet)
        {
            player.gun.prehabBullet = bullet.prefabBullet;
        }
    }

    
}
