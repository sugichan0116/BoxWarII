using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Image))]
public class CellUnit : MonoBehaviour
{
    public Color error = Color.red;
    public Color success = Color.green;
    
    private ItemUnit item;

    public delegate void EventHandler(ItemUnit item);
    public event EventHandler OnChanged;
    
    private void Update() => UpdateItem();

    private void UpdateItem()
    {
        ItemUnit old = item;
        item = GetComponentInChildren<ItemUnit>();
        if (old != item)
        {
            OnChanged?.Invoke(item);
        }
    }

    public ItemUnit Item() => item;

    public void OnSuccess() => GetComponent<Image>().color = success;
    public void OnError() => GetComponent<Image>().color = error;

    public void OnUsed()
    {
        GetComponent<DragAndDropCell>().RemoveItem();
        OnChanged?.Invoke(item); //??????????????????????????????????????
    }

    public void AddItem(ItemUnit _item)
    {
        if(_item == null)
        {
            Debug.LogWarning("!!!!!!!!!!!???????????");
            return;
        }
        GetComponent<DragAndDropCell>().AddItem(_item.Item());
    }
}
