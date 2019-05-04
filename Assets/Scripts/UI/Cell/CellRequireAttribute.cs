using UnityEngine;

[RequireComponent(typeof(CellUnit))]
public class CellRequireAttribute : MonoBehaviour
{
    private CellUnit cell;
    [SerializeField]
    private StatusAttribute attr = StatusAttribute.Default;
    
    // Start is called before the first frame update
    void Start()
    {
        if (attr == StatusAttribute.Default) return;

        cell = GetComponent<CellUnit>();
        cell.OnChanged += item => {
            if (item == null) return;

            if (item.HaveAttribute(attr)) cell.OnSuccess();
            else cell.OnError();
        };
    }

    public string RequireAttribute() => attr.ToString();
}
