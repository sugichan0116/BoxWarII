using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CostManager))]
public class EquipGun : MonoBehaviour
{
    public GunBehaviour container;
    private CostManager costManager;

    public CellUnit cellBullet;
    public CellUnit cellGun;

    private StatusBullet bullet;
    private StatusGun gun;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("gun !!");
        costManager = GetComponent<CostManager>();

        if(costManager != null) costManager.OnEquip += isCost => {
            container.Bullet = (isCost) ? null : bullet;
            container.Gun = (isCost) ? null : gun;
        };

        cellBullet.OnChanged += item => {
            if (item == null)
            {
                this.bullet = null;
                return;
            }
            if (item.status is StatusBullet bullet) this.bullet = bullet;
            else this.bullet = null;
        };

        cellGun.OnChanged += item => {
            if (item == null)
            {
                this.gun = null;
                return;
            }
            if (item.status is StatusGun gun) this.gun = gun;
            else this.gun = null;
        };
    }
}
