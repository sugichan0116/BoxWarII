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

    public ItemUnit GetItem()
    {
        ItemUnit item = Instantiate(prefabItem);
        item.status = list[Random.Range(0, list.Count)];
        return item;
    }

    public ItemUnit GetItemByName(string name)
    {
        foreach (var status in list)
        {
            if(status.Name == name)
            {
                ItemUnit item = Instantiate(prefabItem);
                item.status = status;
                return item;
            }
        }

        return null;
    }
}
