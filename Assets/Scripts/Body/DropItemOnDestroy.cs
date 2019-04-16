using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DropItemOnDestroy : BehaviourOnDestroy
{
    public ItemUnit item;
    private InventoryUnit inventory;
    
    void Start()
    {
        inventory = GameObject.FindGameObjectsWithTag("Inventory")
            .FirstOrDefault(value => value.GetComponent<InventoryUnit>() != null)
            .GetComponent<InventoryUnit>();
    }
    
    protected override void DoOnDestroy()
    {
        inventory.AddItem(item);
    }
}
