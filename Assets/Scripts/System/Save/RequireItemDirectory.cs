using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class ItemDirectory
{
    public string title;
    public List<string> items;

    public ItemDirectory(string title, int num)
    {
        this.title = title;
        items = new List<string>();
        for (int i = 0; i < num; i++) items.Add("");
    }
}

public class RequireItemDirectory : MonoBehaviour
{
    public AutoSaveGameData resource;
    public string key;
    public ItemTable listForDecode;

    private ItemDirectory customData;

    private void Awake()
    {
        resource.OnSaveBefore += data => {
            data.directories[key] = customData;
        };

        resource.OnLoadAfter += data => {
            if (data.directories.ContainsKey(key) == false) return;
            customData = data.directories[key];

            InitializeCells();
        };
    }

    void Start()
    {
        if (customData == null)
        {
            int num = GetComponentsInChildren<CellUnit>().Length;
            customData = new ItemDirectory(key, num);
        }

        SubscribeCellsEvent();
    }

    private void SubscribeCellsEvent()
    {
        foreach (var (cell, index) in GetComponentsInChildren<CellUnit>().WithIndex())
        {
            cell.OnChanged += item =>
            {
                customData.items[index] = (item == null) ? "" : item.status.Name;
            };
        }
    }

    private void InitializeCells()
    {
        foreach (var (cell, index) in GetComponentsInChildren<CellUnit>().WithIndex())
        {
            string itemName = customData.items[index];
            cell.AddItem(listForDecode.GetItemByName(itemName));
        }
    }
}
