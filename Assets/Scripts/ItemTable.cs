using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
  fileName = "ItemTable",
  menuName = "ScriptableObject/ItemTable",
  order = 0)
]
public class ItemTable : ScriptableObject
{
    public string Name = "new item table";
    public ItemUnit prefabItem;
    public List<Status> list = new List<Status>();

    public ItemUnit GetStatus()
    {
        ItemUnit item = Instantiate(prefabItem);
        item.status = list[Random.Range(0, list.Count)];
        return item;
    }
}
