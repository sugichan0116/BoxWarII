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
    public float Mass = 1f;
    public float FiringSpeed = 100f;
    public float Cooltime = 0.3f;
    public BulletBehaviour prefabBullet;
}
