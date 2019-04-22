using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DropItemOnDestroy : BehaviourOnDestroy
{
    public ItemTable itemTable;
    private InventoryUnit inventory;
    
    void Start()
    {
        inventory = Builder.FindGameObject<InventoryUnit>("Inventory");
    }
    
    protected override void DoOnDestroy()
    {
        inventory.AddItem(itemTable.GetStatus());
    }
}
