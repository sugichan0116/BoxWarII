using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(
  fileName = "StatusBullet",
  menuName = "ScriptableObject/StatusBullet",
  order = 0)
]
[System.Serializable]
public class StatusBullet : Status
{
    public float FiringSpeed = 100f;
    public float Cooltime = 0.3f;
    public BulletBehaviour prefabBullet;

    public override string DetailedText()
    {
        return $"破壊力 : {prefabBullet.Destruction} \n" +
            $"初速度 : {FiringSpeed} m/sec \n" +
            $"冷却時間 : {Cooltime} sec \n" +
            SubText();
    }

    private string SubText()
    {
        string text = "";

        ExplosionBehaviour e = prefabBullet.GetComponent<ExplosionBehaviour>();
        if (e != null) text += e.Text();

        ShotgunBehaviour s = prefabBullet.GetComponent<ShotgunBehaviour>();
        if (s != null) text += s.Text();
        
        return text;
    }
}
