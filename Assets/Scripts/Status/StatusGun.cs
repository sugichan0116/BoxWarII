using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(
  fileName = "StatusGun",
  menuName = "ScriptableObject/StatusGun",
  order = 0)
]
[System.Serializable]
public class StatusGun : Status
{
    public float FiringSpeedRate = 1f;
    public float CooltimeRate = 1f;
    public Vector2 offset = new Vector2();

    public override string DetailedText()
    {
        return $"初速倍率 : x {FiringSpeedRate} \n" +
            $"冷却倍率 : x {CooltimeRate} \n";
    }
}
