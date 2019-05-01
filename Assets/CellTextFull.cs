using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellTextFull : MonoBehaviour
{
    public Text top, bottom;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CellUnit>().OnChanged += item =>
        {
            if (item != null)
            {
                top.text = $"{Builder.Repeat("●", item.status.cost)}";
                bottom.text = $"{item.status.Name}\n" +
                    $"{Builder.Repeat("★", item.status.rare)}";
            }
            else top.text = bottom.text = "";
        };
    }
}
