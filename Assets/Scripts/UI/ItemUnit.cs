using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DragAndDropItem))]
public class ItemUnit : MonoBehaviour
{
    //test parameter
    [SerializeField]
    private float speed;
    [SerializeField]
    private float skill;
    [SerializeField]
    private List<string> attribute;
    
    public DragAndDropItem Item()
    {
        return GetComponent<DragAndDropItem>();
    }

    public bool HaveAttribute(string attr)
    {
        return attribute.Contains(attr);
    }
}
