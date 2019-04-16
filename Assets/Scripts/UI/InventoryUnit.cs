using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DummyControlUnit))]
public class InventoryUnit : MonoBehaviour
{
    private DummyControlUnit unit;

    // Start is called before the first frame update
    void Start()
    {
        unit = GetComponent<DummyControlUnit>();
    }

    public void AddItem(ItemUnit item)
    {
        Debug.Log(item.Item());
        //wrapper class : Item Unit (Drag And Drop Item)
        //unit.RemoveFirstItem();
        unit.AddItemInFreeCell(item.Item());
    }
}
