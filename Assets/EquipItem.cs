using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItem : MonoBehaviour
{
    public CellUnit cellItem;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = Builder.FindGameObject<Player>("Player");

        cellItem.OnChanged += value => {
            if (value == null) return;

            if (value.status is StatusItem item)
            {
                player.UseItem(item);
                cellItem.OnUsed();
            }
        };
    }
}
