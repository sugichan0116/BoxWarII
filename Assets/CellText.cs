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

        GetComponent<CellUnit>().OnChanged += item =>
        {
            if (item != null)
            {
                text.text = Builder.Repeat("●", item.status.cost);
                attr.text = $"[{require.RequireAttribute()}]";
            }
            else text.text = attr.text = "";
        };
    }

}
