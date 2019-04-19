using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    public CellUnit cell;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cell.item == null) return;
        player.prehabBullet = cell.item.status.prefabBullet;
    }

    
}
