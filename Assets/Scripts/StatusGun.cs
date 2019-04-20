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
    public GunBehaviour prefabGun;
}
