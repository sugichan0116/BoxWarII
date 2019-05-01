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
