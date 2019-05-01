using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipAutoRepair : MonoBehaviour
{
    public CellUnit cellItem;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = Builder.FindGameObject<Player>("Player");
    }

    private void Update()
    {
        if (cellItem.Item() == null) return;

        if (cellItem.Item().status is StatusItem item)
        {
            if(item.Type == ItemAttribute.Repair)
            {
                if (player.GetComponent<EnduranceBody>().Health() <= item.strongth)
                {
                    player.UseItem(item);
                    cellItem.OnUsed();
                }
            }
        }
        
    }
}
