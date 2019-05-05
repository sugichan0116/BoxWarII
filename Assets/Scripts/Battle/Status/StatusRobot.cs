using UnityEngine;

[CreateAssetMenu(
 fileName = "StatusRobot",
 menuName = "ScriptableObject/StatusRobot",
 order = 0)
]
[System.Serializable]
public class StatusRobot : Status
{
    public int maxCost;
    public int jump;

    public override string DetailedText()
    {
        return $"コスト上限 : + {maxCost} \n" +
            $"空中跳躍 : {jump - 1} \n";
    }
}
