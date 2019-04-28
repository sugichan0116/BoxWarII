using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(EnduranceBody))]
public class DropItemOnDestroy : MonoBehaviour
{
    public ItemTable itemTable;
    private InventoryUnit inventory;

    private bool isDestroy = false;

    void Start()
    {
        GetComponent<EnduranceBody>().OnDestroy += DoOnDestroy;
        inventory = Builder.FindGameObject<InventoryUnit>("Inventory");
    }
    
    private void DoOnDestroy()
    {
        if (isDestroy) return;
        isDestroy = true;

        ItemUnit item = itemTable.GetItem();
        inventory.AddItem(item);
        Destroy(item.gameObject);//つらい
    }
}
