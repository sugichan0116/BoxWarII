using UnityEngine;

[RequireComponent(typeof(CellUnit))]
public class CellRequireAttribute : MonoBehaviour
{
    private CellUnit cell;
    [SerializeField]
    private string attr;


    // Start is called before the first frame update
    void Start()
    {
        cell = GetComponent<CellUnit>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsValid() == false) cell.OnError();
    }

    private bool IsValid()
    {
        if (attr == "" || cell == null || cell.item == null) return true;

        return cell.item.HaveAttribute(attr);
    }
}
