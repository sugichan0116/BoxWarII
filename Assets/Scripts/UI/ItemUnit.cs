using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(DragAndDropItem))]
public class ItemUnit : MonoBehaviour
{
    public Status status;

    private void Start()
    {
        GetComponent<Image>().sprite = status.icon;
        DragAndDropItem.OnItemDragEndEvent += item =>
        {
            if (item == null || item.GetCell() == null) return;

            if(Builder.IsPointerOverUIObject() == false) item.GetCell().RemoveItem();
        };
    }

    public DragAndDropItem Item()
    {
        return GetComponent<DragAndDropItem>();
    }

    public bool HaveAttribute(StatusAttribute attr)
    {
        return status.Attribute.Contains(attr);
    }
}
