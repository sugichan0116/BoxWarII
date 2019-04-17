using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Image))]
public class CellUnit : MonoBehaviour
{
    public Color error = new Color();
    public ItemUnit item;

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
        item = GetComponentInChildren<ItemUnit>();
    }
}
