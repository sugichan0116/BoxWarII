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
        return $"効果 : {Type.ToString()} \n" +
            $"量 : {strongth}";
    }
}

public enum ItemAttribute
{
    Default,
    Repair,
    b,
    c
}
