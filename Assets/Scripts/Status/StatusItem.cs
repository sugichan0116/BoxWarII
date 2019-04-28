using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
 fileName = "StatusItem",
 menuName = "ScriptableObject/StatusItem",
 order = 0)
]
[System.Serializable]
public class StatusItem : Status
{
    public ItemAttribute Type;
    public float strongth;

    public override string DetailedText()
    {
        return "This is Item!";
    }
}

public enum ItemAttribute
{
    Default,
    Repair,
    b,
    c
}
