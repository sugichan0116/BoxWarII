using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CellRequireAttribute))]
[RequireComponent(typeof(CellUnit))]
public class CellText : MonoBehaviour
{
    public Text text, attr;

    private CellRequireAttribute require;

    // Start is called before the first frame update
    void Start()
    {
        require = GetComponent<CellRequireAttribute>();
        
        attr.text = $"[{require.RequireAttribute()}]";

        GetComponent<CellUnit>().OnChanged += item =>
        {
            if (item != null)
            {
                text.text = Builder.Repeat("●", item.status.cost);
            }
            else text.text = "";
        };
    }

}
