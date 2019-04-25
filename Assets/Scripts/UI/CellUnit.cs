using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Image))]
public class CellUnit : MonoBehaviour
{
    public Color error = new Color();
    private ItemUnit item;

    public delegate void EventHandler(ItemUnit item);

    public event EventHandler OnChanged;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        UpdateItem();
    }

    public void OnError()
    {

        Image bg = GetComponent<Image>();
        bg.color = error;
    }

    public void UpdateItem()
    {
        ItemUnit old = item;
        item = GetComponentInChildren<ItemUnit>();
        if(old != item)
        {
            OnChanged(item);
        }
    }
}
