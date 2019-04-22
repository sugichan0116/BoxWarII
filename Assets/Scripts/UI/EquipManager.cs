using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    public CellUnit cellBullet;
    public CellUnit cellGun;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EquipBullet();
        EquipGun();
    }

    void EquipBullet()
    {
        if (cellBullet.item == null) player.gunContainer.bullet = null;
        else if (cellBullet.item.status is StatusBullet bullet)
        {
            player.gunContainer.bullet = bullet;
        }
    }

    void EquipGun()
    {
        if (cellGun.item == null) player.gunContainer.gun = null;
        else if (cellGun.item.status is StatusGun gun)
        {
            player.gunContainer.gun = gun;
        }
    }


}
