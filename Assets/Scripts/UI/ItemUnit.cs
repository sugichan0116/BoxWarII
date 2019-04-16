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
    
    public DragAndDropItem Item()
    {
        return GetComponent<DragAndDropItem>();
    }
}
