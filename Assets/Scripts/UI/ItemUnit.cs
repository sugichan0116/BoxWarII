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
            if (item == null) return;
            Debug.Log("aaa");
            if (item.GetCell() == null) return;
            if(Input.mousePosition.y > 300)
            item.GetCell().RemoveItem();
        };
    }

    public DragAndDropItem Item()
    {
        return GetComponent<DragAndDropItem>();
    }

    public bool HaveAttribute(StatusAttribute attr)
    {
        //string d = "@ + " + attr + " // ";
        //foreach (var item in status.Attribute)
        //{
        //    d += item;
        //}

        //Debug.Log(d + status.Attribute.Contains(attr));
        return status.Attribute.Contains(attr);
    }
}
