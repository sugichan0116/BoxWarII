using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    public CellUnit cellBullet;
    public CellUnit cellGun;
    public GunBehaviour container;

    // Start is called before the first frame update
    void Start()
    {
        cellBullet.OnChanged += item => {
            if (item.status is StatusBullet bullet) container.Bullet = bullet;
            else container.Bullet = null;
        };

        cellGun.OnChanged += item => {
            if (item.status is StatusGun gun) container.Gun = gun;
            else container.Bullet = null;
        };
    }

}
