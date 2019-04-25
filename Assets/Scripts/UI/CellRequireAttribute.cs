using UnityEngine;

[RequireComponent(typeof(CellUnit))]
public class CellRequireAttribute : MonoBehaviour
{
    private CellUnit cell;
    [SerializeField]
    private string attr = "";
    
    // Start is called before the first frame update
    void Start()
    {
        if (attr == "") return;

        cell = GetComponent<CellUnit>();
        cell.OnChanged += item => {
            if (item != null && item.HaveAttribute(attr) == false)
                cell.OnError();
        };
    }
}
