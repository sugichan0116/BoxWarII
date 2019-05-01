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
    public float Destruction = 10f;
    public float FiringSpeedRate = 1f;
    public float CooltimeRate = 1f;
    public List<Vector2> Muzzles = new List<Vector2>();
    public Vector2 offset = new Vector2();

    public override string DetailedText()
    {
        return $"破壊力補正 : + {Destruction} \n" +
            $"銃口 : x {Muzzles.Count} \n" +
            $"加速率 : x {FiringSpeedRate} \n" +
            $"冷却効率 : x {(1 / CooltimeRate).ToString("f2")} \n";
    }
}
