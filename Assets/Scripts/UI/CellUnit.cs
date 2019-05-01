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
            if(OnChanged != null) OnChanged(item);
        }
    }

    public ItemUnit Item() => item;

    public void OnSuccess() => GetComponent<Image>().color = success;
    public void OnError() => GetComponent<Image>().color = error;

    public void OnUsed() => GetComponent<DragAndDropCell>().RemoveItem();
}
