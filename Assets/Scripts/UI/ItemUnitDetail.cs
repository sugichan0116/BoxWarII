using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ItemUnit))]
public class ItemUnitDetail : MonoBehaviour, IPointerEnterHandler
{
    private DetailManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = Builder.FindGameObject<DetailManager>("ItemDetail");
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        manager.item = GetComponent<ItemUnit>();
    }
}
