using UnityEngine;
using System.Collections.Generic;
using System.Linq;

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
        foreach (var cell in GetComponentsInChildren<CellUnit>()
            .Select((alphabet, index) => new { Value = alphabet, Index = index }))
        {
            cell.Value.OnChanged += item =>
            {
                if (item == null) customData.items[cell.Index] = "";
                else customData.items[cell.Index] = item.status.Name;
            };
        }
    }

    private void InitializeCells()
    {
        foreach (var cell in GetComponentsInChildren<CellUnit>()
            .Select((alphabet, index) => new { Value = alphabet, Index = index }))
        {
            string itemName = customData.items[cell.Index];
            cell.Value.AddItem(listForDecode.GetItemByName(itemName));
        }
    }
}

